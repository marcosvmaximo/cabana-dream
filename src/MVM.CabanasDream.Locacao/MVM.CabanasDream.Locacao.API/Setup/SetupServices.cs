using System;
using MediatR;
using MVM.CabanasDream.Core.Comunications;
using MVM.CabanasDream.Core.Comunications.Interfaces;
using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Locacao.Application.Commands;
using MVM.CabanasDream.Locacao.Data.Context;
using MVM.CabanasDream.Locacao.Data.Repositories;
using MVM.CabanasDream.Locacao.Domain.Repositories;
using MVM.CabanasDream.Locacao.Domain.Services;
using MVM.CabanasDream.Locacao.Domain.Services.Interfaces;

namespace MVM.CabanasDream.Locacao.API.Setup;

public static class SetupServices
{
    public static void RegisterServices(this IServiceCollection services)
    {
        // Bus (MediatR)
        services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(CriarFestaCommand).Assembly));
        services.AddScoped<IMediatrHandler, MediatrHandler>();

        // Notifications
        //services.AddSingleton<IDomainNotificationHandler, DomainNotificationHandler>();
        services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

        // Services
        services.AddTransient<IFestaRepository, FestaRepository>();
        services.AddTransient<ILocacaoService, LocacaoService>();

        services.AddScoped<FestaContext>();
    }
}

