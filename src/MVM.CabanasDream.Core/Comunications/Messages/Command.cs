using System;
using FluentValidation.Results;
using MediatR;
using MVM.CabanasDream.Core.Domain.DomainEvents.Common;
using MVM.CabanasDream.Core.Domain.Results;

namespace MVM.CabanasDream.Core.Domain.DomainEvents;

public abstract class Command : Message, IRequest<BaseResult>
{
    protected DateTime DateDispartch { get; private set; }
    public ValidationResult ValidationResult { get; protected set; }

    public Command()
    {
        DateDispartch = DateTime.Now;
    }


    public virtual bool EhValido() => throw new NotImplementedException();
}

