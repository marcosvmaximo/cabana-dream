using MediatR;
using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Core.Domain.DomainEvents;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.Domain.Models;
using MVM.CabanasDream.Estoque.API.Application.Commands;
using MVM.CabanasDream.Estoque.API.Models;

namespace MVM.CabanasDream.Estoque.API.Application.Handlers;

public class EstoqueCommandHandler :
    IRequestHandler<IncrementarArtigoDeFestaEstoqueCommand, BaseResult>,
    IRequestHandler<IncrementarTemaEstoqueCommand, BaseResult>,
    IRequestHandler<DecrementarArtigoDeFestaEstoqueCommand, BaseResult>,
    IRequestHandler<DecrementarTemaEstoqueCommand, BaseResult>
{
    private readonly IEstoqueRepository _repository;
    private readonly IMediatorHandler _mediator;

    public EstoqueCommandHandler(IEstoqueRepository repository, IMediatorHandler mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<BaseResult> Handle(IncrementarArtigoDeFestaEstoqueCommand command, CancellationToken cancellationToken)
    {
        if (!ValidarComando(command))
        {
            return BaseResult.BadResult();
        }

        var artigoFesta = await _repository.ObterArtigoFestaPorId(command.ArtigoFestaId)
            ?? throw new DomainException("Artigo de Festa inserido não foi encontrado.");

        artigoFesta.AdicionarEstoque(command.Valor);

        await _repository.AtualizarArtigoFesta(artigoFesta);
        await _repository.UnityOfWork.Commit();

        return BaseResult.OkResult(artigoFesta);
    }

    public async Task<BaseResult> Handle(IncrementarTemaEstoqueCommand command, CancellationToken cancellationToken)
    {
        if (!ValidarComando(command))
        {
            return BaseResult.BadResult();
        }

        var tema = await _repository.ObterTemaPorId(command.TemaId)
            ?? throw new DomainException("Tema inserido não foi encontrado.");

        tema.AdicionarEstoque(command.Valor);

        await _repository.AtualizarTema(tema);
        await _repository.UnityOfWork.Commit();

        return BaseResult.OkResult(tema);
    }

    public async Task<BaseResult> Handle(DecrementarArtigoDeFestaEstoqueCommand command, CancellationToken cancellationToken)
    {
        if (!ValidarComando(command))
        {
            return BaseResult.BadResult();
        }

        ArtigoFesta artigoFesta = await _repository.ObterArtigoFestaPorId(command.ArtigoFestaId)
            ?? throw new DomainException("Artigo de Festa inserido não foi encontrado.");

        artigoFesta.DiminuirEstoque(command.Valor);

        await _repository.AtualizarArtigoFesta(artigoFesta);
        await _repository.UnityOfWork.Commit();

        return BaseResult.OkResult(artigoFesta);
    }

    public async Task<BaseResult> Handle(DecrementarTemaEstoqueCommand command, CancellationToken cancellationToken)
    {
        if (!ValidarComando(command))
        {
            return BaseResult.BadResult();
        }

        var tema = await _repository.ObterTemaPorId(command.TemaId)
            ?? throw new DomainException("Tema inserido não foi encontrado.");

        tema.DiminuirEstoque(command.Valor);

        await _repository.AtualizarTema(tema);
        await _repository.UnityOfWork.Commit();

        return BaseResult.OkResult(tema);
    }

    protected bool ValidarComando<T>(T command) where T : Command
    {
        if (!command.EhValido())
        {
            foreach (var error in command.ValidationResult.Errors)
            {
                _mediator.PublicarNotificacao(new DomainNotification(
                    error.PropertyName, error.ErrorMessage));
            }
        }

        return command.EhValido();
    }
}

