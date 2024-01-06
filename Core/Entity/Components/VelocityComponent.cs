using ProjectRPS.Core.Models;

namespace ProjectRPS.Core.Components;

public class VelocityComponent
{
    public Position Velocity;

    public VelocityComponent()
    {
        Velocity = new Position();
    }
}