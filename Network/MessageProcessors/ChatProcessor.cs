using System.Text.Json;
using Microsoft.AspNetCore.SignalR;
using ProjectRPS.Hubs.Models;

namespace ProjectRPS.Hubs.MessageProcessors;

public class ChatProcessor : IMessageProcessor
{
    private IHubContext<MainHub> _messageHub;

    public ChatProcessor(IHubContext<MainHub> messageHub)
    {
        _messageHub = messageHub;
    }

    public async Task Process(string data)
    {
        try
        {
            var message = data;
            Console.WriteLine($"Chat message: {message}");
            await _messageHub.Clients.All.SendAsync("message", data);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public bool IsTypeOf(string type)
    {
        return type == "chat";
    }
}