using ProjectRPS.Core.Components;

namespace ProjectRPS.Core;

public class Entity
{
    private readonly Dictionary<string, Component> _components;

    public Entity()
    {
        _components = new Dictionary<string, Component>();
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