using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using ProjectRPS.Core.Models;
using Vector = ProjectRPS.Core.Models.Vector;

namespace ProjectRPS.Core.Components;

public class PositionComponent : Component
{
    public Vector Vector;

    public PositionComponent()
    {
        Vector = new Vector();
    }
}