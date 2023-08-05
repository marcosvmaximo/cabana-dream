using MVM.CabanasDream.Locacao.Domain.Enum;

namespace MVM.CabanasDream.Locacao.Application.Queries.Dtos;

public class FestaDto
{
    public FestaDto()
    {
    }

    public FestaDto(Guid temaId, Guid clienteId, int quantidadeParticipantes, EStatusFesta status, DateTime dataRealizacao, Guid? contratoId, IEnumerable<ArtigoFestaDto> itensExtras)
    {
        TemaId = temaId;
        ClienteId = clienteId;
        QuantidadeParticipantes = quantidadeParticipantes;
        Status = status;
        DataRealizacao = dataRealizacao;
        ContratoId = contratoId;
        ArtigosDeFesta = itensExtras;
    }

    public Guid TemaId { get; set; }
    public Guid ClienteId { get; set; }
    public int QuantidadeParticipantes { get; set; }
    public EStatusFesta Status { get; set; }
    public DateTime DataRealizacao { get; set; }
    public Guid? ContratoId { get; set; }
    public IEnumerable<ArtigoFestaDto> ArtigosDeFesta { get; set; }
}

