using ProjectRPS.Core.Components;

namespace ProjectRPS.Core.State;

public class GameState
{
    private List<Entity> _entities;

    public GameState()
    {
        _entities = new List<Entity>();
    }

    public void CreatePlayerEntity(string id)
    {
        var entity = new Entity();
        entity.AddComponent("Position", new PositionComponent());
        entity.AddComponent("Velocity", new VelocityComponent());
        _entities.Add(entity);
    }
}