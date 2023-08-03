using MVM.CabanasDream.Core.Domain.AssertionConcern;
using MVM.CabanasDream.Core.Domain.Models;
using MVM.CabanasDream.Core.Domain.ValueObjects.Enum;

namespace MVM.CabanasDream.Core.Domain.ValueObjects;

public class Documento : ValueObject
{
    public Documento(EDocumento tipo, string numero, DateTime dataEmissao)
    {
        Tipo = tipo;
        Numero = numero;
        DataEmissao = dataEmissao;

        Validar();
    }

    public EDocumento Tipo { get; private set; }
    public string Numero { get; private set; }
    public DateTime DataEmissao { get; private set; }

    public override void Validar()
    {
        var numero = Numero.Trim()
            .Replace(".", "")
            .Replace("-", "")
            .Replace("'", "")
            .Replace(" ", "");

        if (Tipo == EDocumento.CNH)
        {
            Assertion.ValidarValorMinimoMaximo(numero.Count(), 11, 15, "Numero de documento inválido");
        }

        if (Tipo == EDocumento.CPF)
            Assertion.ValidarSeDiferente(numero.Count(), 11, "Numero de documento inválido");

        if (Tipo == EDocumento.RG)
            Assertion.ValidarValorMinimoMaximo(numero.Count(), 9, 15, "Numero de documento inválido");

        Assertion.ValidarSeNulo(Numero, "O campo {0} não pode conter valores nulos");
        Assertion.ValidarSeIgual(DataEmissao, DateTime.MinValue, "Data de emissão do documento inválida");
    }
}

