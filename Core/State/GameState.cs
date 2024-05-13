using ProjectRPS.Core.Components;

namespace ProjectRPS.Core.State;

public interface IGameState
{
    void CreatePlayerEntity(string id);
    List<Entity> GetGameState();
}

public class GameState : IGameState
{
    private List<Entity> _entities;

    public GameState()
    {
        _entities = new List<Entity>();
        CreatePlayerEntity("test");
    }

    public void CreatePlayerEntity(string id)
    {
        var entity = new Entity();
        entity.AddComponent("Position", new PositionComponent());
        entity.AddComponent("Velocity", new VelocityComponent());
        _entities.Add(entity);
    }

    public List<Entity> GetGameState()
    {
        return _entities;
    }
}