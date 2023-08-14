using System;
using MediatR;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.FestaContext;

namespace MVM.CabanasDream.Estoque.API.Events;

public class FestaCriadaEventHandler : INotificationHandler<FestaCriadaEvent>
{
    public FestaCriadaEventHandler()
    {
    }

    public Task Handle(FestaCriadaEvent message, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

