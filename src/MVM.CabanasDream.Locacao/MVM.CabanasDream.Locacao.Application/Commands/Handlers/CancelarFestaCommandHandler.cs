using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Core.Domain.Models;
using MVM.CabanasDream.Locacao.Domain.Repositories;
using MVM.CabanasDream.Locacao.Domain.Services.Interfaces;

namespace MVM.CabanasDream.Locacao.Application.Commands.Handlers;

public class CancelarFestaCommandHandler : Handler<CancelarFestaCommand>
{
    private readonly IMediatorHandler _mediator;
    private readonly IFestaRepository _repository;
    private readonly ILocacaoService _locacaoService;

    public CancelarFestaCommandHandler(IFestaRepository repository,
                                       IMediatorHandler mediator,
                                       ILocacaoService locacaoService)
    {
        _mediator = mediator;
        _repository = repository;
        _locacaoService = locacaoService;
    }

    public override async Task<BaseResult> Handle(CancelarFestaCommand command, CancellationToken cancellationToken)
    {
        if (!ValidarComando(command))
            return BaseResult.BadResult();

        await _locacaoService.CancelarFesta(command.FestaId, command.DataFinalizacao, command.Motivo);
        await _repository.UnityOfWork.Commit();

        return BaseResult.OkResult(null);
    }

    protected override bool ValidarComando(CancelarFestaCommand command)
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

