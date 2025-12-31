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
            
            Assert.Contains("<Response><Say>Hello</Say></Response>", responseString);
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
            
            Assert.Contains("<Response><Say>Hello</Say></Response>", responseString);
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
            
            Assert.Contains("<Response><Say>Hello</Say></Response>", responseString);
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
