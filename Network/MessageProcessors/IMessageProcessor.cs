namespace ProjectRPS.Hubs.MessageProcessors;

public interface IMessageProcessor
{
    Task Process(string data);
    bool IsTypeOf(string type);
}