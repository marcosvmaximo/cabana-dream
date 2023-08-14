using MVM.CabanasDream.Core.Domain.Models;
using MVM.CabanasDream.Estoque.API.Models.Common;

namespace MVM.CabanasDream.Estoque.API.Models;

public class Tema : Entity, IAggregateRoot, IEstoque
{
    private IList<ArtigoFesta> _artigosFestas;

    public Tema(string nome, int quantidadeEstoque)
    {
        Nome = nome;
        QuantidadeEstoque = quantidadeEstoque;
        _artigosFestas = new List<ArtigoFesta>();
    }

    protected Tema() { }

    public string Nome { get; private set; }
    public int QuantidadeEstoque { get; private set; }
    public IReadOnlyCollection<ArtigoFesta> ArtigoFestas => _artigosFestas.ToList();

    // Retiram/Adicionam artigos padrões do Tema
    public void AdicionarArtigoFesta(ArtigoFesta artigoFesta) => _artigosFestas.Add(artigoFesta);
    public void RemoverArtigoFesta(ArtigoFesta artigoFesta) => _artigosFestas.Remove(artigoFesta);

    // Alterar estoque de temas
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

