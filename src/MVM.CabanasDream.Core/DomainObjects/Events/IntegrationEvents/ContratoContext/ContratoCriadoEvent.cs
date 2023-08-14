using System;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.Common;

namespace MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.ContratoContext;

public class ContratoCriadoEvent : IntegrationEvent
{
    public Guid FestaId { get; private set; }

    public ContratoCriadoEvent(Guid contratoId, Guid festaId) : base(contratoId)
    {
        FestaId = festaId;
    }
}

