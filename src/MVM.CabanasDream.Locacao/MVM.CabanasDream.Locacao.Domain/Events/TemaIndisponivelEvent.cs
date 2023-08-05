using System;
using MVM.CabanasDream.Core.Domain.DomainEvents;

namespace MVM.CabanasDream.Locacao.Domain.Events;

public class TemaIndisponivelEvent : DomainEvent
{
    public TemaIndisponivelEvent(Guid aggregateId, Guid temaId, int quantidadeEstoque) : base(aggregateId)
    {
        TemaId = temaId;
        QuantidadeEstoque = quantidadeEstoque;
    }

    public Guid TemaId { get; private set; }
    public int QuantidadeEstoque { get; private set; }
}

