using System;
namespace MVM.CabanasDream.Core.Domain.DomainEvents.Common;

public abstract class Message
{
    public Guid AggregrateId { get; protected set; }
    public string MessageType { get; protected set; }

    public Message()
    {
        MessageType = GetType().Name;
    }

}