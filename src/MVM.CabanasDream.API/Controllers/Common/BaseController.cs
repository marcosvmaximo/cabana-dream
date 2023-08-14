using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVM.CabanasDream.Core.Comunications;
using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Core.Domain.DomainEvents;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Core.Domain.Models;

namespace MVM.CabanasDream.API.Controllers.Common;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected readonly IMediatorHandler _mediator;
    protected readonly DomainNotificationHandler _notificationHandler;
    protected readonly IMapper _mapper;

    public BaseController(IMediatorHandler mediator,
                          INotificationHandler<DomainNotification> notificationHandler,
                          IMapper mapper)
    {
        _mapper = mapper;
        _mediator = mediator;
        _notificationHandler = (DomainNotificationHandler)notificationHandler;
    }


    protected internal bool OperacaoValida()
    {
        return !_notificationHandler.PossuiNotificacoes();
    }

    protected internal void NotificarErro(string codigo, string message)
    {
        _mediator.PublicarNotificacao(new DomainNotification(codigo, message));
    }

    protected internal async Task<BaseResult> EnviarComando<TRequest, TCommand>(TRequest request)
        where TRequest : class
        where TCommand : Command
    {
        var command = _mapper.Map<TCommand>(request)
            ?? throw new InvalidCastException("Erro ao converter a requisição para um comando", 500);

        var result = await _mediator.EnviarComando(command);

        if (_notificationHandler.PossuiNotificacoes())
        {
            var notifications = _notificationHandler.ObterNotificacoes().Select(x => new
            { x.MessageType, x.Key, x.Value });

            result.Result = notifications;
        }

        return result;
    }
}

