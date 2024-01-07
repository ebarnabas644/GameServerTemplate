using Microsoft.AspNetCore.SignalR;

namespace ProjectRPS.Hubs;

public partial class MainHub : Hub
{
    /*public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("message", message);
    }*/
}