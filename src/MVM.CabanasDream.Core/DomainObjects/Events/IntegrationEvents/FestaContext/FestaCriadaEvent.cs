using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.Common;

namespace MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.FestaContext;

public class FestaCriadaEvent : IntegrationEvent
{
    public FestaCriadaEvent(Guid festaId, Guid clienteId, DateTime dataDevolucao) : base(festaId)
    {
        ClienteId = clienteId;
        DataDevolucao = dataDevolucao;
    }

    public Guid ClienteId { get; private set; }
    public DateTime DataDevolucao { get; private set; }
}

