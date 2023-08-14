using System;
using System.Drawing;
using MVM.CabanasDream.Core.Domain.Models;
using MVM.CabanasDream.Estoque.API.Models.Common;

namespace MVM.CabanasDream.Estoque.API.Models;

public class ArtigoFesta : Entity, IEstoque
{
    public ArtigoFesta(string nome, int quantidadeEstoque, Guid temaId)
    {
        Nome = nome;
        QuantidadeEstoque = quantidadeEstoque;
        TemaId = temaId;
    }

    protected ArtigoFesta() { }

    public string Nome { get; private set; }
    public int QuantidadeEstoque { get; private set; }
    public Guid TemaId { get; private set; }

    // Ef Rel...
    public Tema Tema { get; private set; }

    // Controles de estoques

    public void DiminuirEstoque(int? valor = null)
    {
        if (!valor.HasValue || valor is 0)
            QuantidadeEstoque--;
        else
            QuantidadeEstoque -= valor.Value;
    }

    public void AdicionarEstoque(int? valor = null)
    {
        if (!valor.HasValue || valor is 0)
            QuantidadeEstoque++;
        else
            QuantidadeEstoque += valor.Value;
    }

    public override void Validar()
    {
        throw new NotImplementedException();
    }
}

