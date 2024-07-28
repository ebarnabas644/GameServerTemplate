using Microsoft.AspNetCore.SignalR;
using ProjectRPS.Core;
using ProjectRPS.Core.Builders;
using ProjectRPS.Core.State;
using ProjectRPS.Core.Systems;
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

    public static IServiceCollection AddGameState(this IServiceCollection services)
    {
        services.AddSingleton<IGameState, GameState>();

        return services;
    }

    public static IServiceCollection AddGameSystems(this IServiceCollection services)
    {
        services.AddSingleton<ISystem, VelocitySystem>();
        services.AddSingleton<ISystem, StateSystem>();
        services.AddSingleton<ISystem, SpawnerSystem>();
        services.AddSingleton<ISystem, EnemySystem>();

        return services;
    }

    public static IServiceCollection AddEntityBuilder(this IServiceCollection services)
    {
        services.AddSingleton<IEntityBuilder, EntityBuilder>();

        return services;
    }
}