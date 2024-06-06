using System.Text.Json;
using ProjectRPS.Core.Models;

namespace ProjectRPS.Hubs.MessageProcessors;

public class InputProcessor : IMessageProcessor
{
    private readonly ILogger<InputProcessor> _logger;
    
    public InputProcessor(ILogger<InputProcessor> logger)
    {
        _logger = logger;
    }
    
    public async Task Process(string data)
    {
        var parsed = JsonSerializer.Deserialize<List<KeyInput>>(data);
        _logger.LogInformation($"Input received: {string.Join(',', parsed.Select(x => x.Input))}");
    }

    public bool IsTypeOf(string type)
    {
        return type == "input";
    }
}