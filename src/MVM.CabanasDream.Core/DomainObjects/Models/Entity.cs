using System;
using MVM.CabanasDream.Core.Domain.DomainEvents;
using MVM.CabanasDream.Core.Domain.DomainEvents.Common;

namespace MVM.CabanasDream.Core.Domain.Models;

public abstract class Entity
{
    private List<Event> _events;

    public Entity()
    {
        Id = Guid.NewGuid();
        DataCriacao = DateTime.Now;
        _events = new List<Event>();
    }

    public Guid Id { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public IReadOnlyCollection<Event> Events => _events;

    public abstract void Validar();

    public void AdicionarEvento(Event @event) => _events.Add(@event);

    public void AdicionarEvento(List<Event> events) => _events.AddRange(events);

    public void RemoverEvento(Event @event) => _events.Remove(@event);

    public void LimparEventos() => _events = new List<Event>();

    public override bool Equals(object? obj)
    {
        var compareToo = obj as Entity;

        if (ReferenceEquals(this, compareToo))
            return true;

        if (ReferenceEquals(null, compareToo))
            return false;

        return Id.Equals(compareToo.Id);
    }

    public static bool operator ==(Entity? a, Entity? b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }


    public static bool operator !=(Entity? a, Entity? b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return (GetType().GetHashCode() * 907) + Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"{GetType().Name} [Id={Id}]";
    }
}

