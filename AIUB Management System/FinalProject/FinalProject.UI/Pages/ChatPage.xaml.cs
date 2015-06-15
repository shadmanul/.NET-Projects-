using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using System.Windows.Threading;
using FinalProject.UI.Dto;

namespace FinalProject.UI.Pages
{
    /// <summary>
    /// Interaction logic for ChatPage.xaml
    /// </summary>
    public partial class ChatPage : UserControl
    {
        string id;
        
        public System.Threading.Thread Thread { get; set; }
        public string Host = "http://localhost:8089/";
        int count = 0;

        public IHubProxy Proxy { get; set; }
        public HubConnection Connection { get; set; }

        public bool Active { get; set; }
        public ChatPage()
        {
            InitializeComponent();
            
        }
        private async void ActionHeartbeatButtonClick(object sender, RoutedEventArgs e)
        {
            await SendHeartbeat();
        }

        private async void ActionSendButtonClick(object sender, RoutedEventArgs e)
        {
            await SendMessage();
        }

        private async Task SendMessage()
        {
            await Proxy.Invoke("AddMessage", id, MessageTextBox.Text);
        }

        private async Task SendHeartbeat()
        {
            await Proxy.Invoke("Heartbeat");
        }

        private async void ActionWindowLoaded(object sender, RoutedEventArgs e)
        {
            if (count == 0)
            {
                id = Properties.Settings.Default.UserID;
                //ClientNameTextBox.Text = id;
                Active = true;
                Thread = new System.Threading.Thread(() =>
                {
                    Connection = new HubConnection(Host);
                    Proxy = Connection.CreateHubProxy("SignalRMainHub");

                    Proxy.On<string, string>("addmessage", (name, message) => OnSendData(DateTime.Now.ToShortTimeString()+"    ["+ name + "]\t " + message));
                    Proxy.On("heartbeat", () => OnSendData("Recieved heartbeat <3"));
                    Proxy.On<HelloModel>("sendHelloObject", hello => OnSendData("Recieved sendHelloObject " + hello.Molly + " " + hello.Age));

                    Connection.Start();

                    while (Active)
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                }) { IsBackground = true };
                
                Thread.Start();
                
                count++;
            }

        }

        private void OnSendData(string message)
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() => MessagesListBox.Items.Add(message)));
            
        }

        private async void ActionMessageTextBoxOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                await SendMessage();
                MessageTextBox.Text = "";
                MessagesListBox.ScrollIntoView(MessagesListBox.Items[MessagesListBox.Items.Count - 1]);
            }
        }
        
        
    }
}
