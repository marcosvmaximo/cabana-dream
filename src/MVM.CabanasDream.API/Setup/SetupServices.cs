using MediatR;
using MVM.CabanasDream.Core.Comunications;
using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Locacao.DependencyInjection;
using MVM.CabanasDream.Fiscal.Bussines;

namespace MVM.CabanasDream.API.Setup;

public static class SetupServices
{
    public static void RegisterServices(this IServiceCollection services, string connectionString)
    {
        // Bus (MediatR)
        services.AddScoped<IMediatorHandler, MediatorHandler>();


        // Notifications
        //services.AddSingleton<IDomainNotificationHandler, DomainNotificationHandler>();
        services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

        services.RegisterServicesLocacao(connectionString);
        services.RegisterServicesFiscal(connectionString);
    }
}

