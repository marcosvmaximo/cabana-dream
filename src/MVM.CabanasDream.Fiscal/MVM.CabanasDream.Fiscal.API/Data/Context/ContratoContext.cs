using Microsoft.EntityFrameworkCore;
using MVM.CabanasDream.Core.Data.Interfaces;
using MVM.CabanasDream.Fiscal.API.Models;

namespace MVM.CabanasDream.Fiscal.API.Data.Context;

public class ContratoContext : DbContext, IUnityOfWork
{
    public ContratoContext(DbContextOptions<ContratoContext> options) : base(options)
    {
    }

    public DbSet<Contrato> Contratos { get; set; }

    public async Task<bool> Commit()
    {

    }
}

