using MVM.CabanasDream.Core.Domain.AssertionConcern;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.Domain.Interfaces;
using MVM.CabanasDream.Core.Domain.Models;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.ContratoContext;
using MVM.CabanasDream.Fiscal.API.Models.Entities;
using MVM.CabanasDream.Fiscal.API.Models.Enum;

namespace MVM.CabanasDream.Fiscal.API.Models;

public class Contrato : Entity, IAggregateRoot
{
    public Contrato(Cliente cliente, Festa festa, DateTime dataDevolucao)
    {
        ClienteId = cliente.Id;
        FestaId = festa.Id;
        DataDevolucao = dataDevolucao;
        Vigente = true;

        Cliente = cliente;
        Festa = festa;

        Validar();

        AdicionarEvento(new ContratoCriadoEvent(Id, FestaId));
    }

    protected Contrato() { }

    public Guid ClienteId { get; private set; }
    public Guid FestaId { get; private set; }
    public DateTime DataDevolucao { get; private set; }
    public decimal Multa { get => CalcularMulta(); private set => Multa = value; }
    public decimal Valor { get => CalcularValor(); private set => Valor = value; }
    public bool Vigente { get; private set; }

    // Ef Rel..
    public Cliente Cliente { get; private set; }
    public Festa Festa { get; private set; }

    private decimal CalcularValor()
    {
        decimal valorBase = 250; // Valor base da festa
        decimal valorPorParticipante = 35; // Valor adicional por participante
        decimal valorPorArtigoExtra = 30; // Valor por cada item extra

        decimal valorTotal = valorBase + (Festa.QuantidadeParticipantes * valorPorParticipante) + (Festa.QuantidadeArtigosDeFestasExtra * valorPorArtigoExtra);

        return valorTotal;
    }

    private decimal CalcularMulta()
    {
        decimal taxaMulta = 0.07m; // Taxa de multa de 7%
        decimal taxaAdicional = 0.01m; // Taxa adicional de 1% por participante ou item extra

        decimal multa = Valor * taxaMulta;
        decimal adicional = Valor * (Festa.QuantidadeParticipantes + Festa.QuantidadeArtigosDeFestasExtra) * taxaAdicional;

        return multa + adicional;
    }

    public override void Validar()
    {
        Assertion.ValidarSeMenorQue(Multa, 0, "O campo {0} não pode ser menor do que 0");
        Assertion.ValidarSeMenorQue(Valor, 0, "O campo {0} não pode ser menor do que 0");
        Assertion.ValidarSeMenorQue(Valor, Multa, "O campo {0} não pode ser menor que a taxa de multa");

        Assertion.ValidarSeFalso(DataDevolucao <= DateTime.Now, "O campo {0} não pode ser menor que a data atual");

        Assertion.ValidarSeNulo(Cliente, "O campo {0} não pode conter valores nulos");
        Assertion.ValidarSeNulo(Festa, "O campo {0} não pode conter valores nulos");
    }

    public void QuebrarContrato(EStatusFesta status)
    {
        if (status != EStatusFesta.Cancelada)
            throw new DomainException($"Não é possível quebrar um contrato de uma festa {status}");

        Vigente = false;
        DataDevolucao = DateTime.Now.AddHours(18);
    }
}

