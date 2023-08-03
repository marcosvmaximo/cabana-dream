using System;
using MVM.CabanasDream.Core.Domain.DomainEvents;

namespace MVM.CabanasDream.Locacao.Domain.Events;

public class FestaCriadaEvent : DomainEvent
{
    public Guid ClienteId { get; private set; }

    public FestaCriadaEvent(Guid aggregateId, Guid clienteId) : base(aggregateId)
    {
        ClienteId = clienteId;
    }
}