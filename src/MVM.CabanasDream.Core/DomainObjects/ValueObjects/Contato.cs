using System.Text.RegularExpressions;
using MVM.CabanasDream.Core.Domain.AssertionConcern;
using MVM.CabanasDream.Core.Domain.Models;

namespace MVM.CabanasDream.Core.Domain.ValueObjects;

public class Contato : ValueObject
{
    public Contato(string email, string ddd, string telefone)
    {
        Email = email;
        Ddd = ddd;
        Telefone = telefone;

        Validar();
    }

    public string Email { get; private set; }
    public string Ddd { get; private set; }
    public string Telefone { get; private set; }

    public override void Validar()
    {
        Assertion.ValidarSeFalso(IsValidDdd(Ddd), "O Ddd informado não é valido");
        Assertion.ValidarSeFalso(IsValidTelefone(Telefone), "O Telefone informado não é valido");
        Assertion.ValidarSeFalso(IsValidEmail(Email), "O Email informado não é valido");
    }

    private bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || email.Length > 255)
        {
            return false;
        }

        return Regex.IsMatch(email, @"^[\w\.-]+@[\w\.-]+\.\w+$");
    }

    private bool IsValidDdd(string ddd)
    {
        // Lista de DDDs válidos no Brasil
        string[] validDdds = { "11", "12", "13", "14", "15", "16", "17", "18", "19", "21", "22", "24", "27", "28", "31", "32", "33", "34", "35", "37", "38", "41", "42", "43", "44", "45", "46", "47", "48", "49", "51", "53", "54", "55", "61", "62", "63", "64", "65", "66", "67", "68", "69", "71", "73", "74", "75", "77", "79", "81", "82", "83", "84", "85", "86", "87", "88", "89", "91", "92", "93", "94", "95", "96", "97", "98", "99" };

        if (string.IsNullOrWhiteSpace(ddd) || ddd.Length != 2 || !validDdds.Contains(ddd))
        {
            return false;
        }

        return true;
    }

    private bool IsValidTelefone(string telefone)
    {
        if (string.IsNullOrWhiteSpace(telefone) || telefone.Length != 9 || !telefone.All(char.IsDigit))
        {
            return false;
        }

        return true;
    }
}
