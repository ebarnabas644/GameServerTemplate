using ProjectRPS.Core.Builders;
using ProjectRPS.Core.State;

namespace ProjectRPS.Core.Systems;

public class SpawnerSystem : ISystem
{
    private IGameState _gameState;
    private IEntityBuilder _entityBuilder;
    private int _tick = 0;

    public SpawnerSystem(IGameState gameState, IEntityBuilder entityBuilder)
    {
        _gameState = gameState;
        _entityBuilder = entityBuilder;
    }
    public void Process()
    {
        if (_tick++ % 600 == 0)
        {
            var entity = _entityBuilder.BuildMob();
            _gameState.AddEntity(entity);
        }
    }
}