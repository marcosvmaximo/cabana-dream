using System;
using System.Text.RegularExpressions;
using MVM.CabanasDream.Core.Domain.Exceptions;

namespace MVM.CabanasDream.Core.Domain.AssertionConcern;

public static class Assertion
{
    public static void ValidarSeIgual(object obj1, object obj2, string message)
    {
        if (obj1.Equals(obj2))
        {
            throw new DomainException(message);
        }
    }

    public static void ValidarSeDiferente(object obj1, object obj2, string message)
    {
        if (!obj1.Equals(obj2))
        {
            throw new DomainException(message);
        }
    }

    public static void ValidarTamanhoCaracteres(string valor, int maximo, string message)
    {
        var length = valor.Trim().Length;
        if (length > maximo)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidarTamanhoCaracteres(string valor, int minimo, int maximo, string message)
    {
        var length = valor.Trim().Length;
        if (length < minimo || length > maximo)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidarExpressao(string expressao, string valor, string message)
    {
        var regex = new Regex(expressao);

        if (regex.IsMatch(valor))
        {
            throw new DomainException(message);
        }
    }

    public static void ValidarSeVazio(string valor, string message)
    {
        if (string.IsNullOrWhiteSpace(valor))
        {
            throw new DomainException(message);
        }
    }

    public static void ValidarSeNulo(object obj, string message)
    {
        if (obj == null)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidarValorMinimoMaximo(int valor, int valorMinimo, int valorMaximo, string message)
    {
        if (valor < valorMinimo || valor > valorMaximo)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidarValorMinimoMaximo(double valor, double valorMinimo, double valorMaximo, string message)
    {
        if (valor < valorMinimo || valor > valorMaximo)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidarValorMinimoMaximo(float valor, float valorMinimo, float valorMaximo, string message)
    {
        if (valor < valorMinimo || valor > valorMaximo)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidarValorMinimoMaximo(decimal valor, decimal valorMinimo, decimal valorMaximo, string message)
    {
        if (valor < valorMinimo || valor > valorMaximo)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidarValorMinimoMaximo(long valor, long valorMinimo, long valorMaximo, string message)
    {
        if (valor < valorMinimo || valor > valorMaximo)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidarSeMenorQue(int valor, int valorMinimo, string message)
    {
        if (valor < valorMinimo)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidarSeMenorQue(double valor, double valorMinimo, string message)
    {
        if (valor < valorMinimo)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidarSeMenorQue(float valor, float valorMinimo, string message)
    {
        if (valor < valorMinimo)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidarSeMenorQue(decimal valor, decimal valorMinimo, string message)
    {
        if (valor < valorMinimo)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidarSeMenorQue(long valor, long valorMinimo, string message)
    {
        if (valor < valorMinimo)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidarSeFalso(bool valor, string message)
    {
        if (!valor)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidarSeVerdadeiro(bool valor, string message)
    {
        if (valor)
        {
            throw new DomainException(message);
        }
    }
}
