

using RosTest.Messages;

namespace RosTest
{
    public class TestPublisher : RosPublisher<Test> 
    {
        override protected string Topic => "Test";
        public TestPublisher(ICommunicator rosConnector) : base(rosConnector)
        {
        }
    }
}
