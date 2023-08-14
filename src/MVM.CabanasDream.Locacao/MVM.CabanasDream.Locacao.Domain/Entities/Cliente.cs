using System;
using MVM.CabanasDream.Core.Domain.AssertionConcern;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.Domain.Models;
using MVM.CabanasDream.Core.Domain.ValueObjects;

namespace MVM.CabanasDream.Locacao.Domain.Entities;

public class Cliente : Entity
{
    private readonly IList<Festa> _festas;

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
        _festas = new List<Festa>();

        Validar();
    }

    public string Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public Documento Documento { get; private set; }
    public Contato Contato { get; private set; }
    public Endereco Endereco { get; private set; }
    public IReadOnlyCollection<Festa> Festas => _festas.ToList();

    public IEnumerable<Festa?> ObterFestasCanceladas()
    {
        return _festas.Where(x => x.Status == Enum.EStatusFesta.Cancelada);
    }

    public void AdicionarFesta(Festa festa)
    {
        Assertion.ValidarSeNulo(festa, "Festa inválida, não deve ser nula.");

        if (festa.Status == Enum.EStatusFesta.Cancelada)
            throw new DomainException("Não é possível adicionar uma festa cancelada.");

        _festas.Add(festa);
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

