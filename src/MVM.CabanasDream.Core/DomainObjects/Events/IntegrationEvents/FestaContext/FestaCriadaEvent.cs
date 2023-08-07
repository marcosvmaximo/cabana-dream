using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.Common;

namespace MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.FestaContext;

public class FestaCriadaEvent : IntegrationEvent
{
    public FestaCriadaEvent(Guid aggregateId, Guid clienteId, DateTime dataDevolucao) : base(aggregateId)
    {
        FestaId = aggregateId;
        ClienteId = clienteId;
        DataDevolucao = dataDevolucao;
    }

    public Guid ClienteId { get; set; }
    public Guid FestaId { get; set; }
    public DateTime DataDevolucao { get; set; }
}

