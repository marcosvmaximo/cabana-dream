using System;
using MVM.CabanasDream.Core.Domain.DomainEvents;

namespace MVM.CabanasDream.Locacao.Application.Commands;

public class CancelarFestaCommand : Command
{
    public CancelarFestaCommand()
    {
    }

    public CancelarFestaCommand(Guid festaId, DateTime dataFinalizacao, string motivo)
    {
        FestaId = festaId;
        DataFinalizacao = dataFinalizacao;
        Motivo = motivo;
    }

    public Guid FestaId { get; set; }
    public DateTime DataFinalizacao { get; set; }
    public string Motivo { get; set; }
}

