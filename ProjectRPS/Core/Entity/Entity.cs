using ProjectRPS.Core.Components;

namespace ProjectRPS.Core;

public class Entity
{
    public Guid Id { get; }
    public string? ConnectionId { get; set; }
    private readonly Dictionary<string, Component> _components;
    private readonly HashSet<string> _tags;

    public Entity()
    {
        Id = Guid.NewGuid();
        _components = new Dictionary<string, Component>();
        _tags = new HashSet<string>();
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

    public void AddTag(string tag)
    {
        _tags.Add(tag);
    }

    public bool HasTag(string tag)
    {
        return _tags.Contains(tag);
    }
}