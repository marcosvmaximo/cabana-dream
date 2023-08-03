using System;
using MVM.CabanasDream.Core.Domain.DomainEvents;

namespace MVM.CabanasDream.Locacao.Domain.Events;

public class TemaIndisponivelEvent : DomainEvent
{
    public int QuantidadeEstoqueDisponivel { get; private set; }
    public Guid TemaId { get; private set; }

    public TemaIndisponivelEvent(Guid aggregateId, Guid temaId, int quantidade) : base(aggregateId)
    {
        QuantidadeEstoqueDisponivel = quantidade;
        TemaId = temaId;
    }
}

