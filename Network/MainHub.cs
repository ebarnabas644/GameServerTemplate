using Microsoft.AspNetCore.SignalR;
using ProjectRPS.Core.State;
using ProjectRPS.Hubs.MessageProcessors;
using ProjectRPS.Hubs.Models;

namespace ProjectRPS.Hubs;

public partial class MainHub : Hub
{
    private ILogger<MainHub> _logger;
    private IEnumerable<IMessageProcessor> _messageProcessors;
    private IGameState _gameState;

    public MainHub(ILogger<MainHub> logger, IEnumerable<IMessageProcessor> messageProcessors, IGameState gameState)
    {
        _logger = logger;
        _messageProcessors = messageProcessors;
        _gameState = gameState;
    }
    
    public override async Task OnConnectedAsync()
    {
        var connectionId = Context.ConnectionId;
        var id = _gameState.CreatePlayerEntity(connectionId);
        await Clients.Client(connectionId).SendAsync("playerCreated", id);
        _logger.LogInformation($"Player connected with id: {connectionId}");
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        _gameState.DeletePlayerEntity(Context.ConnectionId);
        _logger.LogInformation($"Player disconnected with id: {Context.ConnectionId}");
    }

    public async Task SendUpdateMessage(string topic, string message)
    {
        await Clients.All.SendAsync(topic, message);
    }

    public async Task ClientMessage(Message message)
    {
        var processor = _messageProcessors.FirstOrDefault(x => x.IsTypeOf(message.Type));
        processor?.Process(message.Data, Context.ConnectionId);
    }
}