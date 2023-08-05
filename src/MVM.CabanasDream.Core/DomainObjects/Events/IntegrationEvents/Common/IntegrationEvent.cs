using System;
using MVM.CabanasDream.Core.Domain.DomainEvents;
using MVM.CabanasDream.Core.Domain.DomainEvents.Common;

namespace MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.Common;

public abstract class IntegrationEvent : DomainEvent
{
    public IntegrationEvent(Guid aggregateId) : base(aggregateId)
    {
    }
}

