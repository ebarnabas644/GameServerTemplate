using ProjectRPS.Core.Components;
using ProjectRPS.Core.State;
using MathNet.Numerics.LinearAlgebra;

namespace ProjectRPS.Core.Systems;

public class EnemySystem : ISystem
{
    private readonly IGameState _gameState;
    
    public EnemySystem(IGameState gameState)
    {
        _gameState = gameState;
    }
    
    public void Process()
    {
        var gameState = _gameState.GetGameState();
        var mobs = gameState.Where(x => x.HasTag("mob"));
        var players = gameState.Where(x => x.HasTag("player"));
        foreach (var mob in mobs)
        {
            if (mob.GetComponent("Position") is PositionComponent mobPositionComponent &&
                mob.GetComponent("Velocity") is VelocityComponent mobVelocityComponent)
            {
                var closestPlayerPositionComponent = players
                    .Select(x => x.GetComponent("Position") as PositionComponent)
                    .Where(x => x != null).MinBy(x => x?.Vector.Distance(mobPositionComponent.Vector));
                if (closestPlayerPositionComponent != null)
                {
                    var vector = closestPlayerPositionComponent.Vector.DirectionFromVector(mobPositionComponent.Vector);
                    vector = vector.Normalize(2);
                    mobVelocityComponent.Velocity.X = vector[0];
                    mobVelocityComponent.Velocity.Y = vector[1];
                }
            }
            
        }
    }
}