using System.Text.Json;
using Microsoft.AspNetCore.SignalR;
using ProjectRPS.Hubs.Models;

namespace ProjectRPS.Hubs.MessageProcessors;

public class ChatProcessor : IMessageProcessor
{
    private IMessageSender _messageSender;
    private readonly ILogger<ChatProcessor> _logger;

    public ChatProcessor(ILogger<ChatProcessor> logger, IMessageSender messageSender)
    {
        _messageSender = messageSender;
        _logger = logger;
    }

    public async Task Process(string data, string connectionId)
    {
        try
        {
            var message = data;
            Console.WriteLine($"Chat message: {message}");
            await _messageSender.SendMessage("message", data);
        }
        catch(Exception ex)
        {
            _logger.LogError($"Error occured during chat message processing: {ex.Message}");
        }
    }

    public bool IsTypeOf(string type)
    {
        return type == "chat";
    }
}