using ProjectRPS.Core.Models;

namespace ProjectRPS.Core.Components;

public class VelocityComponent : Component
{
    public Vector Velocity;

    public VelocityComponent()
    {
        Velocity = new Vector();
    }
}