using System;
using MediatR;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.ContratoContext;

namespace MVM.CabanasDream.Locacao.Application.Events.Handlers;

public class FalhouAnaliseClienteEventHandler : INotificationHandler<FalhouAnaliseClienteEvent>
{
    public FalhouAnaliseClienteEventHandler()
    {
    }

    public Task Handle(FalhouAnaliseClienteEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

