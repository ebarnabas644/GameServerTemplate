using ProjectRPS.Core.Components;
using ProjectRPS.Core.Models;

namespace ProjectRPS.Core.DTOs;

public class EntityDTO
{
    public Vector Position { get; set; }

    public EntityDTO(Entity entity)
    {
        var position = entity.GetComponent("Position") as PositionComponent;
        this.Position = position.Vector;
    }
}