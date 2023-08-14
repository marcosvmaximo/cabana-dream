using System;
using Microsoft.EntityFrameworkCore;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Core.Domain.Models;

namespace MVM.CabanasDream.Core.Data;

public static class MediatorExtensions
{
    public static async Task PublishEvents<TContext>(this IMediatorHandler mediator, TContext context)
        where TContext : DbContext
    {
        // Busco as entidades <entity> no change tracker, onde sejam diferentes de nulas e possuam itens em sua lista.
        var domainEntities = context.ChangeTracker.Entries<Entity>()
            .Where(x => x.Entity.Events != null && x.Entity.Events.Any());

        // Seleciono os eventos.
        var domainEvents = domainEntities.SelectMany(x => x.Entity.Events).ToList();

        // Limpo a lista de eventos da entidade
        domainEntities.ToList().ForEach(x => x.Entity.LimparEventos());

        // Publicar cada evento.
        var tasks = domainEvents.Select(async @event => await mediator.PublicarEvento(@event));

        await Task.WhenAll(tasks);
    }
}

