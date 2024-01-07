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
    
    private readonly DenseVector _position = new(new double[] { 0, 0 });
}