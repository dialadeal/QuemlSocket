using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DamlSocket.Behaviors;
using DamlSocket.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;

namespace DamlSocket.Extensions
{
    public static class EndpointRouteBuilderExtensions
    {
        public static IEndpointConventionBuilder MapDamlSocket(this IEndpointRouteBuilder endpoints, string pattern)
        {
            return endpoints.MapMethods(pattern, new[] { "GET", "POST" }, async context =>
            {
                var createSession = context.RequestServices.GetRequiredService<CreateSession>();

                var parameters = new JObject();

                // Handle Query
                foreach (var query in context.Request.Query)
                {
                    parameters[query.Key] = query.Value.ToString();
                }

                // Handle Form
                if (context.Request.HasFormContentType)
                {
                    var form = await context.Request.ReadFormAsync();
                    foreach (var field in form)
                    {
                        parameters[field.Key] = field.Value.ToString();
                    }
                }

                // Determine Method
                string method = null;
                if (parameters.ContainsKey("method"))
                {
                    method = parameters["method"].ToString();
                }
                else if (context.Request.RouteValues.ContainsKey("method"))
                {
                    method = context.Request.RouteValues["method"]?.ToString();
                }
                
                var request = new Request
                {
                    ID = Guid.NewGuid().ToString(),
                    JSONRPC = "2.0",
                    Method = method,
                    Parameters = parameters,
                    RequestUri = context.Request.Path + context.Request.QueryString,
                    HttpMethod = context.Request.Method
                };

                try
                {
                    var response = await createSession.welcome(request);
                    context.Response.ContentType = "application/xml";
                    await context.Response.WriteAsync(response);
                }
                catch (Exception ex)
                {
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync(ex.ToString());
                }
            });
        }
    }
}
