using System;
namespace MVM.CabanasDream.Estoque.API.Models.Common;

public interface IEstoque
{
    void DiminuirEstoque(int? valor = null);
    void AdicionarEstoque(int? valor = null);
}

