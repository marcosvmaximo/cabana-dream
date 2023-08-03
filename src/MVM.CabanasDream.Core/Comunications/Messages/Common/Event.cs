using MediatR;

namespace MVM.CabanasDream.Core.Domain.DomainEvents.Common;

public abstract class Event : Message, INotification
{
    public DateTime TimeStamp { get; protected set; }

    public Event()
    {
        TimeStamp = DateTime.Now;
    }
}