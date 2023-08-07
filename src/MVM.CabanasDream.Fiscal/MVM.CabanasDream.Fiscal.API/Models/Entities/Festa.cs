using System;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.Domain.Models;
using MVM.CabanasDream.Fiscal.API.Models.Enum;

namespace MVM.CabanasDream.Fiscal.API.Models.Entities;
public class Festa : Entity
{
    public Festa(int quantidadeParticipantes,
                 int quantidadeArtigosDeFestasExtra,
                 EStatusFesta status,
                 DateTime dataRealizacao,
                 Guid? contratoId)
    {
        QuantidadeParticipantes = quantidadeParticipantes;
        QuantidadeArtigosDeFestasExtra = quantidadeArtigosDeFestasExtra;
        Status = status;
        DataRealizacao = dataRealizacao;
        ContratoId = contratoId;
    }

    protected Festa() { }

    public int QuantidadeParticipantes { get; private set; }
    public int QuantidadeArtigosDeFestasExtra { get; private set; }
    public EStatusFesta Status { get; private set; }
    public DateTime DataRealizacao { get; private set; }
    public Contrato Contrato { get; private set; }
    public Guid? ContratoId { get; private set; }

    public void ConfirmarFesta() => Status = EStatusFesta.AguardandoPagamento;

    public void AdicionarContrato(Contrato contrato)
    {
        if (contrato == null)
            throw new DomainException("Contrato inválido, não pode ser nulo.");

        if (contrato.DataDevolucao <= DateTime.Now)
            throw new DomainException("Contrato inválido, não deve possuir uma data de devolução menor que a data atual.");

        ConfirmarFesta();
        Contrato = contrato;
        ContratoId = contrato.Id;
    }

    public override void Validar()
    {
        throw new NotImplementedException();
    }
}

