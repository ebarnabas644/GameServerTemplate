namespace ProjectRPS.Core.Components;

public abstract class Component
{
    protected Entity _entity;
    
    public void Attach(Entity entity)
    {
        _entity = entity;
    }

    public void Detach(Entity entity)
    {
        _entity = null;
    }
}