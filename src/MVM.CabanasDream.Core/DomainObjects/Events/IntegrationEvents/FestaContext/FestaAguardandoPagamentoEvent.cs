using System;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.Common;

namespace MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.FestaContext;

public class FestaAguardandoPagamentoEvent : IntegrationEvent
{
    public FestaAguardandoPagamentoEvent(Guid festaId) : base(festaId)
    {
    }
}

