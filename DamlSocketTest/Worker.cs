using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DamlSocket;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DamlSocketTest
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private ListenerStartup _listenerStartup;

        public Worker(ILogger<Worker> logger, ListenerStartup listenerStartup)
        {
            _logger = logger;
            _listenerStartup=listenerStartup;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _listenerStartup.Start();
        }
    }
}