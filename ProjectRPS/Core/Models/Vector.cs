using MathNet.Numerics.LinearAlgebra.Double;

namespace ProjectRPS.Core.Models;

public class Vector
{
    public double X
    {
        get => _position[0];
        set => _position[0] = value;
    }

    public double Y
    {
        get => _position[1];
        set => _position[1] = value;
    }

    public void Add(Vector a)
    {
        _position = (DenseVector)_position.Add(a._position);
    }

    public Vector()
    {
        var a = new DenseVector(new double[] { 1, 2 });
    }
    
    private DenseVector _position = new(new double[] { 0, 0 });
}