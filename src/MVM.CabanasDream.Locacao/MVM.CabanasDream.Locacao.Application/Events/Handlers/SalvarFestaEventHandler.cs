using System;
using MediatR;

namespace MVM.CabanasDream.Locacao.Application.Events.Handlers;

public class SalvarFestaEventHandler : INotificationHandler<SalvarFestaEvent>
{
    public SalvarFestaEventHandler()
    {
    }

    public Task Handle(SalvarFestaEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

