using ProjectRPS.Core.State;

namespace ProjectRPS.Core.Systems;

public class SpawnerSystem : ISystem
{
    private IGameState _gameState;
    private int _tick = 0;

    public SpawnerSystem(IGameState gameState)
    {
        _gameState = gameState;
    }
    public void Process()
    {
        if (_tick++ % 600 == 0)
        {
            _gameState.CreateMobEntity();
        }
    }
}