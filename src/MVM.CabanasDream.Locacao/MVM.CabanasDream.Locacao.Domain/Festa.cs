using MVM.CabanasDream.Core.Domain.AssertionConcern;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.Domain.Interfaces;
using MVM.CabanasDream.Core.Domain.Models;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.FestaContext;
using MVM.CabanasDream.Locacao.Domain.Entities;
using MVM.CabanasDream.Locacao.Domain.Enum;

namespace MVM.CabanasDream.Locacao.Domain;
public class Festa : Entity, IAggregateRoot
{
    private readonly IList<ArtigoFesta> _artigosDeFesta;

    protected Festa() { }

    public Festa(
        Tema tema,
        Cliente cliente,
        int quantidadeParticipantes,
        DateTime dataRealizacao)
    {
        Tema = tema;
        Cliente = cliente;
        QuantidadeParticipantes = quantidadeParticipantes;
        DataRealizacao = dataRealizacao;

        TemaId = tema.Id;
        ClienteId = cliente.Id;

        Status = EStatusFesta.Pendente;
        _artigosDeFesta = new List<ArtigoFesta>();

        Validar();
    }

    public Tema Tema { get; private set; }
    public Guid TemaId { get; private set; }
    public Cliente Cliente { get; private set; }
    public Guid ClienteId { get; private set; }
    public int QuantidadeParticipantes { get; private set; }
    public EStatusFesta Status { get; private set; }
    public DateTime DataRealizacao { get; private set; }
    public Guid? ContratoId { get; private set; }
    public IReadOnlyCollection<ArtigoFesta> ArtigosDeFesta => _artigosDeFesta.ToList();

    public void ConfirmarFesta()
    {
        Status = EStatusFesta.AguardandoPagamento;

        AdicionarEvento(new FestaAguardandoPagamentoEvent(Id));
    }
    public void EntregarFesta() => Status = EStatusFesta.EmAndamento;

    public void CancelarFesta(DateTime dataFinalizacao, string motivo)
    {
        if (Status == EStatusFesta.Cancelada || Status == EStatusFesta.Finalizada)
            throw new DomainException("Não é possível cancelar uma festa já cancelada ou finalizada");

        if (DataRealizacao <= DateTime.Now || dataFinalizacao <= DateTime.Now)
            throw new DomainException("Não é possível cancelar uma festa que já foi realizada");

        Status = EStatusFesta.Cancelada;
        AdicionarEvento(new FestaCanceladaEvent(Id, ContratoId, dataFinalizacao, motivo));
    }

    public void FinalizarFesta(DateTime dataFinalizacao)
    {
        AdicionarEvento(new FestaFinalizadaEvent(Id, dataFinalizacao));
        Status = EStatusFesta.Finalizada;
    }

    public void AdicionarArtigoExtra(ArtigoFesta itemDeFesta)
    {
        if (itemDeFesta == null)
            throw new DomainException("Item De Festa inválido, impossível adicionar um item nulo.");

        if (Status != EStatusFesta.Pendente)
            throw new DomainException("Não é mais possível adicionar objetos extras.");

        _artigosDeFesta.Add(itemDeFesta);
    }

    public DateTime ObterDataDevolucao() => DataRealizacao.AddDays(2);

    public override void Validar()
    {
        if (!Tema.VerificarDisponibilidade())
            throw new DomainException("Tema sem estoque disponivel.");

        Assertion.ValidarSeNulo(Tema, "O campo {0} não deve ser nulo ou vazio");
        Assertion.ValidarSeNulo(Cliente, "O campo {0} não deve ser nulo ou vazio");
        Assertion.ValidarSeNulo(Status, "O campo {0} não deve ser nulo ou vazio");
        Assertion.ValidarSeMenorQue(QuantidadeParticipantes, 1, "A quantidade de participante não deve ser menor que 1 participante.");
        Assertion.ValidarSeVerdadeiro(DataRealizacao <= DateTime.Now, "O campo {0} não pode ser menor que a data atual");
    }
}
