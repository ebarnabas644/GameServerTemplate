namespace ProjectRPS.Hubs.MessageProcessors;

public interface IMessageProcessor
{
    Task Process(string data, string connectionId);
    bool IsTypeOf(string type);
}