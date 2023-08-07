using MediatR;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.ContratoContext;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.FestaContext;
using MVM.CabanasDream.Fiscal.API.Services.Interfaces;

namespace MVM.CabanasDream.Fiscal.API.Events.Handlers;

public class FestaCriadaEventHandler : INotificationHandler<FestaCriadaEvent>
{
    private readonly IContratoService _service;
    private readonly IContratoRepository _repository;
    private readonly IMediatrHandler _mediator;

    public FestaCriadaEventHandler(IContratoRepository repository, IMediatrHandler mediator, IContratoService service)
    {
        _service = service;
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

        await _service.CriarContrato(message.FestaId, message.ClienteId, message.DataDevolucao);
    }
}

