using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.Protocols;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static RosSharp.RosBridgeClient.RosSocket;


namespace RosTest
{
    public class RosConnector : ICommunicator  
    {
        public RosSocket RosSocket { get; set; }
        private IProtocol protocol;
        private readonly int SecondsTimeout = 10;
        private readonly string RosBridgeServerUrl;
        public ManualResetEvent IsConnected { get;  set; }

        Dictionary<string, IPublisher> publishers;
        public RosConnector(string rosBridgeServerUrl)
        {
            try
            {
                RosBridgeServerUrl = rosBridgeServerUrl;
                IsConnected = new ManualResetEvent(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void RegisterPublisher(string topic, string id, Message message)
        {
            Task.Run(()=> { RosSocket.Publish(id, message); });
        }

        public void RegisterSubscriber()
        {
            //Subscribe<T>(Topic, ReceiveMessage, (int)(TimeStep * 1000)); 
        }

        public void ConnectAndWait()
        {
            try
            {
                protocol = new WebSocketSharpProtocol(RosBridgeServerUrl);
                protocol.OnConnected += OnConnected;
                protocol.OnClosed += OnClosed;
                RosSocket = new RosSocket(protocol);

                if (!IsConnected.WaitOne(SecondsTimeout * 1000))
                    Console.WriteLine("Failed to connect to RosBridge at: " + RosBridgeServerUrl);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
           
        }
        
        private void OnConnected(object sender, EventArgs e)
        {
            IsConnected.Set();
            Console.WriteLine("Connected to RosBridge: " + RosBridgeServerUrl);
        }

        private void OnClosed(object sender, EventArgs e)
        {
            IsConnected.Reset();
            protocol.OnConnected -= OnConnected;
            protocol.OnClosed -= OnClosed;
            Console.WriteLine("Disconnected from RosBridge: " + RosBridgeServerUrl);
        }
    }
}
