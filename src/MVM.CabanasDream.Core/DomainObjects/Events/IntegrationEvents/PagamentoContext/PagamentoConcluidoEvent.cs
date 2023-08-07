using System;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.Common;

namespace MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.PagamentoContext;

public class PagamentoConcluidoEvent : IntegrationEvent
{
    public PagamentoConcluidoEvent(Guid aggregateId) : base(aggregateId)
    {
    }
}

