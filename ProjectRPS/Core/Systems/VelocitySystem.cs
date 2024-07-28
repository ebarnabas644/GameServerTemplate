using ProjectRPS.Core.Components;
using ProjectRPS.Core.State;

namespace ProjectRPS.Core.Systems;

public class VelocitySystem : ISystem
{
    private readonly IGameState _gameState;
    
    public VelocitySystem(IGameState gameState)
    {
        _gameState = gameState;
    }
    public void Process()
    {
        foreach (var entity in _gameState.GetGameState())
        {
            if (entity.GetComponent("Velocity") is VelocityComponent velocityComponent &&
                entity.GetComponent("Position") is PositionComponent positionComponent)
            {
                positionComponent.Vector.Add(velocityComponent.Velocity);
            }
        }
    }
}