using System;
using MediatR;
using MVM.CabanasDream.Locacao.Domain.Events;
using MVM.CabanasDream.Locacao.Domain.Events.Festas;

namespace MVM.CabanasDream.Locacao.Application.Events.Handlers;

public class AtualizarFestaEventHandler : INotificationHandler<AtualizarFestaEvent>
{
    public AtualizarFestaEventHandler()
    {
    }

    public Task Handle(AtualizarFestaEvent message, CancellationToken cancellationToken)
    {
        // Atualiza bases de leituras
        throw new NotImplementedException();
    }
}

