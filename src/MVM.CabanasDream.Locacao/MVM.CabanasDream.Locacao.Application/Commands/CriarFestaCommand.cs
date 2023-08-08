using MVM.CabanasDream.Core.Domain.DomainEvents;
using MVM.CabanasDream.Locacao.Application.Validations;

namespace MVM.CabanasDream.Locacao.Application.Commands;

public class CriarFestaCommand : Command
{
    public CriarFestaCommand()
    {
    }

    public CriarFestaCommand(Guid clienteId, Guid temaId, int quantidadeParticipantes, DateTime dataRealizacao, List<ArtigoDeFestaCommand?> itemsExtras)
    {
        ClienteId = clienteId;
        TemaId = temaId;
        QuantidadeParticipantes = quantidadeParticipantes;
        DataRealizacao = dataRealizacao;
        ArtigosDeFesta = itemsExtras;
    }

    public Guid ClienteId { get; set; }
    public Guid TemaId { get; set; }
    public int QuantidadeParticipantes { get; set; }
    public DateTime DataRealizacao { get; set; }
    public List<ArtigoDeFestaCommand?> ArtigosDeFesta { get; set; }

    public override bool EhValido()
    {
        ValidationResult = new CriarFestaValidator().Validate(this);
        return ValidationResult.IsValid;
    }
}

public class ArtigoDeFestaCommand
{
    public string Nome { get; set; }
    public decimal ValorExtra { get; set; }
    public int Quantidade { get; set; }
}