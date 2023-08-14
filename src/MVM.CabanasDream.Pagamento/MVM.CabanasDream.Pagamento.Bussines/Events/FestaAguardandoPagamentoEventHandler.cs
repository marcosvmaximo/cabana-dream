using System;
using MediatR;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.FestaContext;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.PagamentoContext;
using MVM.CabanasDream.Pagamento.API.Models;

namespace MVM.CabanasDream.Pagamento.API.Events;

public class FestaAguardandoPagamentoEventHandler : INotificationHandler<FestaAguardandoPagamentoEvent>
{
    private readonly IMediatorHandler _mediator;

    public FestaAguardandoPagamentoEventHandler(IMediatorHandler mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(FestaAguardandoPagamentoEvent message, CancellationToken cancellationToken)
    {
        await _mediator.PublicarEvento(new PagamentoRealizadoEvent(Guid.Empty));
        await _mediator.PublicarEvento(new PagamentoRecusadoEvent(Guid.Empty));

    }
}

