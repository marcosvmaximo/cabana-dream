using System;
using MVM.CabanasDream.Core.Domain.Interfaces;
using MVM.CabanasDream.Core.Domain.Models;

namespace MVM.CabanasDream.Pagamento.API.Models;

public class Pagamento : Entity, IAggregateRoot
{
    public Pagamento()
    {
    }

    public override void Validar()
    {
        throw new NotImplementedException();
    }
}

