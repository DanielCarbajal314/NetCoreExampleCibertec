using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Presentation.WebApi.Hubs
{
    public class MessageHub : Hub
    {
        public void SendMessageToClients(string message)
        {
            Clients.All.SendAsync("MessageFromServer",message);
        }



    }
}
