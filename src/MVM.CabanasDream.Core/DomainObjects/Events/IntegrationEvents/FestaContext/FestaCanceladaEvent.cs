using System;
using MVM.CabanasDream.Core.Domain.DomainEvents;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.Common;

namespace MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.FestaContext;

public class FestaCanceladaEvent : IntegrationEvent
{
    public FestaCanceladaEvent(Guid aggregateId, Guid? contratoId, DateTime dataFinalizacao, string motivo) : base(aggregateId)
    {
        ContratoId = contratoId;
        DataFinalizacao = dataFinalizacao;
        Motivo = motivo;
    }

    public Guid? ContratoId { get; private set; }
    public DateTime DataFinalizacao { get; private set; }
    public string Motivo { get; private set; }
}

