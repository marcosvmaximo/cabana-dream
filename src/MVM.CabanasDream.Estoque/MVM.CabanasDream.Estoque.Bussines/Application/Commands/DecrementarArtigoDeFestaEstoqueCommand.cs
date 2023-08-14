using System;
using MVM.CabanasDream.Core.Domain.DomainEvents;

namespace MVM.CabanasDream.Estoque.API.Application.Commands;

public class DecrementarArtigoDeFestaEstoqueCommand : Command
{
    public DecrementarArtigoDeFestaEstoqueCommand(Guid artigoFestaId, int? valor)
    {
        ArtigoFestaId = artigoFestaId;
        Valor = valor;
    }

    public DecrementarArtigoDeFestaEstoqueCommand()
    {
    }

    public Guid ArtigoFestaId { get; set; }
    public int? Valor { get; set; }
}

