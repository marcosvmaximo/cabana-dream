using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.FestaContext;
using MVM.CabanasDream.Locacao.Domain.Entities;
using MVM.CabanasDream.Locacao.Domain.Events.Festas;
using MVM.CabanasDream.Locacao.Domain.Repositories;
using MVM.CabanasDream.Locacao.Domain.Services.Interfaces;

namespace MVM.CabanasDream.Locacao.Domain.Services;

public class LocacaoService : ILocacaoService
{
    private readonly IMediatrHandler _mediatorHandler;
    private readonly IFestaRepository _repository;

    public LocacaoService(IFestaRepository repository, IMediatrHandler mediator)
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
        if (await VerificaClientePossuiFestaPendente(clienteId))
            throw new DomainException("Cliente já possui festa pendente criada.");

        var cliente = ObterCliente(clienteId);
        var tema = ObterTema(temaId);

        var festa = new Festa(tema!, cliente!, quantidadeParticipantes, dataRealizacao);

        artigos?.ForEach(festa.AdicionarArtigoExtra);

        tema.AdicionarFesta(festa);

        festa.AdicionarEvento(new FestaCriadaEvent(festa.Id, clienteId, festa.ObterDataDevolucao()));

        await _repository.AdicionarFesta(festa);
    }

    private async Task<bool> VerificaClientePossuiFestaPendente(Guid clienteId)
    {
        var festasPendentes = _repository.ObterFestasPorCliente(clienteId).Result
            .Where(x => x.Status == Enum.EStatusFesta.Pendente ||
                        x.Status == Enum.EStatusFesta.AguardandoPagamento ||
                        x.Status == Enum.EStatusFesta.EmAndamento);

        if (festasPendentes == null || festasPendentes.Any())
            return false;

        DomainNotification notificacao = new DomainNotification("Cliente", "Cliente já possúi uma festa pendente ou em processamento no momento.");
        await _mediatorHandler.PublicarNotificacao(notificacao);

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

    public async Task<Festa> CancelarFesta(Guid festaId)
    {
        Festa festa = await _repository.ObterFestaPorId(festaId) ??
            throw new DomainException("Festa inserida não foi encontrada");

        if (festa.DataRealizacao <= DateTime.Now)
            throw new DomainException("Não é possível cancelar uma festa que já foi realizada");

        if (festa.Status == Enum.EStatusFesta.Cancelada || festa.Status == Enum.EStatusFesta.Finalizada)
            throw new DomainException("Não é possível cancelar uma festa já cancelada ou finalizada");

        // Marca festa do cliente como cancelada
        festa.CancelarFesta();

        // Volta ao estoque normal.
        festa.Tema?.DecrementarEstoque();

        await _repository.AtualizarFesta(festa);
        return festa;
    }

    public async Task<Festa> FecharContratoFesta(Guid festaId)
    {
        // recebe o evento e marca festa como aguardando pagamento ou em andamento
    }

    public async Task<Festa> FinalizarFesta(Guid festaId, DateTime dataFinalizacao)
    {
        Festa festa = await _repository.ObterFestaPorId(festaId) ??
            throw new DomainException("Festa inserida não foi encontrada");

        if (festa.Status == Enum.EStatusFesta.Cancelada || festa.Status == Enum.EStatusFesta.Finalizada)
            throw new DomainException("Não é possível finalizar uma festa já finalizada ou cancelada");

        // Marca Festa como concluida.
        festa.FinalizarFesta(dataFinalizacao);

        // Volta ao estoque normal.
        festa.Tema?.DecrementarEstoque();

        await _repository.AtualizarFesta(festa!);
        return festa;
    }
}