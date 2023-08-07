using System;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.Common;

namespace MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.PagamentoContext;

public class PagamentoFalhadoEvent : IntegrationEvent
{
    public PagamentoFalhadoEvent(Guid aggregateId) : base(aggregateId)
    {
    }
}

