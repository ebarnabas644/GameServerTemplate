using ProjectRPS.Core.Components;
using ProjectRPS.Core.Models;

namespace ProjectRPS.Core.DTOs;

public class EntityDTO
{
    public Guid Id { get; set; }
    public Vector Position { get; set; }

    public EntityDTO(Entity entity)
    {
        Id = entity.Id;
        var position = entity.GetComponent("Position") as PositionComponent;
        Position = position.Vector;
    }
}