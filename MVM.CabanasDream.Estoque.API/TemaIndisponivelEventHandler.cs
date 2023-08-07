using MediatR;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Locacao.Domain.Events;
using MVM.CabanasDream.Locacao.Domain.Repositories;

namespace MVM.CabanasDream.Locacao.Application.Events.Handlers;

public class TemaIndisponivelEventHandler : INotificationHandler<TemaIndisponivelEvent>
{
    private readonly IFestaRepository _repository;

    public TemaIndisponivelEventHandler(IFestaRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(TemaIndisponivelEvent message, CancellationToken cancellationToken)
    {
        var tema = await _repository.ObterTemaPorId(message.TemaId);

        if (tema == null)
            throw new DomainException("Tema informado inválido.");

        // Chamar serviço de email enviando para o dono do negócio
    }
}

