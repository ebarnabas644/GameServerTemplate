using Microsoft.AspNetCore.SignalR;

namespace ProjectRPS.Hubs.MessageProcessors;

public class ChatProcessor : IMessageProcessor
{
    private IHubContext<MainHub> _messageHub;

    public ChatProcessor(IHubContext<MainHub> messageHub)
    {
        _messageHub = messageHub;
    }

    public async Task Process(object data)
    {
        await _messageHub.Clients.All.SendAsync("message", data);
    }

    public bool IsTypeOf(string type)
    {
        return type == "chat";
    }
}