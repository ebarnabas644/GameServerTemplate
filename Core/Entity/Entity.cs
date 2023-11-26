using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using ProjectRPS.Core.Components;

namespace ProjectRPS.Core;

public class Entity
{
    public Vector<double> Position;
    private readonly Dictionary<string, Component> _components;

    public Entity()
    {
        _components = new Dictionary<string, Component>();
        Position = new DenseVector(new double[] { 2, 0 });
    }

    public void AddComponent(string name, Component component)
    {
        component.Attach(this);
        _components[name] = component;
    }

    public void RemoveComponent(string name)
    {
        _components.Remove(name);
    }

    public Component GetComponent(string name)
    {
        return _components[name];
    }
}