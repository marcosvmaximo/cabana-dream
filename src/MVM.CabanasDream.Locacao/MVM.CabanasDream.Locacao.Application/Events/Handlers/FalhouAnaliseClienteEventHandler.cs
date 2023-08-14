using System;
using MediatR;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.ContratoContext;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.FestaContext.Enum;
using MVM.CabanasDream.Locacao.Domain.Repositories;
using MVM.CabanasDream.Locacao.Domain.Services.Interfaces;

namespace MVM.CabanasDream.Locacao.Application.Events.Handlers;

public class FalhouAnaliseClienteEventHandler : INotificationHandler<FalhouAnaliseClienteEvent>
{
    private readonly ILocacaoService _service;

    public FalhouAnaliseClienteEventHandler(ILocacaoService service)
    {
        _service = service;
    }

    public async Task Handle(FalhouAnaliseClienteEvent message, CancellationToken cancellationToken)
    {
        if (message.Motivo != EMotivoCancelamento.Analise)
            throw new DomainException("Deve ter falhado na analise.");

        await _service.CancelarFesta(message.AggregrateId, message.DataFinalizacao, message.Motivo);
    }
}

