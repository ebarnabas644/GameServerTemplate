using Microsoft.AspNetCore.SignalR;

namespace ProjectRPS.Hubs;

public partial class MainHub : Hub
{
    private ILogger<MainHub> _logger;

    public MainHub(ILogger<MainHub> logger)
    {
        _logger = logger;
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
}