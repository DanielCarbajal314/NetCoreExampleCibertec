using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Sales.Presentation.WebApi.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sales.Presentation.WebApi.Tasks
{
    public class AutomaticMessages : BackgroundService
    {
        private readonly IHubContext<MessageHub> _messageHubContext;
        private Timer timer;

        public AutomaticMessages(IHubContext<MessageHub> messageHubContext)
        {
            this._messageHubContext = messageHubContext;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            this.timer = new Timer(taskToExecute, null, TimeSpan.Zero, TimeSpan.FromSeconds(20));
            return Task.CompletedTask;
        }

        private void taskToExecute(object state) {
            this._messageHubContext.Clients.All.SendAsync("MessageFromServer", $"Hola desde el servidor a las {DateTime.Now.ToLongTimeString()}");
        }
    }
}
