using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Core.Domain.Results;
using MVM.CabanasDream.Locacao.Application.Commands;
using MVM.CabanasDream.Locacao.Domain.Entities;
using MVM.CabanasDream.Locacao.Domain.Repositories;
using MVM.CabanasDream.Locacao.Domain.Services.Interfaces;
namespace MVM.CabanasDream.Locacao.Application.Handlers;

public class CriarFestaCommandHandler : Handler<CriarFestaCommand>
{
    private readonly IMediatrHandler _mediator;
    private readonly IFestaRepository _repository;
    private readonly ILocacaoService _service;

    public CriarFestaCommandHandler(
        IMediatrHandler mediator,
        IFestaRepository repository,
        ILocacaoService service)
    {
        _mediator = mediator;
        _repository = repository;
        _service = service;
    }

    public override async Task<BaseResult> Handle(CriarFestaCommand command, CancellationToken cancellationToken)
    {
        if (!ValidarComando(command))
        {
            return BaseResult.BadResult();
        }

        var artigosExtras = command.ArtigosDeFesta.Select(artigo =>
            new ArtigoFesta(artigo!.Nome, artigo.ValorExtra, artigo.Quantidade));

        await _service.LocarFesta(
            command.ClienteId,
            command.TemaId,
            command.QuantidadeParticipantes,
            command.DataRealizacao,
            artigosExtras.ToList());

        await _repository.UnityOfWork.Commit();

        return BaseResult.OkResult("Festa cadastrada com sucesso.");
    }

    protected override bool ValidarComando(CriarFestaCommand command)
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

