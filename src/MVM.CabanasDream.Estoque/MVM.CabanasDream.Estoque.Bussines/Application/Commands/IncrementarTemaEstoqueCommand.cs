using System;
using MediatR;
using MVM.CabanasDream.Core.Domain.DomainEvents;

namespace MVM.CabanasDream.Estoque.API.Application.Commands;

public class IncrementarTemaEstoqueCommand : Command
{
    public IncrementarTemaEstoqueCommand(Guid temaId, int valor)
    {
        TemaId = temaId;
        Valor = valor;
    }

    public IncrementarTemaEstoqueCommand()
    {
    }

    public Guid TemaId { get; set; }
    public int? Valor { get; set; }
}

