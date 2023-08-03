using System;
using MVM.CabanasDream.Core.Domain.Models;

namespace MVM.CabanasDream.Locacao.Domain.ValueObjects;

public class ItemDeFesta : ValueObject
{
    public ItemDeFesta(string nome, int quantidade)
    {
        Nome = nome;
        Quantidade = quantidade;
    }

    public string Nome { get; private set; }
    public int Quantidade { get; private set; }

    public override void Validar()
    {
        throw new NotImplementedException();
    }
}

