using Microsoft.AspNetCore.SignalR;

namespace ProjectRPS.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("message", message);
    }

    public override async Task OnConnectedAsync()
    {
        var id = Context.ConnectionId;
        await Clients.Client(Context.ConnectionId).SendAsync("initial", "Hello there");
    }
}