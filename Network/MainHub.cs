using Microsoft.AspNetCore.SignalR;
using ProjectRPS.Hubs.MessageProcessors;
using ProjectRPS.Hubs.Models;

namespace ProjectRPS.Hubs;

public partial class MainHub : Hub
{
    private ILogger<MainHub> _logger;
    private IEnumerable<IMessageProcessor> _messageProcessors;

    public MainHub(ILogger<MainHub> logger, IEnumerable<IMessageProcessor> messageProcessors)
    {
        _logger = logger;
        _messageProcessors = messageProcessors;
    }
    
    public override async Task OnConnectedAsync()
    {
        var id = Context.ConnectionId;
        _logger.LogInformation($"Player connected with id: {id}");
        await Clients.Client(Context.ConnectionId).SendAsync("initial", "Hello there");
    }

    public async Task SendUpdateMessage(string topic, string message)
    {
        await Clients.All.SendAsync(topic, message);
    }

    public async Task ClientMessage(Message message)
    {
        var processor = _messageProcessors.FirstOrDefault(x => x.IsTypeOf(message.Type));
        processor?.Process(message.Data);
    }
}