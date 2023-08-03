using MediatR;
using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Locacao.Application.Commands;
using MVM.CabanasDream.Locacao.Application.Events;
using MVM.CabanasDream.Locacao.Domain.Events;
using MVM.CabanasDream.Locacao.Domain.Repositories;

namespace MVM.CabanasDream.Locacao.Application.DomainHandlers.Handlers;

public class FestaCriadaEventHandler : INotificationHandler<FestaCriadaEvent>
{
    private readonly IFestaRepository _repository;
    private readonly IMediatrHandler _bus;

    public FestaCriadaEventHandler(IFestaRepository repository, IMediatrHandler bus)
    {
        _repository = repository;
        _bus = bus;
    }

    public async Task Handle(FestaCriadaEvent evento, CancellationToken cancellationToken)
    {
        var cliente = await _repository.ObterClientePorId(evento.ClienteId);

        if (cliente == null)
            throw new DomainException("Cliente informado inválido.");

        var festasCanceladas = cliente.ObterFestasCanceladas();
        if (festasCanceladas.Any() && festasCanceladas.Count() >= 5)
        {
            await _bus.PublicarNotificacao(new DomainNotification("Cliente", "Cliente falhou na analise e não pode mais realizar novas festas."));
            await _bus.PublicarEvento(new EnviarEmailEvent(evento.AggregrateId, false));

            return;
        }

        await _bus.EnviarComando(new CriarContratoCommand(evento.AggregrateId, evento.ClienteId));
    }
}

