using System.Text.Json;
using Microsoft.AspNetCore.SignalR;
using ProjectRPS.Hubs.Models;

namespace ProjectRPS.Hubs.MessageProcessors;

public class ChatProcessor : IMessageProcessor
{
    private IMessageSender _messageSender;

    public ChatProcessor(IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }

    public async Task Process(string data)
    {
        try
        {
            var message = data;
            Console.WriteLine($"Chat message: {message}");
            await _messageSender.SendMessage("message", data);
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