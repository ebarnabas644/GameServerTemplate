using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace ProjectRPS.Core.Models;

public class Vector
{
    public Vector<double> Position { get; set; }
    
    public double X
    {
        get => Position[0];
        set => Position[0] = value;
    }

    public double Y
    {
        get => Position[1];
        set => Position[1] = value;
    }

    public void Add(Vector a)
    {
        Position = Position.Add(a.Position);
    }

    public double Distance(Vector a)
    {
        return MathNet.Numerics.Distance.Euclidean(Position, a.Position);
    }

    public Vector<double> DirectionFromVector(Vector a)
    {
        return Position.Subtract(a.Position);
    }

    public Vector()
    {
        Position = new DenseVector(2);
    }
}