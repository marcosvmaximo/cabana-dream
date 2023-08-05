using System;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.Common;

namespace MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.ContratoContext;

public class FalhouAnaliseClienteEvent : IntegrationEvent
{
    public Guid ClienteId { get; set; }

    public FalhouAnaliseClienteEvent(Guid aggregateId, Guid clienteId) : base(aggregateId)
    {
        ClienteId = clienteId;
    }
}

