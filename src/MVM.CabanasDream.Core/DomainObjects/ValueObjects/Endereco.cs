using MVM.CabanasDream.Core.Domain.AssertionConcern;
using MVM.CabanasDream.Core.Domain.Models;

namespace MVM.CabanasDream.Core.Domain.ValueObjects;

public class Endereco : ValueObject
{
    public Endereco(string cep, string logradouro, int numero, string bairro, string cidade, string unidadeFederativa)
    {
        Cep = cep;
        Logradouro = logradouro;
        Numero = numero;
        Bairro = bairro;
        Cidade = cidade;
        UnidadeFederativa = unidadeFederativa;

        Validar();
    }


    public string Cep { get; private set; }
    public string Logradouro { get; private set; }
    public int Numero { get; private set; }
    public string Bairro { get; private set; }
    public string Cidade { get; private set; }
    public string UnidadeFederativa { get; private set; }

    public override void Validar()
    {
        Assertion.ValidarSeNulo(Cep, "O campo CEP não pode ser nulo ou vazio");
        Assertion.ValidarSeIgual(Cep.Trim(), string.Empty, "O campo CEP não pode ser nulo ou vazio");
        Assertion.ValidarValorMinimoMaximo(Cep.Length, 8, 8, $"O campo CEP deve ter exatamente {8} caracteres");

        Assertion.ValidarSeNulo(Logradouro, "O campo Logradouro não pode ser nulo ou vazio");
        Assertion.ValidarSeIgual(Logradouro.Trim(), string.Empty, "O campo Logradouro não pode ser nulo ou vazio");
        Assertion.ValidarValorMinimoMaximo(Logradouro.Length, 0, 100, $"O campo Logradouro deve ter no máximo {100} caracteres");

        Assertion.ValidarSeMenorQue(Numero, 1, "O campo Número deve ser maior que zero");

        Assertion.ValidarSeNulo(Bairro, "O campo Bairro não pode ser nulo ou vazio");
        Assertion.ValidarSeIgual(Bairro.Trim(), string.Empty, "O campo Bairro não pode ser nulo ou vazio");
        Assertion.ValidarValorMinimoMaximo(Bairro.Length, 0, 100, $"O campo Bairro deve ter no máximo {100} caracteres");

        Assertion.ValidarSeNulo(Cidade, "O campo Cidade não pode ser nulo ou vazio");
        Assertion.ValidarSeIgual(Cidade.Trim(), string.Empty, "O campo Cidade não pode ser nulo ou vazio");
        Assertion.ValidarValorMinimoMaximo(Cidade.Length, 0, 100, $"O campo Cidade deve ter no máximo {100} caracteres");

        Assertion.ValidarSeNulo(UnidadeFederativa, "O campo Unidade Federativa não pode ser nulo ou vazio");

        Assertion.ValidarValorMinimoMaximo(UnidadeFederativa.Length, 2, 2, $"O campo Unidade Federativa deve ter exatamente {2} caracteres");
    }
}

