using Microsoft.AspNetCore.SignalR;

namespace ProjectRPS.Hubs;

public interface IMessageSender
{
    Task SendMessage(string topic, string message);
}

public class MessageSender : IMessageSender
{
    private readonly IHubContext<MainHub> _messageHub;

    public MessageSender(IHubContext<MainHub> messageHub)
    {
        this._messageHub = messageHub;
    }
    
    public async Task SendMessage(string topic, string message)
    {
        await _messageHub.Clients.All.SendAsync(topic, message);
    }
}