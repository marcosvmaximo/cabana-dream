using System;
using MediatR;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.ContratoContext;
using MVM.CabanasDream.Locacao.Domain;
using MVM.CabanasDream.Locacao.Domain.Repositories;
using MVM.CabanasDream.Locacao.Domain.Services.Interfaces;

namespace MVM.CabanasDream.Locacao.Application.Events.Handlers;

public class ContratoCriadoEventHandler : INotificationHandler<ContratoCriadoEvent>
{
    private readonly IFestaRepository _repository;
    private readonly ILocacaoService _service;

    public ContratoCriadoEventHandler(IFestaRepository repository, ILocacaoService service)
    {
        _service = service;
        _repository = repository;
    }

    public async Task Handle(ContratoCriadoEvent message, CancellationToken cancellationToken)
    {
        await _service.FecharContratoFesta(message.FestaId);

        await _repository.UnityOfWork.Commit();
    }
}

