using System;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.Common;

namespace MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.PagamentoContext;

public class PagamentoRecusadoEvent : IntegrationEvent
{
    public PagamentoRecusadoEvent(Guid aggregateId) : base(aggregateId)
    {
    }
}

