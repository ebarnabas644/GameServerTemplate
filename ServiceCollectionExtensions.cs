using Microsoft.AspNetCore.SignalR;
using ProjectRPS.Core;
using ProjectRPS.Hubs;
using ProjectRPS.Hubs.MessageProcessors;

namespace ProjectRPS;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSignalRHub(this IServiceCollection services)
    {
        services.AddSingleton<Hub, MainHub>();

        return services;
    }

    public static IServiceCollection AddMessageSender(this IServiceCollection services)
    {
        services.AddSingleton<IMessageSender, MessageSender>();

        return services;
    }
    
    public static IServiceCollection AddGameLoop(this IServiceCollection services)
    {
        services.AddSingleton<IGameLoop, GameLoop>();

        return services;
    }

    public static IServiceCollection AddMessageProcessors(this IServiceCollection services)
    {
        services.AddTransient<IMessageProcessor, InputProcessor>();
        services.AddTransient<IMessageProcessor, ChatProcessor>();

        return services;
    }
}