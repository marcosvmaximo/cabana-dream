using MVM.CabanasDream.Core.Domain.AssertionConcern;
using MVM.CabanasDream.Core.Domain.Models;
using MVM.CabanasDream.Locacao.Domain.Events;
using MVM.CabanasDream.Locacao.Domain.Events.Temas;

namespace MVM.CabanasDream.Locacao.Domain.Entities;

public class Tema : Entity
{
    private readonly IList<ArtigoFesta> _itensDeFesta;
    private readonly IList<Festa> _festas;

    public Tema(string nome, int estoque)
    {
        Nome = nome;
        QuantidadeEstoque = estoque;
        Disponivel = true;
        _itensDeFesta = new List<ArtigoFesta>();
        _festas = new List<Festa>();

        Validar();
    }

    public string Nome { get; private set; }
    public int QuantidadeEstoque { get; private set; }
    public bool Disponivel { get; private set; }
    public IReadOnlyCollection<ArtigoFesta> ArtigosDeFesta => _itensDeFesta.ToList();
    public IReadOnlyCollection<Festa> Festas => _festas.ToList();

    public bool VerificarDisponibilidade()
    {
        if (QuantidadeEstoque > 0) return true;

        return false;
    }

    public void AdicionarFesta(Festa festa)
    {
        Assertion.ValidarSeNulo(festa, "Não é possível adicionar uma festa nula");

        _festas.Add(festa);
        DecrementarEstoque();
    }

    public void DecrementarEstoque()
    {
        QuantidadeEstoque--;

        if (QuantidadeEstoque < 1)
        {
            Indisponibilizar();
        }
    }

    public void IncrementarEstoque()
    {
        QuantidadeEstoque++;

        if (QuantidadeEstoque >= 1)
        {
            Disponibilizar();
        }
    }

    public void Indisponibilizar()
    {
        AdicionarEvento(new TemaIndisponivelEvent(Guid.Empty, Id, QuantidadeEstoque));
        Disponivel = false;
    }

    public void Disponibilizar()
    {
        AdicionarEvento(new TemaDisponivelEvent(Guid.Empty, Id, QuantidadeEstoque));
        Disponivel = true;
    }

    public override void Validar()
    {
        Assertion.ValidarSeNulo(Nome, "O campo {0} não deve ser nulo ou vazio");
        Assertion.ValidarSeVazio(Nome, "O campo {0} não deve ser nulo ou vazio");
        Assertion.ValidarSeMenorQue(QuantidadeEstoque, 1, "O campo {0} não deve ser menor que 1");
    }
}

