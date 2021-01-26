using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RosTest
{
    class Program
    {

        static void Main(string[] args)
        {
            var rosConnector = new RosConnector("ws://192.168.0.101:9090");

            Console.WriteLine("Press any key to close...");
            Console.ReadKey(true);
        }
    }
}
