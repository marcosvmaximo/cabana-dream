using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVM.CabanasDream.Core.Comunications;
using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Fiscal.API.Data.Context;
using MVM.CabanasDream.Fiscal.API.Data.Repositories;
using MVM.CabanasDream.Fiscal.API.Interfaces;
using MVM.CabanasDream.Fiscal.API.Models;
using MVM.CabanasDream.Fiscal.API.Services;

namespace MVM.CabanasDream.Fiscal.Bussines;
public static partial class ServicesExtesion
{
    public static void RegisterServicesFiscal(this IServiceCollection services, string connectionString)
    {
        // Mediator
        services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(Contrato).Assembly));

        // Services
        services.AddTransient<IContratoRepository, ContratoRepository>();
        services.AddTransient<IFiscalService, FiscalService>();

        // Contexto
        services.AddDbContext<FiscalContext>(opt => opt.UseNpgsql(connectionString));

        services.AddScoped<FiscalContext>();
    }
}
