using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WebSocketSharp.Server;
using WorkerServiceSuperSocket.Services;

namespace WorkerServiceSuperSocket
{
    public class ListenerStartup
    {
        WebSocketServer _server;
        IServiceProvider _serviceProvider;
        public static  List<object> _services = new List<object>();
        
        public static CreateSession _createSession;

        public ListenerStartup(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
          
        }

        public void Start()
        {
            _server = new WebSocketServer(4649);
            _server.AddWebSocketService<Behaviors.JsonRpc>("/json-rpc");

            // Start the server and keep it running until the user presses a key.
            _server.Start();

            _createSession = _serviceProvider.GetService<CreateSession>();
            _services.Add(_createSession);
        }

       

        public void Stop()
        {
            _server.Stop();
        }
    }
}