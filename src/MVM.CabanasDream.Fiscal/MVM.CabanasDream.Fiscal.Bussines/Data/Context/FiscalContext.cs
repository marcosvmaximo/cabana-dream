using Microsoft.EntityFrameworkCore;
using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Core.Data;
using MVM.CabanasDream.Core.Data.Interfaces;
using MVM.CabanasDream.Core.Domain.DomainEvents.Common;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Fiscal.API.Models;
using MVM.CabanasDream.Fiscal.API.Models.Entities;

namespace MVM.CabanasDream.Fiscal.API.Data.Context;

public class FiscalContext : DbContext, IUnityOfWork
{
    private readonly IMediatorHandler _mediator;

    public FiscalContext(DbContextOptions<FiscalContext> opt, IMediatorHandler mediator) : base(opt)
    {
        _mediator = mediator;
    }

    public DbSet<Festa> Festas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Contrato> Contratos { get; set; }

    public async Task<bool> Commit()
    {
        var result = await SaveChangesAsync() > 0;

        // Serão processados após a persistencia
        if (result)
        {
            await _mediator.PublishEvents(this);
        }
        else
        {
            await _mediator.PublicarNotificacao(
                new DomainNotification("Evento", "Falha ao salvar a entidade, eventos não foram enviados."));
        }

        return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FiscalContext).Assembly);

        modelBuilder.Ignore<Event>();

        base.OnModelCreating(modelBuilder);
    }
}

