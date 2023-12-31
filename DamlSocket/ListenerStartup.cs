using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using DamlSocket.Behaviors;
using DamlSocket.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// using WebSocketSharp.Server;

namespace DamlSocket
{
    public class ListenerStartup
    {
        // WebSocketServer _server;
        IServiceProvider _serviceProvider;
        public static List<object> _services = new List<object>();

        public static CreateSession _createSession;
        public static int Port = 4649;

        TcpListener _tcpListener;

        public static ILogger<ListenerStartup> _logger;

        public ListenerStartup(IServiceProvider serviceProvider, ILogger<ListenerStartup> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task Start()
        {
            _createSession = _serviceProvider.GetService<CreateSession>();
            _services.Add(_createSession);

            _tcpListener = new TcpListener(IPAddress.Any, Port);
            _tcpListener.Start();

            _logger.LogInformation($"Listening on port {Port}");

            _tcpListener.BeginAcceptTcpClient(OnClientConnecting, _tcpListener);
        }


        public void Stop()
        {
            _tcpListener.Stop();
        }

        static void OnClientConnecting(IAsyncResult ar)
        {
            try
            {
                if (ar.AsyncState is null)
                    throw new Exception("AsyncState is null. Pass it as an argument to BeginAcceptSocket method");

                // Get the server. This was passed as an argument to BeginAcceptSocket method
                TcpListener s = (TcpListener)ar.AsyncState;

                // listen for more clients. Note its callback is this same method (recusive call)
                s.BeginAcceptTcpClient(OnClientConnecting, s);

                // Get the client that is connecting to this server
                while (true)
                {
                    var client = s.EndAcceptTcpClient(ar);
                    if (client.Connected)
                    {
                        // handle this client

                        // read data sent to this server by client that just connected
                        byte[] buffer = new byte[client.ReceiveBufferSize];
                        var i = client.Client.Receive(buffer);

                        var requestString = System.Text.Encoding.UTF8.GetString(buffer, 0, i);

                        string respondString = null;
                        Request request = null;
                        try
                        {
                            request = Request.Parse(requestString);
                            ListenerStartup._logger.LogInformation($"Request: {requestString}");

                            var response = ListenerStartup._createSession.welcome(request).ConfigureAwait(false)
                                .GetAwaiter().GetResult();

                            ListenerStartup._logger.LogInformation($"Response: {response}");

                            var respond = Response.Create(request.ID);
                            respond.Result = response;

                            ListenerStartup._logger.LogDebug($"Response: {respond.ToJSON()}");

                            respondString = respond.ToJSON();
                        }
                        catch (Exception ex)
                        {
                            var respond = Response.CreateError(request?.ID, -32603, ex.Message);

                            ListenerStartup._logger.LogError(
                                $"Error: {JsonConvert.SerializeObject(ex, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Ignore })}");

                            ListenerStartup._logger.LogError($"Response: {respond.ToJSON()}");

                            respondString = respond.ToJSON();
                        }


                        byte[] msg = System.Text.Encoding.UTF8.GetBytes(respondString);


                        // reply back the same data that was received to the client
                        var k = client.Client.Send(msg);
                        
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}