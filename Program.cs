using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.Protocols;
using RosSharp.RosBridgeClient.Messages;

namespace RosBridgeClientTest
{
    class Program
    {
        // 
        static readonly string RosBridgeServerUrl = "ws://172.23.40.13:9090";
        static void Main(string[] args)
        {

            var protocol = new WebSocketSharpProtocol(RosBridgeServerUrl);
            protocol.OnConnected += OnConnected;
            protocol.OnClosed += OnClosed;
            var RosSocket = new RosSocket(protocol);

            RosSocket.Subscribe<RosSharp.RosBridgeClient.Messages.Standard.UInt32>("/vision60/mcu/state/behaviorMode", behaviorModeHandler);
            Console.ReadKey();

            var msg = new RosSharp.RosBridgeClient.Messages.Standard.UInt32();
            msg.data = 1;
            var id = RosSocket.Advertise<RosSharp.RosBridgeClient.Messages.Standard.UInt32>("/vision60/behaviorMode");
            RosSocket.Publish(id, msg);
            Console.ReadKey();

            RosSocket.Close();
        }

        private static void behaviorModeHandler(RosSharp.RosBridgeClient.Messages.Standard.UInt32 msg)
        {
            Console.WriteLine("behaviorModeHandler Msg" + msg);
        }

        private static void OnClosed(object sender, EventArgs e)
        {
            Console.WriteLine("Connected to RosBridge: " + RosBridgeServerUrl);
        }

        private static void OnConnected(object sender, EventArgs e)
        {
            Console.WriteLine("Disconnected from RosBridge: " + RosBridgeServerUrl);
        }
    }

}
