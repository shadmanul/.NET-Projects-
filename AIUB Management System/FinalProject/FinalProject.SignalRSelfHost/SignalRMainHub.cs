using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace FinalProject.SignalRSelfHost.Hubs
{
    public class SignalRMainHub : Hub
    {
        public void AddMessage(string who, string message)
        {
            Console.WriteLine("Hub AddMessage {0} {1}\n", who, message);
            Clients.All.addMessage(who, message);
        }


        public override Task OnConnected()
        {
            Console.WriteLine("Hub OnConnected {0}\n", Context.ConnectionId);
            return (base.OnConnected());
        }

        public override Task OnDisconnected()
        {
            Console.WriteLine("Hub OnDisconnected {0}\n", Context.ConnectionId);
            return (base.OnDisconnected());
        }

        public override Task OnReconnected()
        {
            Console.WriteLine("Hub OnReconnected {0}\n", Context.ConnectionId);
            return (base.OnDisconnected());
        }


    }
}
