using ProjectRPS.Core;

namespace ProjectRPS;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGameLoop(this IServiceCollection services)
    {
        services.AddSingleton<IGameLoop, GameLoop>();

        return services;
    }
}