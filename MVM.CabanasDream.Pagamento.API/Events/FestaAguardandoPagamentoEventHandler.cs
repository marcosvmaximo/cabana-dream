using System;
using MediatR;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.FestaContext;
using MVM.CabanasDream.Pagamento.API.Models;

namespace MVM.CabanasDream.Pagamento.API.Events;

public class FestaAguardandoPagamentoEventHandler : INotificationHandler<FestaAguardandoPagamentoEvent>
{
    public FestaAguardandoPagamentoEventHandler()
    {
    }

    public async Task Handle(FestaAguardandoPagamentoEvent message, CancellationToken cancellationToken)
    {
        var pagamento = new Transacao();
    }
}

