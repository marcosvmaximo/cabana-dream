using System;
using MVM.CabanasDream.Core.Domain.DomainEvents;

namespace MVM.CabanasDream.Locacao.Application.Commands;

public class CriarContratoCommand : Command
{
    public Guid FestaId { get; set; }
    public Guid ClienteId { get; set; }

    public CriarContratoCommand()
    {
    }

    public CriarContratoCommand(Guid festaId, Guid clienteId)
    {
        FestaId = festaId;
        ClienteId = clienteId;
    }
}

