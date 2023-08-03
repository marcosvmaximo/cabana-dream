using System;
using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Core.Domain.DomainEvents;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.Domain.Results;
using MVM.CabanasDream.Locacao.Domain.Entities;
using MVM.CabanasDream.Locacao.Domain.Events;
using MVM.CabanasDream.Locacao.Domain.Repositories;
using MVM.CabanasDream.Locacao.Domain.Services.Interfaces;
using MVM.CabanasDream.Locacao.Domain.ValueObjects;

namespace MVM.CabanasDream.Locacao.Domain.Services;

public class LocacaoService : ILocacaoService
{
    private readonly IMediatrHandler _bus;
    private readonly IFestaRepository _repository;

    public LocacaoService(IFestaRepository repository, IMediatrHandler bus)
    {
        _bus = bus;
        _repository = repository;
    }

    public async Task LocarFesta(Guid clienteId,
                                 Guid temaId,
                                 int quantidadeParticipantes,
                                 DateTime dataRealizacao,
                                 List<ItemDeFesta> itens = null)
    {
        //if (await VerificaClientePossuiFestaPendente(clienteId))
        //    throw new DomainException("Cliente já possui festa pendente criada.");

        var cliente = ObterCliente(clienteId);
        var tema = ObterTema(temaId);

        var festa = new Festa(tema, cliente, quantidadeParticipantes, dataRealizacao);
        itens?.ForEach(festa.AdicionarItemDeFestaExtra);

        tema.AdicionarFesta(festa);

        if (tema.Estoque < 1)
            await _bus.PublicarEvento(new TemaIndisponivelEvent(festa.Id, tema.Id, tema.Estoque));

        festa.AdicionarEvento(new FestaCriadaEvent(festa.Id, clienteId));

        await _repository.AdicionarFesta(festa);
    }

    private async Task<bool> VerificaClientePossuiFestaPendente(Guid clienteId)
    {
        var festaPendente = await _repository.ObterFestasPendentesPorCliente(clienteId);

        if (festaPendente != null) // testar como o operador modifica nessa situação.
        {
            var notificacao = new DomainNotification(
                nameof(festaPendente),
                "Cliente já possúi uma festa pendente ou em processamento no momento.");
            await _bus.PublicarNotificacao(notificacao);

            return true;
        }

        return false;
    }

    private Tema? ObterTema(Guid temaId)
    {
        return _repository.ObterTemaPorId(temaId).Result ?? throw new DomainException("Tema não encontrado");
    }

    private Cliente? ObterCliente(Guid clienteId)
    {
        return _repository.ObterClientePorId(clienteId).Result ?? throw new DomainException("Cliente não encontrado");
    }

    public async Task<decimal?> CancelarFesta(Guid festaId)
    {
        var festa = await _repository.ObterFestaPorId(festaId);

        if (festa == null)
            throw new DomainException("Festa inserida não foi encontrada");

        if (festa.DataRealizacao <= DateTime.Now)
            throw new DomainException("Não é possível cancelar uma festa que já foi realizada");

        if (festa.Status == Enum.EStatusFesta.Cancelada || festa.Status == Enum.EStatusFesta.Finalizada)
            throw new DomainException("Não é possível cancelar uma festa já cancelada ou finalizada");

        festa.CancelarFesta();
        festa.Tema?.DecrementarEstoque();

        await _repository.AtualizarFesta(festa!);

        return festa.ContratoLocacao?.Multa;
    }

    public async Task FecharFesta(Guid festaId)
    {

        var festa = await _repository.ObterFestaPorId(festaId);

        if (festa == null)
            throw new DomainException("Festa inserida não foi encontrada");

        if (festa.Status == Enum.EStatusFesta.Cancelada || festa.Status == Enum.EStatusFesta.Finalizada)
            throw new DomainException("Não é possível finalizar uma festa já finalizada ou cancelada");

        festa.FinalizarFesta();
        festa.Tema?.DecrementarEstoque();

        await _repository.AtualizarFesta(festa!);
    }

    public async Task<ContratoLocacao> MostrarTermosDoContrato(Guid festaId)
    {
        var festa = await _repository.ObterFestaPorId(festaId);

        if (festa == null)
            throw new DomainException("Festa inserida não foi encontrada");

        return festa.ContratoLocacao;
    }
}