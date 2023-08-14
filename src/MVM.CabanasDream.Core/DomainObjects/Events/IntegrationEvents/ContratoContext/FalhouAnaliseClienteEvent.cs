using System;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.Common;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.FestaContext.Enum;

namespace MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.ContratoContext;

public class FalhouAnaliseClienteEvent : IntegrationEvent
{
    public Guid ClienteId { get; private set; }
    public DateTime DataFinalizacao { get; private set; }
    public EMotivoCancelamento Motivo { get; private set; }

    public FalhouAnaliseClienteEvent(Guid festaId, Guid clienteId, DateTime dataFinalizacao, EMotivoCancelamento motivo) : base(festaId)
    {
        ClienteId = clienteId;
        DataFinalizacao = dataFinalizacao;
        Motivo = motivo;
    }
}

