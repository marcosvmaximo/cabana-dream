using System;
using System.Text.Json.Serialization;
using MVM.CabanasDream.BussinesLogic.Enum;
using MVM.CabanasDream.Core.Domain;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.Domain.Interfaces;
using MVM.CabanasDream.Core.Domain.Models;

namespace MVM.CabanasDream.BussinesLogic.Models;

public class Item : Entity
{
    public Item(EObjetoDeFesta objetoFesta, int quantidade)
    {
        Tipo = objetoFesta;
        Quantidade = quantidade;
    }

    public Item() { }

    public EObjetoDeFesta Tipo { get; set; }
    public int Quantidade { get; set; }
    public Guid TemaId { get; set; }
    [JsonIgnore]
    public Tema Tema { get; set; }

    public void AumentarQuantidade(int quantidade)
    {
        if ((Quantidade + quantidade) > 1000)
            throw new DomainException("Estoque insuficiente para realizar esta ação.");

        Quantidade += quantidade;
    }

    public void DiminuirQuantidade(int quantidade)
    {
        if (quantidade < 1 || (Quantidade -= quantidade) < 1)
            throw new DomainException("Item sem estoque suficiente para essa ação");

        Quantidade -= quantidade;
    }

    public void AdicionarNovaQuantidade(int quantidade)
    {
        Quantidade = quantidade;
    }

    public override void Validar()
    {
        throw new NotImplementedException();
    }
}

