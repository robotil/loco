using RosSharp.RosBridgeClient;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RosTest
{
    public abstract class RosSubscriber<T> :  Message where T : Message //, ISubscriber
    {
        virtual protected string Topic { get; set; }
        virtual protected float TimeStep { get; set; }

        private readonly int SecondsTimeout = 1;
        private readonly ICommunicator rosConnector;

        protected RosSubscriber(ICommunicator rosConnector)
        {
            new Task(Subscribe).Start();
            this.rosConnector = rosConnector;
        }

        private void Subscribe()
        {

            if (!rosConnector.IsConnected.WaitOne(SecondsTimeout * 1000))
                Console.WriteLine("Failed to subscribe: RosConnector not connected");

            rosConnector.RosSocket.Subscribe<T>(Topic, ReceiveMessage, (int)(TimeStep * 1000)); // the rate(in ms in between messages) at which to throttle the topics
        }

        protected abstract void ReceiveMessage(T message);

    }
}
