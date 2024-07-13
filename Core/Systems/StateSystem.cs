using ProjectRPS.Core.Components;
using ProjectRPS.Core.State;

namespace ProjectRPS.Core.Systems;

public class StateSystem : ISystem
{
    private readonly IGameState _gameState;

    public StateSystem(IGameState gameState)
    {
        _gameState = gameState;
    }
    public void Process()
    {
        foreach (var entity in _gameState.GetGameState())
        {
            if (entity.GetComponent("Velocity") is VelocityComponent velocityComponent &&
                entity.GetComponent("State") is StateComponent stateComponent)
            {
                if (velocityComponent.Velocity.X == 0 && velocityComponent.Velocity.Y == 0)
                {
                    stateComponent.State = "Idle";
                }
                else if(velocityComponent.Velocity.X > 0)
                {
                    stateComponent.State = "RightMovement";
                }
                else if (velocityComponent.Velocity.X < 0)
                {
                    stateComponent.State = "LeftMovement";
                }
                else if (velocityComponent.Velocity.Y < 0)
                {
                    stateComponent.State = "UpMovement";
                }
                else if (velocityComponent.Velocity.Y > 0)
                {
                    stateComponent.State = "DownMovement";
                }
            }
        }
    }
}