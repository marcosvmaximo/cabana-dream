using System;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.Common;

namespace MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.FestaContext;

public class FestaFinalizadaEvent : IntegrationEvent
{
    public FestaFinalizadaEvent(Guid aggregateId, DateTime dataFinalizacao) : base(aggregateId)
    {
        DataFinalizacao = dataFinalizacao;
    }

    public DateTime DataFinalizacao;
}

