using System;
using MVM.CabanasDream.Core.Domain.DomainEvents;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.FestaContext.Enum;

namespace MVM.CabanasDream.Locacao.Application.Commands;

public class CancelarFestaCommand : Command
{
    public CancelarFestaCommand()
    {
    }

    public CancelarFestaCommand(Guid festaId, DateTime dataFinalizacao, EMotivoCancelamento motivo)
    {
        FestaId = festaId;
        DataFinalizacao = dataFinalizacao;
        Motivo = motivo;
    }

    public Guid FestaId { get; set; }
    public DateTime DataFinalizacao { get; set; }
    public EMotivoCancelamento Motivo { get; set; }
}

