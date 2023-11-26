using Microsoft.AspNetCore.SignalR;

namespace ProjectRPS.Hubs;

public partial class MainHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        var id = Context.ConnectionId;
        await Clients.Client(Context.ConnectionId).SendAsync("initial", "Hello there");
    }
}