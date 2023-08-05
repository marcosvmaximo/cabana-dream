using System;
using Microsoft.EntityFrameworkCore;
using MVM.CabanasDream.Fiscal.Domain;

namespace MVM.CabanasDream.Fiscal.Data.Context;

public class ContratoContext : DbContext
{
    public ContratoContext(DbContextOptions<ContratoContext> options) : base(options)
    {
    }

    public DbSet<Contrato> Contratos { get; set; }
}

