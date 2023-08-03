using MVM.CabanasDream.Core.Domain.DomainEvents;
using MVM.CabanasDream.Locacao.Application.Validations;

namespace MVM.CabanasDream.Locacao.Application.Commands;

public class CriarFestaCommand : Command
{
    public Guid ClienteId { get; set; }
    public Guid TemaId { get; set; }
    public int QuantidadeParticipantes { get; set; }
    public DateTime DataRealizacao { get; set; }
    public List<PedidoItemDeFestaExtraCommand?> ItemsExtras { get; set; }

    public CriarFestaCommand()
    {
    }

    public CriarFestaCommand(Guid clienteId, Guid temaId, int quantidadeParticipantes, DateTime dataRealizacao, List<PedidoItemDeFestaExtraCommand?> itemsExtras)
    {
        ClienteId = clienteId;
        TemaId = temaId;
        QuantidadeParticipantes = quantidadeParticipantes;
        DataRealizacao = dataRealizacao;
        ItemsExtras = itemsExtras;
    }

    public override bool EhValido()
    {
        ValidationResult = new CriarFestaValidator().Validate(this);
        return ValidationResult.IsValid;
    }
}

public class PedidoItemDeFestaExtraCommand
{
    public string Nome { get; set; }
    public int Quantidade { get; set; }
}