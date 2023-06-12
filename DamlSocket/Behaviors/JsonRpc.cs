using System;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace DamlSocket.Behaviors
{
    public class JsonRpc : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var request = Request.Parse(e.Data);

            try
            {
                ListenerStartup._logger.LogInformation($"Request: {e.Data}");

                var response = ListenerStartup._createSession.welcome(request);
                
                ListenerStartup._logger.LogInformation($"Response: {response}");

                var respond = Response.Create(request.ID);
                respond.Result = response;
                
                ListenerStartup._logger.LogDebug($"Response: {respond.ToJSON()}");
                Send(respond.ToJSON());
            }
            catch (Exception ex)
            {
                var respond = Response.CreateError(request.ID, -32603, ex.Message);

                ListenerStartup._logger.LogError(
                    $"Error: {JsonConvert.SerializeObject(ex, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Ignore })}");
                
                ListenerStartup._logger.LogError($"Response: {respond.ToJSON()}");
                Send(respond.ToJSON());
            }
        }
    }
}