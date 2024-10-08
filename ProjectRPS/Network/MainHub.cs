﻿using Microsoft.AspNetCore.SignalR;
using ProjectRPS.Core.Builders;
using ProjectRPS.Core.State;
using ProjectRPS.Hubs.MessageProcessors;
using ProjectRPS.Hubs.Models;

namespace ProjectRPS.Hubs;

public partial class MainHub : Hub
{
    private ILogger<MainHub> _logger;
    private IEnumerable<IMessageProcessor> _messageProcessors;
    private IGameState _gameState;
    private IEntityBuilder _entityBuilder;

    public MainHub(ILogger<MainHub> logger, IEnumerable<IMessageProcessor> messageProcessors, IGameState gameState, IEntityBuilder entityBuilder)
    {
        _logger = logger;
        _messageProcessors = messageProcessors;
        _gameState = gameState;
        _entityBuilder = entityBuilder;
    }
    
    public override async Task OnConnectedAsync()
    {
        var connectionId = Context.ConnectionId;
        var player = _entityBuilder.BuildPlayer(connectionId);
        _gameState.AddEntity(player);
        var id = player.Id;
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