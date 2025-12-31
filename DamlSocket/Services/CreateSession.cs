using System;
using System.Linq;
using System.Threading.Tasks;
using DamlSocket.Behaviors;
using DamlSocket.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;

namespace DamlSocket.Services
{
    public class CreateSession
    {
        IServiceProvider _serviceProvider;

        public CreateSession(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public async Task<string> welcome(Request request)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => 
                {
                    try
                    {
                        return s.GetTypes();
                    }
                    catch (System.Reflection.ReflectionTypeLoadException e)
                    {
                        return e.Types.Where(t => t != null);
                    }
                    catch
                    {
                        return Type.EmptyTypes;
                    }
                });

            var type = types
                .FirstOrDefault(x => x.GetMethods().Any(c => string.Equals(c.Name, request.Method, StringComparison.OrdinalIgnoreCase)));

            if (type == null)
            {
                throw new Exception($"Method '{request.Method}' not found in any type.");
            }

            var parameters = request.Parameters as JObject;
            var callSid = parameters.GetValue("callSid", StringComparison.OrdinalIgnoreCase)?.ToString();
            
            if (string.IsNullOrEmpty(callSid))
            {
                 throw new Exception("callSid not found in parameters.");
            }

            var scope = CallScope.CreateOrGetScope(callSid,
                _serviceProvider);
            var client = scope.ServiceProvider.GetRequiredService(typeof(Client)) as Client;
            var typeInstance = scope.ServiceProvider.GetRequiredService(type);

            if (!client.CallInProgress)
            {
                Task.Run(async () =>
                {
                    try
                    {
                        await (((Task)type.GetMethods().First(x => string.Equals(x.Name, request.Method, StringComparison.CurrentCultureIgnoreCase))
                            .Invoke(typeInstance, null))!);
                    }
                    catch (HangupException e)
                    {
                        Console.WriteLine(e);
                    }
                    catch (ServerTimeoutException e)
                    {
                        Console.WriteLine(e);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        client.SetError(e);
                    }
                    

                });
                client.SetContext(request.Parameters as JObject);
            }
            else
            {
                client.Tcs.SetResult(request.Parameters as JObject);
            }


            var response = await client.GetResponseAsync();

            client.CallInProgress = true;
            return response;
        }
    }
}