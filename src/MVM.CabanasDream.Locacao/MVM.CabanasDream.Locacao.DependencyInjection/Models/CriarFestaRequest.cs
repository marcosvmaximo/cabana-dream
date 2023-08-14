using System;
using MVM.CabanasDream.Locacao.Application.Commands;

namespace MVM.CabanasDream.API.Models;

public class CriarFestaRequest
{
    public CriarFestaRequest()
    {
    }

    public Guid ClienteId { get; set; }
    public Guid TemaId { get; set; }
    public int QuantidadeParticipantes { get; set; }
    public DateTime DataRealizacao { get; set; }
    public List<ArtigoDeFestaCommand?> ItemsExtras { get; set; }
}

