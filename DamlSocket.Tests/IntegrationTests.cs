using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;
using DamlSocket.Services;
using DamlSocket.Extensions;
using DamlSocket.DiExtention;
using Xunit.Abstractions;
using Microsoft.AspNetCore.Http;

using System.IO;
using System.Collections.Generic;

namespace DamlSocket.Tests
{
    public class IntegrationTests
    {
        private readonly ITestOutputHelper _output;

        public IntegrationTests(ITestOutputHelper output)
        {
            _output = output;
        }

        public class TestIvr
        {
            private readonly Client _client;

            public TestIvr(Client client)
            {
                _client = client;
            }

            public async Task TestMethod()
            {
                // Send TwiML and wait for input
                var input = await _client.GetInputAsync("<Response><Say>Hello</Say></Response>");
            }

            public async Task ThrowingMethod()
            {
                await Task.Yield();
                throw new InvalidOperationException("Something went wrong");
            }

            public async Task ThreeStepMethod()
            {
                await _client.GetInputAsync("<Response><Say>Step 1</Say></Response>");
                await _client.GetInputAsync("<Response><Say>Step 2</Say></Response>");
                await _client.GetInputAsync("<Response><Say>Step 3</Say></Response>");
                _client.ExecuteRedirect("<Response><Say>Goodbye</Say></Response>");
            }

            public async Task ContextMethod()
            {
                var context = await _client.GetContextAsync();
                var from = context["From"]?.ToString();
                await _client.GetInputAsync($"<Response><Say>From {from}</Say></Response>");
            }

            public async Task ParameterAccessMethod()
            {
                // 1. Get Initial Context (CallSid, From)
                var context = await _client.GetContextAsync();
                var callSid = context["CallSid"]?.ToString();
                var from = context["From"]?.ToString();
                
                // Echo back CallSid and From
                var input = await _client.GetInputAsync($"<Response><Say>{callSid}|{from}</Say></Response>");
                
                // 2. Get Digits from the next input
                var digits = input["Digits"]?.ToString();
                
                // Echo back Digits
                _client.ExecuteRedirect($"<Response><Say>Digits:{digits}</Say></Response>");
            }

            public async Task AutoRedirectMethod()
            {
                // This TwiML has no Redirect or Action. 
                // The system should automatically append a Redirect to keep the session alive.
                await _client.GetInputAsync("<Response><Say>Keep going</Say></Response>");
                
                // If we get here, it means the Redirect worked and called us back.
                _client.ExecuteRedirect("<Response><Say>Done</Say></Response>");
            }

            public async Task GatherMethod()
            {
                // Gather without action
                await _client.GetInputAsync("<Response><Gather><Say>Enter digits</Say></Gather></Response>");
            }

            public async Task GetTextMethod()
            {
                // GetText without action
                await _client.GetInputAsync("<Response><GetText><Say>Speak now</Say></GetText></Response>");
            }

            public async Task RecordMethod()
            {
                await _client.GetInputAsync("<Response><Record /></Response>");
            }
        }

        [Fact]
        public async Task Test_Auto_Record_Action_Injection()
        {
            using var host = await CreateHost();
            var client = host.GetTestClient();
            var callSid = Guid.NewGuid().ToString();

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("CallSid", callSid),
            });
            
            var response = await client.PostAsync("/daml/RecordMethod", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            
            Assert.Contains("action=\"/daml/RecordMethod\"", responseString);
            Assert.Contains("method=\"POST\"", responseString);
            Assert.Contains("<Record", responseString);
            Assert.DoesNotContain("<Redirect", responseString);
        }

        [Fact]
        public async Task Test_Auto_Redirect_Injection()
        {
            using var host = await CreateHost();
            var client = host.GetTestClient();
            var callSid = Guid.NewGuid().ToString();

            // Step 1: Initial Request via Path (POST)
            // We expect the response to contain a Redirect because the TwiML didn't have one.
            var content1 = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("CallSid", callSid),
                new KeyValuePair<string, string>("From", "123"),
            });
            var response1 = await client.PostAsync("/daml/AutoRedirectMethod", content1);
            response1.EnsureSuccessStatusCode();
            var responseString1 = await response1.Content.ReadAsStringAsync();
            
            Assert.Contains("<Say>Keep going</Say>", responseString1);
            Assert.Contains("<Redirect method=\"POST\">/daml/AutoRedirectMethod</Redirect>", responseString1); 

            // Step 2: Initial Request via Query (POST)
            // Use a new CallSid to start a fresh session
            var callSid2 = Guid.NewGuid().ToString();
            var content2 = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("CallSid", callSid2),
                new KeyValuePair<string, string>("From", "123"),
            });
            var response2 = await client.PostAsync("/daml?method=AutoRedirectMethod", content2);
            response2.EnsureSuccessStatusCode();
            var responseString2 = await response2.Content.ReadAsStringAsync();
            
            Assert.Contains("<Say>Keep going</Say>", responseString2);
            Assert.Contains("<Redirect method=\"POST\">/daml?method=AutoRedirectMethod</Redirect>", responseString2);

            // Step 3: Initial Request via Path (GET)
            // Expect Redirect method="GET"
            var callSid3 = Guid.NewGuid().ToString();
            var response3 = await client.GetAsync($"/daml/AutoRedirectMethod?CallSid={callSid3}&From=123");
            response3.EnsureSuccessStatusCode();
            var responseString3 = await response3.Content.ReadAsStringAsync();
            
            Assert.Contains("<Say>Keep going</Say>", responseString3);
            Assert.Contains($"<Redirect method=\"GET\">/daml/AutoRedirectMethod?CallSid={callSid3}&From=123</Redirect>", responseString3);
        }

        [Fact]
        public async Task Test_Auto_Gather_Action_Injection()
        {
            using var host = await CreateHost();
            var client = host.GetTestClient();
            var callSid = Guid.NewGuid().ToString();

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("CallSid", callSid),
            });
            
            var response = await client.PostAsync("/daml/GatherMethod", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            
            // Expect Action injected with POST
            Assert.Contains("action=\"/daml/GatherMethod\"", responseString);
            Assert.Contains("method=\"POST\"", responseString);
            Assert.Contains("<Gather", responseString);
            
            // Expect NO Redirect
            Assert.DoesNotContain("<Redirect", responseString);
        }

        [Fact]
        public async Task Test_Auto_GetText_Action_Injection()
        {
            using var host = await CreateHost();
            var client = host.GetTestClient();
            var callSid = Guid.NewGuid().ToString();

            // Test POST
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("CallSid", callSid),
            });
            
            var response = await client.PostAsync("/daml/GetTextMethod", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            
            // Expect Action injected with POST
            Assert.Contains("action=\"/daml/GetTextMethod\"", responseString);
            Assert.Contains("method=\"POST\"", responseString);
            Assert.Contains("<GetText", responseString);
            Assert.DoesNotContain("<Redirect", responseString);

            // Test GET
            var callSid2 = Guid.NewGuid().ToString();
            var response2 = await client.GetAsync($"/daml/GetTextMethod?CallSid={callSid2}");
            response2.EnsureSuccessStatusCode();
            var responseString2 = await response2.Content.ReadAsStringAsync();

            // Expect Action injected with GET
            Assert.Contains($"action=\"/daml/GetTextMethod?CallSid={callSid2}\"", responseString2);
            Assert.Contains("method=\"GET\"", responseString2);
            Assert.Contains("<GetText", responseString2);
            Assert.DoesNotContain("<Redirect", responseString2);
        }

        [Fact]
        public async Task Test_Parameter_Access_Inside_Call()
        {
            using var host = await CreateHost();
            var client = host.GetTestClient();
            var callSid = Guid.NewGuid().ToString();
            var fromNumber = "1122334455";

            // Step 1: Start Call
            var content1 = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("CallSid", callSid),
                new KeyValuePair<string, string>("From", fromNumber),
            });
            var response1 = await client.PostAsync("/daml/ParameterAccessMethod", content1);
            response1.EnsureSuccessStatusCode();
            var responseString1 = await response1.Content.ReadAsStringAsync();
            Assert.Contains($"{callSid}|{fromNumber}", responseString1);

            // Step 2: Send Digits
            var content2 = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("CallSid", callSid),
                new KeyValuePair<string, string>("Digits", "42"),
            });
            var response2 = await client.PostAsync("/daml/ParameterAccessMethod", content2);
            response2.EnsureSuccessStatusCode();
            var responseString2 = await response2.Content.ReadAsStringAsync();
            Assert.Contains("Digits:42", responseString2);
        }

        [Fact]
        public async Task Test_Context_Retrieval()
        {
            using var host = await CreateHost();
            var client = host.GetTestClient();
            var callSid = Guid.NewGuid().ToString();
            var fromNumber = "9876543210";

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("CallSid", callSid),
                new KeyValuePair<string, string>("From", fromNumber),
            });

            var response = await client.PostAsync("/daml/ContextMethod", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            
            Assert.Contains($"<Response><Say>From {fromNumber}</Say><Redirect method=\"POST\">/daml/ContextMethod</Redirect></Response>", responseString);
        }

        [Fact]
        public async Task Test_Three_Step_Conversation()
        {
            using var host = await CreateHost();
            var client = host.GetTestClient();
            var callSid = Guid.NewGuid().ToString();

            // Step 1: Start Call
            var content1 = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("CallSid", callSid),
                new KeyValuePair<string, string>("From", "1234567890"),
            });
            var response1 = await client.PostAsync("/daml/ThreeStepMethod", content1);
            response1.EnsureSuccessStatusCode();
            Assert.Contains("Step 1", await response1.Content.ReadAsStringAsync());

            // Step 2: Respond to Step 1
            var content2 = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("CallSid", callSid),
                new KeyValuePair<string, string>("Digits", "1"),
            });
            var response2 = await client.PostAsync("/daml/ThreeStepMethod", content2);
            response2.EnsureSuccessStatusCode();
            Assert.Contains("Step 2", await response2.Content.ReadAsStringAsync());

            // Step 3: Respond to Step 2
            var content3 = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("CallSid", callSid),
                new KeyValuePair<string, string>("Digits", "2"),
            });
            var response3 = await client.PostAsync("/daml/ThreeStepMethod", content3);
            response3.EnsureSuccessStatusCode();
            Assert.Contains("Step 3", await response3.Content.ReadAsStringAsync());

            // Step 4: Respond to Step 3 (Final)
            var content4 = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("CallSid", callSid),
                new KeyValuePair<string, string>("Digits", "3"),
            });
            var response4 = await client.PostAsync("/daml/ThreeStepMethod", content4);
            response4.EnsureSuccessStatusCode();
            Assert.Contains("Goodbye", await response4.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task Post_To_DamlSocket_Returns_TwiML()
        {
            using var host = await CreateHost();
            var client = host.GetTestClient();
            var callSid = Guid.NewGuid().ToString();

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("CallSid", callSid),
                new KeyValuePair<string, string>("From", "1234567890"),
            });

            var response = await client.PostAsync("/daml?method=TestMethod", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            
            Assert.Contains("<Response><Say>Hello</Say><Redirect method=\"POST\">/daml?method=TestMethod</Redirect></Response>", responseString);
        }

        [Fact]
        public async Task Get_To_DamlSocket_Returns_TwiML()
        {
            using var host = await CreateHost();
            var client = host.GetTestClient();
            var callSid = Guid.NewGuid().ToString();

            var response = await client.GetAsync($"/daml?method=TestMethod&CallSid={callSid}&From=1234567890");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            
            Assert.Contains($"<Response><Say>Hello</Say><Redirect method=\"GET\">/daml?method=TestMethod&CallSid={callSid}&From=1234567890</Redirect></Response>", responseString);
        }

        [Fact]
        public async Task Exception_In_IVR_Returns_500()
        {
            using var host = await CreateHost();
            var client = host.GetTestClient();
            var callSid = Guid.NewGuid().ToString();

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("CallSid", callSid),
                new KeyValuePair<string, string>("From", "1234567890"),
            });

            var response = await client.PostAsync("/daml?method=ThrowingMethod", content);
            
            Assert.Equal(System.Net.HttpStatusCode.InternalServerError, response.StatusCode);
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Something went wrong", responseString);
        }

        [Fact]
        public async Task Post_To_DamlSocket_With_RouteParam_Returns_TwiML()
        {
            using var host = await CreateHost();
            var client = host.GetTestClient();
            var callSid = Guid.NewGuid().ToString();

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("CallSid", callSid),
                new KeyValuePair<string, string>("From", "1234567890"),
            });

            // Request using route parameter instead of query string
            var response = await client.PostAsync("/daml/TestMethod", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            
            Assert.Contains("<Response><Say>Hello</Say><Redirect method=\"POST\">/daml/TestMethod</Redirect></Response>", responseString);
        }

        private async Task<IHost> CreateHost()
        {
            return await Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseTestServer();
                    webBuilder.ConfigureServices(services =>
                    {
                        services.AddLogging();
                        services.AddDamlSocket();
                        services.AddScoped<TestIvr>();
                    });
                    webBuilder.Configure(app =>
                    {
                        app.UseRouting();
                        app.UseEndpoints(endpoints =>
                        {
                            // Updated to support optional method parameter
                            endpoints.MapDamlSocket("/daml/{method?}");
                        });
                    });
                })
                .StartAsync();
        }
    }
}
