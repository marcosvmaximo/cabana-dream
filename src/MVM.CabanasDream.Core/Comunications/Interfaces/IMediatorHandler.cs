using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Core.Domain.DomainEvents.Common;
using MVM.CabanasDream.Core.Domain.Models;

namespace MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;

public interface IMediatorHandler
{
    Task PublicarEvento<T>(T evento) where T : Event;
    Task<BaseResult> EnviarComando<TRequest>(TRequest command) where TRequest : Command;
    Task PublicarNotificacao<T>(T notification) where T : DomainNotification;
}

