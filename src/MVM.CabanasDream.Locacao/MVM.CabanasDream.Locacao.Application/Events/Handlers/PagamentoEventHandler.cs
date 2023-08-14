using System;
using MediatR;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.PagamentoContext;
using MVM.CabanasDream.Locacao.Domain.Services.Interfaces;

namespace MVM.CabanasDream.Locacao.Application.Events.Handlers;

public class PagamentoEventHandler :
    INotificationHandler<PagamentoRealizadoEvent>,
    INotificationHandler<PagamentoRecusadoEvent>
{
    private readonly ILocacaoService _service;

    public PagamentoEventHandler(ILocacaoService service)
    {
        _service = service;
    }

    public async Task Handle(PagamentoRealizadoEvent message, CancellationToken cancellationToken)
    {
        //await _service.ConfirmarPagamentoFesta();
    }

    public async Task Handle(PagamentoRecusadoEvent message, CancellationToken cancellationToken)
    {
        //await _service.CancelarFesta();
    }
}

