using System;
using MediatR;

namespace MVM.CabanasDream.Locacao.Application.Events.Handlers;

public class EnviarEmailEventHandler : INotificationHandler<EnviarEmailEvent>
{
    public EnviarEmailEventHandler()
    {
    }

    public Task Handle(EnviarEmailEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

