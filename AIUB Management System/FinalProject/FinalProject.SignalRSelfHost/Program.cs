﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;

using FinalProject.SignalRSelfHost.Hubs;

namespace FinalProject.SignalRSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses. 
            // See http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx 
            // for more information.
            string url = "http://localhost:8089";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                while (true)
                {
                    string key = Console.ReadLine();
                    if (key.ToUpper() == "W")
                    {
                        IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<SignalRMainHub>();
                        hubContext.Clients.All.addMessage("server", "ServerMessage");
                        Console.WriteLine("Server Sending addMessage\n");
                    }
                    if (key.ToUpper() == "E")
                    {
                        IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<SignalRMainHub>();
                        hubContext.Clients.All.heartbeat();
                        Console.WriteLine("Server Sending heartbeat\n");
                    }
                    //if (key.ToUpper() == "R")
                    //{
                    //    IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();

                    //    var vv = new HelloModel {Age = 37, Molly = "pushed direct from Server "};

                    //    hubContext.Clients.All.sendHelloObject(vv);
                    //    Console.WriteLine("Server Sending sendHelloObject\n");
                    //}
                    if (key.ToUpper() == "C")
                    {
                        break;
                    }
                }

                Console.ReadLine();
            }

        }
    }
}
