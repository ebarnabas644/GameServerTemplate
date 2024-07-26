using ProjectRPS.Core.Components;

namespace ProjectRPS.Core.State;

public interface IGameState
{
    void AddEntity(Entity entity);
    void DeletePlayerEntity(string connectionId);
    List<Entity> GetGameState();
}

public class GameState : IGameState
{
    private List<Entity> _entities;

    public GameState()
    {
        _entities = new List<Entity>();
    }

    public void AddEntity(Entity entity)
    {
        _entities.Add(entity);
    }

    public void DeletePlayerEntity(string connectionId)
    {
        var entityToRemove = _entities.FirstOrDefault(x => x.ConnectionId == connectionId);
        if (entityToRemove != null)
        {
            _entities.Remove(entityToRemove);
        }
    }

    public List<Entity> GetGameState()
    {
        return _entities;
    }
}