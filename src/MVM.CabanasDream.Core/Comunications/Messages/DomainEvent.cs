using MVM.CabanasDream.Core.Domain.DomainEvents.Common;

namespace MVM.CabanasDream.Core.Domain.DomainEvents;

public class DomainEvent : Event
{
    public DomainEvent(Guid aggregateId)
    {
        AggregrateId = aggregateId;
    }
}

