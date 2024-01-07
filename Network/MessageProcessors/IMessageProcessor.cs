namespace ProjectRPS.Hubs.MessageProcessors;

public interface IMessageProcessor
{
    Task Process(object data);
    bool IsTypeOf(string type);
}