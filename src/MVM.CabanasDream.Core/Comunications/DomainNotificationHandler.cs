using MediatR;
using MVM.CabanasDream.Core.Comunications.Interfaces;
using MVM.CabanasDream.Core.Comunications.Messages;

namespace MVM.CabanasDream.Core.Comunications;

public class DomainNotificationHandler : IDomainNotificationHandler, INotificationHandler<DomainNotification>
{
    private List<DomainNotification> _notifications;

    public DomainNotificationHandler()
    {
        _notifications = new List<DomainNotification>();
    }

    public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
    {
        _notifications.Add(notification);
        return Task.CompletedTask;
    }

    public virtual List<DomainNotification> ObterNotificacoes()
    {
        return _notifications;
    }

    public virtual bool PossuiNotificacoes()
    {
        return _notifications.Any();
    }

    public void Dispose()
    {
        _notifications = new List<DomainNotification>();
    }
}
