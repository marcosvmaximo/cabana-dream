//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using MVM.CabanasDream.Locacao.Data.Context;

//namespace MVM.CabanasDream.Locacao.Data;

//public class FestaContextFactory : IDesignTimeDbContextFactory<FestaContext>
//{
//    public FestaContext CreateDbContext(string[] args)
//    {
//        var optionsBuilder = new DbContextOptionsBuilder<FestaContext>();
//        optionsBuilder.UseNpgsql("Host=localhost;Port=5434;Database=postgres;" +
//            "Username=postgres;Password=8837;");

//        return new FestaContext(optionsBuilder.Options);
//    }
//}

