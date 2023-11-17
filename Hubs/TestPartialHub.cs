using Microsoft.AspNetCore.SignalR;

namespace ProjectRPS.Hubs;

public partial class ChatHub
{
    public async Task SendStateMessage(string message)
    {
        await Clients.All.SendAsync("messageState", message);
    }
}