using ProjectRPS.Core.State;

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
            
        }
    }
}