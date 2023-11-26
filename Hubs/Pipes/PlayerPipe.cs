using Microsoft.AspNetCore.SignalR;

namespace ProjectRPS.Hubs;

public partial class MainHub : Hub
{
    public async Task SendPlayerState(string message)
    {
        await Clients.All.SendAsync("message", message);
    }
}