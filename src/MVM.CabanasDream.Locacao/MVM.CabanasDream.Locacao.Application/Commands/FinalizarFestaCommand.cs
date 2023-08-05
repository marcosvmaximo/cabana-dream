using System;
using MVM.CabanasDream.Core.Domain.DomainEvents;

namespace MVM.CabanasDream.Locacao.Application.Commands;

public class FinalizarFestaCommand : Command
{
    public FinalizarFestaCommand()
    {
    }

    public FinalizarFestaCommand(Guid festaId, DateTime dataFinalizacao)
    {
        FestaId = festaId;
        DataFinalizacao = dataFinalizacao;
    }

    public Guid FestaId { get; set; }
    public DateTime DataFinalizacao { get; set; }

    public override bool EhValido()
    {
        return base.EhValido();
    }
}

