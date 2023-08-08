using System;
using MediatR;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.PagamentoContext;

namespace MVM.CabanasDream.Locacao.Application.Events.Handlers;

public class PagamentoEventHandler :
    INotificationHandler<PagamentoConcluidoEvent>,
    INotificationHandler<PagamentoFalhadoEvent>
{
    public PagamentoEventHandler()
    {
    }

    public Task Handle(PagamentoFalhadoEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Handle(PagamentoConcluidoEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

