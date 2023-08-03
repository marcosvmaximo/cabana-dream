using System;
using MediatR;
using MVM.CabanasDream.Core.Comunications.Messages;

namespace MVM.CabanasDream.Core.Comunications.Interfaces;

public interface IDomainNotificationHandler
{
    List<DomainNotification> ObterNotificacoes();
    bool PossuiNotificacoes();
}

