using RosTest.Messages;
using System;

namespace RosTest
{
    // /state/heartbeat  std_msgs/UInt32MultiArray 
    // UInt32  std_msgs/ /mcu/state/behaviorMode
    public class HeartbeatSubscriber : RosSubscriber<Test>
    {

        override protected string Topic => "/state/heartbeat";
        public HeartbeatSubscriber(ICommunicator rosConnector) : base( rosConnector)
        {
            
        }
        protected override void ReceiveMessage(Test message)
        {
            Console.WriteLine("Receive Message heartbeat");
        }
    }
}
