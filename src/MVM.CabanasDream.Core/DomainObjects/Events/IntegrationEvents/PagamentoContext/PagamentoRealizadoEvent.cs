using System;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.Common;

namespace MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.PagamentoContext;

public class PagamentoRealizadoEvent : IntegrationEvent
{
    public PagamentoRealizadoEvent(Guid aggregateId) : base(aggregateId)
    {
    }
}

