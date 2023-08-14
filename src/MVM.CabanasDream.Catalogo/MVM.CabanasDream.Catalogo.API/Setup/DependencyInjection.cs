//using System;
//using MVM.CabanasDream.BussinesLogic.Repositories;
//using MVM.CabanasDream.BussinesLogic.Services;
//using MVM.CabanasDream.BussinesLogic.Services.Interfaces;
//using MVM.CabanasDream.DataAccess.Context;
//using MVM.CabanasDream.DataAccess.Repositories;

//namespace MVM.CabanasDream.API.Setup;

//public static class DependencyInjection
//{
//    public static void AddServices(this IServiceCollection services)
//    {
//        services.AddScoped<CatalogoContext>();

//        //services.AddTransient<IEstoqueService, EstoqueService>();
//        services.AddTransient<ICatalogoService, CatalogoService>();

//        // Repositories
//        //services.AddTransient<IItemRepository, ItemRepository>();
//        services.AddTransient<ITemaRepository, TemaRepository>();
//    }
//}

