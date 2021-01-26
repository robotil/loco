using RosSharp.RosBridgeClient;

namespace RosTest
{
    public interface IPublisher
    {
        void Publish<T>(T message) where T : Message;
    }
}