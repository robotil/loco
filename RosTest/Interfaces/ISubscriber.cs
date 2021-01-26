using RosSharp.RosBridgeClient;

namespace RosTest
{
    public interface ISubscriber
    {
        string Topic { get; set; }
        float TimeStep { get; set; }
    }
}