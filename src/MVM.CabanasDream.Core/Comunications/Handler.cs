using MediatR;
using MVM.CabanasDream.Core.Domain.Models;

namespace MVM.CabanasDream.Core.Domain.DomainEvents.Handlers;

public abstract class Handler<TRequest> : IRequestHandler<TRequest, BaseResult>
    where TRequest : Command
{
    public abstract Task<BaseResult> Handle(TRequest command, CancellationToken cancellationToken);

    protected internal virtual bool ValidarComando(TRequest command)
    {
        throw new NotImplementedException();
    }
}

