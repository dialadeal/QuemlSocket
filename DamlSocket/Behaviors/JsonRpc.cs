using System;
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
                var response = ListenerStartup._createSession.welcome(request);

                var respond = Response.Create(request.ID);
                respond.Result = response;
                Send(respond.ToJSON());
            }
            catch (Exception ex)
            {
                
                var respond = Response.CreateError(request.ID, -32603, ex.Message);

                Send(respond.ToJSON());
            }
        }
    }
}