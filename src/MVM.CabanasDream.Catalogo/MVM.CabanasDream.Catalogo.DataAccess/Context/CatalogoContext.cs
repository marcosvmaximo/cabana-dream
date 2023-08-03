using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MVM.CabanasDream.BussinesLogic.Models;
using MVM.CabanasDream.Core.Data.Interfaces;
using MVM.CabanasDream.Core.Domain.DomainEvents.Common;

namespace MVM.CabanasDream.DataAccess.Context;

public class CatalogoContext : DbContext, IUnityOfWork
{
    public CatalogoContext(DbContextOptions<CatalogoContext> opt) : base(opt)
    {
    }

    public DbSet<Tema> Temas { get; set; }
    public DbSet<Item> Items { get; set; }

    public async Task<bool> Commit()
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCriacao") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("DataCriacao").CurrentValue = DateTime.Now.ToUniversalTime();
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("DataCriacao").IsModified = false;
            }
        }

        return await SaveChangesAsync() > 0;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
        modelBuilder.Ignore<Event>();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.ConfigureWarnings(warnings =>
        {
            warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored);
        });
    }
}

