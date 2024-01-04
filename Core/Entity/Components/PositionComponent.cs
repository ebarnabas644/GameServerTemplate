using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using ProjectRPS.Core.Models;

namespace ProjectRPS.Core.Components;

public class PositionComponent : Component
{
    public Position Position;

    public PositionComponent()
    {
        Position = new Position();
    }
}