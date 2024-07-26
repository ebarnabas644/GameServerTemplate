using ProjectRPS.Core.Components;

namespace ProjectRPS.Core.Builders;

public interface IEntityBuilder
{
    Entity BuildPlayer(string? connectionId);
    Entity BuildMob();
}

public class EntityBuilder : IEntityBuilder
{
    public Entity BuildPlayer(string? connectionId)
    {
        var entity = new Entity();
        var positionComponent = new PositionComponent();
        var random = new Random();
        positionComponent.Vector.X = random.Next() % 500;
        positionComponent.Vector.Y = random.Next() % 500;
        entity.AddComponent("Position", positionComponent);
        entity.AddComponent("Velocity", new VelocityComponent());
        entity.AddComponent("State", new StateComponent { State = "Idle" });
        entity.AddComponent("Sprite", new SpriteComponent { Sprite = "player.png" });
        
        if (connectionId != null)
        {
            entity.ConnectionId = connectionId;
        }

        return entity;
    }

    public Entity BuildMob()
    {
        var entity = new Entity();
        var positionComponent = new PositionComponent();
        var random = new Random();
        positionComponent.Vector.X = 200 + random.Next() % 500;
        positionComponent.Vector.Y = 200 + random.Next() % 500;
        entity.AddComponent("Position", positionComponent);
        entity.AddComponent("Velocity", new VelocityComponent());
        entity.AddComponent("State", new StateComponent { State = "Idle" });
        entity.AddComponent("Sprite", new SpriteComponent { Sprite = "slime.png" });

        return entity;
    }
}