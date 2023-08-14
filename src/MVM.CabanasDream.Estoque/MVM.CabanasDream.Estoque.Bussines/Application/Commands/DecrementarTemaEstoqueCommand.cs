using MVM.CabanasDream.Core.Domain.DomainEvents;

namespace MVM.CabanasDream.Estoque.API.Application.Commands;

public class DecrementarTemaEstoqueCommand : Command
{
    public DecrementarTemaEstoqueCommand(Guid temaId, int? valor)
    {
        TemaId = temaId;
        Valor = valor;
    }

    public DecrementarTemaEstoqueCommand()
    {
    }

    public Guid TemaId { get; set; }
    public int? Valor { get; set; }
}

