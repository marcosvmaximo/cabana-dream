using System;
using MVM.CabanasDream.Core.Domain.DomainEvents;

namespace MVM.CabanasDream.Estoque.API.Application.Commands;

public class IncrementarArtigoDeFestaEstoqueCommand : Command
{
    public IncrementarArtigoDeFestaEstoqueCommand(Guid artigoFestaId, int valor)
    {
        ArtigoFestaId = artigoFestaId;
        Valor = valor;
    }

    public IncrementarArtigoDeFestaEstoqueCommand()
    {
    }

    public Guid ArtigoFestaId { get; set; }
    public int? Valor { get; set; }
}

