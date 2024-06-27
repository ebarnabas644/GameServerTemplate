using ProjectRPS.Core.Components;

namespace ProjectRPS.Core;

public class Entity
{
    public Guid Id { get; }
    public string? ConnectionId { get; set; }
    private readonly Dictionary<string, Component> _components;

    public Entity()
    {
        Id = Guid.NewGuid();
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