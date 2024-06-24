using System.Text.Json;
using ProjectRPS.Core.Components;
using ProjectRPS.Core.Models;
using ProjectRPS.Core.State;

namespace ProjectRPS.Hubs.MessageProcessors;

public class InputProcessor : IMessageProcessor
{
    private readonly ILogger<InputProcessor> _logger;
    private readonly IGameState _gameState;
    
    public InputProcessor(ILogger<InputProcessor> logger, IGameState gameState)
    {
        _logger = logger;
        _gameState = gameState;
    }
    
    public async Task Process(string data)
    {
        var parsed = JsonSerializer.Deserialize<List<KeyInput>>(data);
        var player = _gameState.GetGameState().FirstOrDefault();
        if (player != null)
        {
            var velocity = player.GetComponent("Velocity") as VelocityComponent;
            velocity.Velocity.X += 1;
        }
        _logger.LogInformation($"Input received: {string.Join(',', parsed.Select(x => x.Input))}");
    }

    public bool IsTypeOf(string type)
    {
        return type == "input";
    }
}