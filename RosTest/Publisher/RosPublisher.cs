using RosSharp.RosBridgeClient;

namespace RosTest
{
    public abstract class RosPublisher<T> : Message where T : Message //, IPublisher
    {
        private readonly ICommunicator rosConnector;
        virtual protected string Topic { get; set; }

        private string publicationId;

        public RosPublisher(ICommunicator rosConnector)
        {
            this.rosConnector = rosConnector;
            publicationId = this.rosConnector.RosSocket.Advertise<T>(Topic);
          
        }
        virtual protected void Publish(T message)
        {
            rosConnector.RosSocket.Publish(publicationId, message);
        }
    }
}
