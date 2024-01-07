namespace ProjectRPS.Hubs.MessageProcessors;

public class InputProcessor : IMessageProcessor
{
    public async Task Process(object data)
    {
        
    }

    public bool IsTypeOf(string type)
    {
        return type == "input";
    }
}