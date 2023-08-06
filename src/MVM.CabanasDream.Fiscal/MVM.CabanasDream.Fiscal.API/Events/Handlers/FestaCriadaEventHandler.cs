using MediatR;
using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.ContratoContext;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.FestaContext;
using MVM.CabanasDream.Fiscal.Application.Commands;
using MVM.CabanasDream.Fiscal.Domain.Interfaces;

namespace MVM.CabanasDream.Fiscal.Application.Events.Handlers;

public class FestaCriadaEventHandler : INotificationHandler<FestaCriadaEvent>
{
    private readonly IContratoRepository _repository;
    private readonly IMediatrHandler _mediator;

    public FestaCriadaEventHandler(IContratoRepository repository, IMediatrHandler mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task Handle(FestaCriadaEvent message, CancellationToken cancellationToken)
    {
        var festasCanceladas = await _repository.ObterFestasCanceladasPorCliente(message.ClienteId);

        if (festasCanceladas.Any() && festasCanceladas.Count() >= 5)
        {
            // Enviar Evento que falhou de volta
            await _mediator.PublicarEvento(new FalhouAnaliseClienteEvent(message.ClienteId));

            return;
        }

        var command = new CriarContratoCommand(message.FestaId, message.ClienteId, message.DataDevolucao);
        await _mediator.EnviarComando(command);
    }
}

