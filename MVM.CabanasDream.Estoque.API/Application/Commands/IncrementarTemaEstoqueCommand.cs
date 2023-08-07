using System;
using MediatR;
using MVM.CabanasDream.Core.Domain.DomainEvents;

namespace MVM.CabanasDream.Estoque.API.Application.Commands;

public class IncrementarTemaEstoqueCommand : IRequest<bool>
{
    public IncrementarTemaEstoqueCommand()
    {
    }
}

