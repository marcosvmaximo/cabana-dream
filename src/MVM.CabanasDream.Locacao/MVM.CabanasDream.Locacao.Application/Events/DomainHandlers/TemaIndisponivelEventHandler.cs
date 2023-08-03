using MediatR;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Locacao.Domain.Events;
using MVM.CabanasDream.Locacao.Domain.Repositories;

namespace MVM.CabanasDream.Locacao.Application.DomainHandlers.Handlers;

public class TemaIndisponivelEventHandler : INotificationHandler<TemaIndisponivelEvent>
{
    private readonly IFestaRepository _repository;

    public TemaIndisponivelEventHandler(IFestaRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(TemaIndisponivelEvent evento, CancellationToken cancellationToken)
    {
        var tema = await _repository.ObterTemaPorId(evento.TemaId);

        if (tema == null)
            throw new DomainException("Tema informado inválido.");

        tema.Indisponibilizar();

        // Chamar serviço de email enviando para o dono do negócio
    }
}

