using System;
using MVM.CabanasDream.Core.Domain.DomainEvents.Common;

namespace MVM.CabanasDream.Locacao.Domain.Events.Festas;

public class AtualizarFestaEvent : Event
{
    public Guid FestaId { get; private set; }

    public AtualizarFestaEvent(Guid festaId)
    {
        FestaId = festaId;
    }
}

