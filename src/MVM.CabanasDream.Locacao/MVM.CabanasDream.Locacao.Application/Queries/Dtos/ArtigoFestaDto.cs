using System;
using MVM.CabanasDream.Locacao.Domain.Entities;

namespace MVM.CabanasDream.Locacao.Application.Queries.Dtos;

public class ArtigoFestaDto
{
    public ArtigoFestaDto()
    {
    }

    public ArtigoFestaDto(string nome, decimal valor, int quantidade)
    {
        Nome = nome;
        Valor = valor;
        Quantidade = quantidade;
    }

    public string? Nome { get; set; }
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }

    public class Factory
    {
        public static IEnumerable<ArtigoFestaDto> Create(IEnumerable<ArtigoFesta> artigosExtras)
        {
            foreach (var artigo in artigosExtras)
            {
                yield return new ArtigoFestaDto(artigo.Nome, artigo.Valor, artigo.Quantidade);
            }
        }
    }
}

