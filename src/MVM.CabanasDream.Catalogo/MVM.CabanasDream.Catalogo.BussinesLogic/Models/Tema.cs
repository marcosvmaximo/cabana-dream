using System;
using MVM.CabanasDream.BussinesLogic.Enum;
using MVM.CabanasDream.Core.Domain;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.Domain.Interfaces;
using MVM.CabanasDream.Core.Domain.Models;

namespace MVM.CabanasDream.BussinesLogic.Models;

public class Tema : Entity, IAggregateRoot
{
    public Tema(string nome, string imagem)
    {
        Nome = nome;
        Disponivel = true;
        Imagem = imagem;
    }

    public Tema() { }

    public string Nome { get; set; }
    public bool Disponivel { get; set; }
    public string Imagem { get; set; }
    public List<Item> Itens { get; set; }

    public void DesativarTema()
    {
        Disponivel = false;
    }

    public void AtivarTema()
    {
        Disponivel = true;
    }

    public void AtualizarImagem(string novaImagem)
    {
        if (string.IsNullOrWhiteSpace(novaImagem))
            throw new DomainException("Não é possível inserir uma nova imagem vazia.");

        Imagem = novaImagem;
    }

    public void AdicionarItem(Item item)
    {
        if (item == null)
            throw new DomainException("Item inválido.");

        Itens.Add(item);
    }

    public override void Validar()
    {
        throw new NotImplementedException();
    }
}

