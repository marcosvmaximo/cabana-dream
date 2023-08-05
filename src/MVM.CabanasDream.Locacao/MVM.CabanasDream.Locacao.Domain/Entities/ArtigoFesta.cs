using System;
using MVM.CabanasDream.Core.Domain.AssertionConcern;
using MVM.CabanasDream.Core.Domain.Models;
using MVM.CabanasDream.Core.Domain.ValueObjects;

namespace MVM.CabanasDream.Locacao.Domain.Entities;

public class ArtigoFesta : Entity
{
    public ArtigoFesta(string nome, decimal valor, int quantidade)
    {
        Nome = nome;
        Valor = valor;
        Quantidade = quantidade;
    }

    protected ArtigoFesta() { }

    public string Nome { get; private set; }
    public decimal Valor { get; private set; }
    public int Quantidade { get; private set; }
    public Tema Tema { get; private set; }
    public Guid TemaId { get; private set; }

    public override void Validar()
    {
        Assertion.ValidarSeNulo(Nome, "O campo {0} não deve ser nulo ou vazio");
        Assertion.ValidarSeMenorQue(Valor, 1, "O campo {0} não deve ser menor que 1");
        Assertion.ValidarSeMenorQue(Quantidade, 1, "O campo {0} não deve ser menor que 1");
    }
}

