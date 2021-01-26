using RosSharp.RosBridgeClient;
using System.Threading;

namespace RosTest
{
    public interface ICommunicator
    {
        void RegisterPublisher(string topic, string id, Message message);

        void RegisterSubscriber();

        ManualResetEvent IsConnected { get; set; }

        void ConnectAndWait();

        /// <summary>
        /// Need to ramoved !!!!
        /// </summary>
        RosSocket RosSocket { get; set; }
    }
}