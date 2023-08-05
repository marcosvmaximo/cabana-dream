using System;
using MVM.CabanasDream.Core.Domain.DomainEvents;

namespace MVM.CabanasDream.Fiscal.Application.Commands;

public class CriarContratoCommand : Command
{
    public Guid FestaId { get; set; }
    public Guid ClienteId { get; set; }
    public DateTime DataDevolucao { get; set; }

    public CriarContratoCommand()
    {
    }

    public CriarContratoCommand(Guid festaId, Guid clienteId, DateTime dataDevolucao)
    {
        FestaId = festaId;
        ClienteId = clienteId;
        DataDevolucao = dataDevolucao;
    }
}

