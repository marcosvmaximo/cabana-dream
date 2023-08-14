using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVM.CabanasDream.API.Setup.Mappers;
using MVM.CabanasDream.Core.Comunications;
using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Locacao.Application.Commands;
using MVM.CabanasDream.Locacao.Data.Context;
using MVM.CabanasDream.Locacao.Data.Repositories;
using MVM.CabanasDream.Locacao.Domain.Repositories;
using MVM.CabanasDream.Locacao.Domain.Services;
using MVM.CabanasDream.Locacao.Domain.Services.Interfaces;

namespace MVM.CabanasDream.Locacao.DependencyInjection;
public static class ServicesExtesion
{
    public static void RegisterServicesLocacao(this IServiceCollection services, string connectionString)
    {
        // Mapper
        services.AddAutoMapper(typeof(FestaProfile));

        // Bus (MediatR)
        services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(CriarFestaCommand).Assembly));
        //services.AddScoped<IMediatrHandler, MediatrHandler>();

        // Services
        services.AddTransient<IFestaRepository, FestaRepository>();
        services.AddTransient<ILocacaoService, LocacaoService>();

        // Contexto
        services.AddDbContext<FestaContext>(opt => opt.UseNpgsql(connectionString));

        services.AddScoped<FestaContext>();
    }
}

