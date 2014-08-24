using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace MyChatApp
{
    [HubName("MyChatHub")]
    public class chatapp : Microsoft.AspNet.SignalR.Hub
    {
        public void send(string message)
        {
            Clients.All.addMessage(message);

        }
    }
}