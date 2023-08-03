using System;
using System.Collections.Generic;
using MVM.CabanasDream.Core.Domain.AssertionConcern;
using MVM.CabanasDream.Core.Domain.Models;
using MVM.CabanasDream.Locacao.Domain.ValueObjects;

namespace MVM.CabanasDream.Locacao.Domain.Entities;

public class Tema : Entity
{
    private readonly IList<ItemDeFesta> _itensDeFesta;
    private readonly IList<Festa> _festas;

    public Tema(string nome, int estoque)
    {
        Nome = nome;
        Estoque = estoque;
        Disponivel = true;
        _itensDeFesta = new List<ItemDeFesta>();
        _festas = new List<Festa>();

        Validar();
    }

    public string Nome { get; private set; }
    public int Estoque { get; private set; }
    public bool Disponivel { get; private set; }
    public IReadOnlyCollection<ItemDeFesta> ItensDeFestas => _itensDeFesta.ToList();
    public IReadOnlyCollection<Festa> Festas => _festas.ToList();

    public bool VerificarDisponibilidade()
    {
        if (Estoque > 0) return true;

        return false;
    }

    public void AdicionarFesta(Festa festa)
    {
        Assertion.ValidarSeNulo(festa, "Não é possível adicionar uma festa nula");

        _festas.Add(festa);

        DecrementarEstoque();
    }

    public void DecrementarEstoque() => Estoque--;
    public void IncrementarEstoque() => Estoque++;

    public void Indisponibilizar() => Disponivel = false;
    public void Disponibilizar() => Disponivel = true;

    public override void Validar()
    {
        Assertion.ValidarSeNulo(Nome, "O campo {0} não deve ser nulo ou vazio");
        Assertion.ValidarSeVazio(Nome, "O campo {0} não deve ser nulo ou vazio");

        Assertion.ValidarSeMenorQue(Estoque, 1, "O campo {0} não deve ser menor que 1");
    }
}

