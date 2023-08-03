using System;
using MVM.CabanasDream.Core.Domain.DomainEvents;
using MVM.CabanasDream.Core.Domain.DomainEvents.Common;

namespace MVM.CabanasDream.Locacao.Application.Events;

public class EnviarEmailEvent : DomainEvent
{
    public bool SucessoAnalise { get; private set; }

    public EnviarEmailEvent(Guid aggregateId, bool sucessoAnalise) : base(aggregateId)
    {
        SucessoAnalise = sucessoAnalise;
    }
}

