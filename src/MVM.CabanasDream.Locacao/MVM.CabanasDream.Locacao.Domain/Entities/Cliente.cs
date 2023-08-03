using System;
using MVM.CabanasDream.Core.Domain.AssertionConcern;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.Domain.Models;
using MVM.CabanasDream.Core.Domain.ValueObjects;

namespace MVM.CabanasDream.Locacao.Domain.Entities;

public class Cliente : Entity
{
    private readonly IList<Festa> _festasRealizadas;

    protected Cliente() { }

    public Cliente(
        string nome,
        DateTime dataNascimento,
        Documento documento,
        Contato contato,
        Endereco endereco)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Documento = documento;
        Contato = contato;
        Endereco = endereco;
        _festasRealizadas = new List<Festa>();

        Validar();
    }

    public string Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public Documento Documento { get; private set; }
    public Contato Contato { get; private set; }
    public Endereco Endereco { get; private set; }
    public IReadOnlyCollection<ContratoLocacao> Contratos { get; private set; }
    public IReadOnlyCollection<Festa> FestasRealizadas => _festasRealizadas.ToList();

    public IEnumerable<Festa?> ObterFestasCanceladas()
    {
        return _festasRealizadas.Where(x => x.Status == Enum.EStatusFesta.Cancelada);
    }

    public void AdicionarFestaRealizada(Festa festa)
    {
        Assertion.ValidarSeNulo(festa, "Festa inválida, não deve ser nula.");

        if (festa.Status != Enum.EStatusFesta.Finalizada)
            throw new DomainException("Festa ainda não foi finalizada.");

        _festasRealizadas.Add(festa);
    }

    public override void Validar()
    {
        Assertion.ValidarSeNulo(Nome, "O campo {0} não deve ser nulo ou vazio");
        Assertion.ValidarSeVazio(Nome, "O campo {0} não deve ser nulo ou vazio");

        Assertion.ValidarSeNulo(Documento, "O campo {0} não deve ser nulo ou vazio");
        Assertion.ValidarSeNulo(Contato, "O campo {0} não deve ser nulo ou vazio");
        Assertion.ValidarSeNulo(Endereco, "O campo {0} não deve ser nulo ou vazio");

        Assertion.ValidarSeIgual(DataNascimento, DateTime.MinValue, "Data de Nascimento inválida");
        Assertion.ValidarSeIgual(DataNascimento, DateTime.MaxValue, "Data de Nascimento inválida");
    }
}

