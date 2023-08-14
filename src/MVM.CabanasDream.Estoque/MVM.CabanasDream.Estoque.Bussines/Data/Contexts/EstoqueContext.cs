using System;
using Microsoft.EntityFrameworkCore;
using MVM.CabanasDream.Estoque.API.Models;

namespace MVM.CabanasDream.Estoque.API.Data.Contexts;

public class EstoqueContext : DbContext
{
    public EstoqueContext(DbContextOptions<EstoqueContext> opt) : base(opt)
    {
    }

    public DbSet<Tema> Temas { get; set; }
    public DbSet<ArtigoFesta> ArtigoFestas { get; set; }
}

