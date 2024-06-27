using ProjectRPS.Core.Components;

namespace ProjectRPS.Core.State;

public interface IGameState
{
    void CreatePlayerEntity(string? connectionId);
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

    public void CreatePlayerEntity(string? connectionId)
    {
        var entity = new Entity();
        var positionComponent = new PositionComponent();
        var random = new Random();
        positionComponent.Vector.X = random.Next() % 500;
        positionComponent.Vector.Y = random.Next() % 500;
        entity.AddComponent("Position", positionComponent);
        entity.AddComponent("Velocity", new VelocityComponent());
        
        if (connectionId != null)
        {
            entity.ConnectionId = connectionId;
        }
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