using Microsoft.AspNetCore.SignalR;
using ProjectRPS.Core;
using ProjectRPS.Hubs;

namespace ProjectRPS;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSignalRHub(this IServiceCollection services)
    {
        services.AddSingleton<Hub, MainHub>();

        return services;
    }
    public static IServiceCollection AddGameLoop(this IServiceCollection services)
    {
        services.AddSingleton<IGameLoop, GameLoop>();

        return services;
    }
}