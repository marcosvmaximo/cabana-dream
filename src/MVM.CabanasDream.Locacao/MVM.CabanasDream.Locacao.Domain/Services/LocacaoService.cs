﻿using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.FestaContext;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.FestaContext.Enum;
using MVM.CabanasDream.Locacao.Domain.Entities;
using MVM.CabanasDream.Locacao.Domain.Enum;
using MVM.CabanasDream.Locacao.Domain.Repositories;
using MVM.CabanasDream.Locacao.Domain.Services.Interfaces;

namespace MVM.CabanasDream.Locacao.Domain.Services;

public class LocacaoService : ILocacaoService
{
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IFestaRepository _repository;

    public LocacaoService(IFestaRepository repository, IMediatorHandler mediator)
    {
        _mediatorHandler = mediator;
        _repository = repository;
    }

    public async Task LocarFesta(Guid clienteId,
                                 Guid temaId,
                                 int quantidadeParticipantes,
                                 DateTime dataRealizacao,
                                 List<ArtigoFesta> artigos = null)
    {
        //if (await VerificaClientePossuiFestaPendente(clienteId))
        //    throw new DomainException("Cliente já possui festa pendente criada.");

        var cliente = ObterCliente(clienteId);
        var tema = ObterTema(temaId);

        var festa = new Festa(tema!, cliente!, quantidadeParticipantes, dataRealizacao);

        artigos?.ForEach(festa.AdicionarArtigoExtra);

        tema?.AdicionarFesta(festa);

        festa.AdicionarEvento(new FestaCriadaEvent(festa.Id, clienteId, festa.ObterDataDevolucao()));

        await _repository.AdicionarFesta(festa);
    }

    private async Task<bool> VerificaClientePossuiFestaPendente(Guid clienteId)
    {
        var festasPendentes = _repository.ObterFestasPorCliente(clienteId)
                                .Result
                                .Where(x =>
                                    x.Status == EStatusFesta.Pendente ||
                                    x.Status == EStatusFesta.AguardandoPagamento ||
                                    x.Status == EStatusFesta.EmAndamento);

        if (festasPendentes is null || !festasPendentes.Any())
            return false;

        await _mediatorHandler.PublicarNotificacao(
            new DomainNotification("Cliente", "Cliente já possúi uma festa pendente ou em processamento no momento."));
        return true;
    }

    private Tema? ObterTema(Guid temaId)
    {
        return _repository.ObterTemaPorId(temaId).Result ?? throw new DomainException("Tema não encontrado");
    }

    private Cliente? ObterCliente(Guid clienteId)
    {
        return _repository.ObterClientePorId(clienteId).Result ?? throw new DomainException("Cliente não encontrado");
    }

    public async Task<Festa> CancelarFesta(Guid festaId, DateTime dataFinalizacao, EMotivoCancelamento motivo)
    {
        Festa festa = await _repository.ObterFestaPorId(festaId) ??
            throw new DomainException("Festa inserida não foi encontrada");

        if (festa.DataRealizacao <= DateTime.Now)
            throw new DomainException("Não é possível cancelar uma festa que já foi realizada");

        if (festa.Status == Enum.EStatusFesta.Cancelada || festa.Status == Enum.EStatusFesta.Finalizada)
            throw new DomainException("Não é possível cancelar uma festa já cancelada ou finalizada");

        // Marca festa do cliente como cancelada
        festa.CancelarFesta(dataFinalizacao, motivo);

        // Volta ao estoque normal.
        festa.Tema?.IncrementarEstoque();

        await _repository.AtualizarFesta(festa);
        return festa;
    }

    public async Task<Festa> ConfirmarFesta(Guid festaId)
    {
        Festa festa = await _repository.ObterFestaPorId(festaId)
            ?? throw new DomainException("Festa inserida é inválida");

        festa.ConfirmarFesta();

        await _repository.AtualizarFesta(festa);
        return festa;
    }

    public async Task<Festa> CompletarFesta(Guid festaId, DateTime dataFinalizacao)
    {
        Festa festa = await _repository.ObterFestaPorId(festaId) ??
            throw new DomainException("Festa inserida não foi encontrada");

        if (festa.Status == Enum.EStatusFesta.Cancelada || festa.Status == Enum.EStatusFesta.Finalizada)
            throw new DomainException("Não é possível finalizar uma festa já finalizada ou cancelada");

        // Marca Festa como concluida.
        festa.FinalizarFesta(dataFinalizacao);

        // Volta ao estoque normal.
        festa.Tema?.IncrementarEstoque();

        await _repository.AtualizarFesta(festa!);
        return festa;
    }

    public async Task<Festa> ConfirmarPagamentoFesta(Guid festaId)
    {

        Festa festa = await _repository.ObterFestaPorId(festaId) ??
            throw new DomainException("Festa inserida não foi encontrada");

        festa.EntregarFesta();

        return festa;
    }
}