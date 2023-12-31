﻿using Microsoft.EntityFrameworkCore;
using MVM.CabanasDream.Core;
using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Core.Data.Interfaces;
using MVM.CabanasDream.Core.Domain.DomainEvents.Common;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Locacao.Domain;
using MVM.CabanasDream.Locacao.Domain.Entities;
using MVM.CabanasDream.Core.Data;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers;

namespace MVM.CabanasDream.Locacao.Data.Context;

public class FestaContext : DbContext, IUnityOfWork
{
    private readonly IMediatorHandler _mediator;

    public FestaContext(DbContextOptions<FestaContext> opt, IMediatorHandler mediator) : base(opt)
    {
        _mediator = mediator;
    }

    public DbSet<ArtigoFesta> ArtigosDeFestas { get; set; }
    public DbSet<Festa> Festas { get; set; }
    public DbSet<Tema> Temas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }

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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FestaContext).Assembly);

        modelBuilder.Ignore<Event>();

        base.OnModelCreating(modelBuilder);
    }
}

