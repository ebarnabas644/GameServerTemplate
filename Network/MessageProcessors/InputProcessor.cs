namespace ProjectRPS.Hubs.MessageProcessors;

public class InputProcessor : IMessageProcessor
{
    public async Task Process(string data)
    {
        //Console.WriteLine("input received");
    }

    public bool IsTypeOf(string type)
    {
        return type == "input";
    }
}