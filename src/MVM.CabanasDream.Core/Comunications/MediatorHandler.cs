using MediatR;
using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Core.Domain.DomainEvents.Common;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Core.Domain.Models;

namespace MVM.CabanasDream.Core.Domain.DomainEvents.Handlers;

public class MediatorHandler : IMediatorHandler
{
    private readonly IMediator _mediator;

    public MediatorHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<BaseResult> EnviarComando<TRequest>(TRequest command) where TRequest : Command
    {
        return await _mediator.Send(command);
    }

    public async Task PublicarEvento<T>(T evento) where T : Event
    {
        await _mediator.Publish(evento);
    }

    public async Task PublicarNotificacao<T>(T notification) where T : DomainNotification
    {
        await _mediator.Publish(notification);
    }
}

