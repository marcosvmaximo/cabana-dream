using MediatR;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.ContratoContext;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.FestaContext;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.FestaContext.Enum;
using MVM.CabanasDream.Fiscal.API.Interfaces;

namespace MVM.CabanasDream.Fiscal.API.Events;

public class FestaEventHandler :
    INotificationHandler<FestaCriadaEvent>,
    INotificationHandler<FestaCanceladaEvent>,
    INotificationHandler<FestaFinalizadaEvent>
{
    private readonly IFiscalService _service;
    private readonly IContratoRepository _repository;
    private readonly IMediatorHandler _mediator;

    public FestaEventHandler(IContratoRepository repository, IMediatorHandler mediator, IFiscalService service)
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
            var dataFinalizacao = DateTime.Now;
            var evento = new FalhouAnaliseClienteEvent(message.AggregrateId,
                                                       message.ClienteId,
                                                       dataFinalizacao,
                                                       EMotivoCancelamento.Analise);

            await _mediator.PublicarEvento(evento);
            return;
        }

        await _service.CriarContrato(message.AggregrateId, message.ClienteId, message.DataDevolucao);
    }

    public async Task Handle(FestaFinalizadaEvent message, CancellationToken cancellationToken)
    {
        // Validações para ver se é possivel finalizar o contrato.

        await _service.FinalizarContrato();
    }

    public async Task Handle(FestaCanceladaEvent message, CancellationToken cancellationToken)
    {
        // Validações para ver se é possível cancelar o contrato
        await _service.QuebrarContrato();
    }
}

