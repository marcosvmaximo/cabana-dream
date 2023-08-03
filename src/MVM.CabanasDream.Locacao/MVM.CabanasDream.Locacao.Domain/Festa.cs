using MVM.CabanasDream.Core.Domain.AssertionConcern;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.Domain.Interfaces;
using MVM.CabanasDream.Core.Domain.Models;
using MVM.CabanasDream.Locacao.Domain.Entities;
using MVM.CabanasDream.Locacao.Domain.Enum;
using MVM.CabanasDream.Locacao.Domain.ValueObjects;

namespace MVM.CabanasDream.Locacao.Domain;
public class Festa : Entity, IAggregateRoot
{
    private readonly IList<ItemDeFesta> _itensExtras;

    protected Festa() { }

    public Festa(
        Tema tema,
        Cliente cliente,
        int quantidadeParticipantes,
        DateTime dataRealizacao)
    {
        Tema = tema;
        TemaId = tema.Id;
        Cliente = cliente;
        ClienteId = cliente.Id;
        QuantidadeParticipantes = quantidadeParticipantes;
        Status = EStatusFesta.Pendente;
        DataRealizacao = dataRealizacao;
        _itensExtras = new List<ItemDeFesta>();

        Validar();
    }

    public Tema Tema { get; private set; }
    public Guid TemaId { get; private set; }
    public Cliente Cliente { get; private set; }
    public Guid ClienteId { get; private set; }
    public int QuantidadeParticipantes { get; private set; }
    public EStatusFesta Status { get; private set; }
    public ContratoLocacao? ContratoLocacao { get; private set; }
    public Guid? ContratoId { get; private set; }
    public DateTime DataRealizacao { get; private set; }
    public IReadOnlyCollection<ItemDeFesta> ItensExtras => _itensExtras.ToList();

    public void CancelarFesta()
    {
        if (Status == EStatusFesta.Cancelada || Status == EStatusFesta.Finalizada)
            throw new DomainException("Não é possível cancelar uma festa já cancelada ou finalizada");

        if (DataRealizacao <= DateTime.Now)
            throw new DomainException("Não é possível cancelar uma festa que já foi realizada");

        Status = EStatusFesta.Cancelada;
        ContratoLocacao.QuebrarContrato(Status);
    }

    public void ConfirmarFesta() => Status = EStatusFesta.AguardandoPagamento;
    public void EntregarFesta() => Status = EStatusFesta.EmAndamento;
    public void FinalizarFesta() => Status = EStatusFesta.Finalizada;

    public void AdicionarItemDeFestaExtra(ItemDeFesta itemDeFesta)
    {
        if (itemDeFesta == null)
            throw new DomainException("Item De Festa inválido, impossível adicionar um item nulo.");

        if (Status != EStatusFesta.Pendente)
            throw new DomainException("Não é mais possível adicionar objetos extras.");

        _itensExtras.Add(itemDeFesta);
    }

    public void AdicionarContrato(ContratoLocacao contrato)
    {
        if (contrato == null)
            throw new DomainException("Contrato inválido, não pode ser nulo.");

        if (contrato.DataDevolucao <= DateTime.Now)
            throw new DomainException("Contrato inválido, não deve possuir uma data de devolução menor que a data atual.");

        ConfirmarFesta();
        ContratoLocacao = contrato;
        ContratoId = contrato.Id;
    }

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

