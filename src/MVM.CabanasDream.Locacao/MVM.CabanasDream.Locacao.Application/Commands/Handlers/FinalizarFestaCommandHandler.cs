using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Core.Domain.Models;
using MVM.CabanasDream.Locacao.Domain.Repositories;
using MVM.CabanasDream.Locacao.Domain.Services.Interfaces;

namespace MVM.CabanasDream.Locacao.Application.Commands.Handlers;

public class FinalizarFestaCommandHandler : Handler<FinalizarFestaCommand>
{
    private readonly ILocacaoService _locacaoService;
    private readonly IMediatorHandler _mediator;
    private readonly IFestaRepository _repository;

    public FinalizarFestaCommandHandler(IFestaRepository repository,
                                        IMediatorHandler mediator,
                                        ILocacaoService locacaoService)
    {
        _locacaoService = locacaoService;
        _mediator = mediator;
        _repository = repository;
    }

    public override async Task<BaseResult> Handle(FinalizarFestaCommand command, CancellationToken cancellationToken)
    {
        if (!ValidarComando(command))
        {
            return BaseResult.BadResult();
        }

        var result = await _locacaoService.CompletarFesta(command.FestaId, command.DataFinalizacao);
        await _repository.UnityOfWork.Commit();

        return BaseResult.OkResult(result);
    }

    protected override bool ValidarComando(FinalizarFestaCommand command)
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

