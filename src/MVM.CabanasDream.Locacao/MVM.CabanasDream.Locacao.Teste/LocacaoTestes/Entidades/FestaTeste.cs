using System;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.Domain.ValueObjects;
using MVM.CabanasDream.Core.Domain.ValueObjects.Enum;
using MVM.CabanasDream.Locacao.Domain;
using MVM.CabanasDream.Locacao.Domain.Entities;
using MVM.CabanasDream.Locacao.Domain.ValueObjects;

namespace MVM.CabanasDream.Locacao.Teste.LocacaoTestes;

public class FestaTeste
{
    private readonly Tema _tema;
    private readonly Cliente _cliente;
    public readonly Festa _festaValida;

    public FestaTeste()
    {
        _tema = CriarTemaValido();
        _cliente = CriarClienteValido();
        _festaValida = new Festa(CriarTemaValido(), CriarClienteValido(), 100, DateTime.Now.AddHours(2));
    }

    public static Tema CriarTemaValido()
    {
        return new Tema("Neon", 10);
    }

    public static Cliente CriarClienteValido()
    {
        return new Cliente(
            "Marcos V Maximo",
            new DateTime(2023, 02, 11),
            new Documento(EDocumento.CPF, "16645092304", new DateTime(2015, 01, 01)),
            new Contato("contato@mail.com", "41", "987302321"),
            new Endereco("81840580", "Rua Maria Costa", 14, "Xaxim", "Curitiba", "PR"));
    }

    [Fact]
    public void DeveCriarFestaComSucesso()
    {
        var sucess = true;

        try
        {
            var tema = CriarTemaValido();
            var cliente = CriarClienteValido();
            var festa = new Festa(tema, cliente, 100, DateTime.Now.AddHours(2));
        }
        catch (DomainException ex)
        {
            sucess = false;
        }

        Assert.True(sucess);
    }

    [Fact]
    public void DeveFalharAoCancelarUmaFestaQueJaFoiRealizada()
    {
        Assert.Throws<DomainException>(() =>
        {
            _festaValida.FinalizarFesta();
            _festaValida.CancelarFesta();
        });
    }

    [Fact]
    public void DeveFalharAoCancelarUmaFestaInvalida()
    {
        Assert.Throws<DomainException>(() =>
        {
            var festa = new Festa(_tema, _cliente, 100, new DateTime(2010, 01, 01));
            _festaValida.CancelarFesta();
        });
    }

    [Fact]
    public void DeveFalharAoAdicionarItemExtraNulo()
    {
        Assert.Throws<DomainException>(() =>
        {
            _festaValida.AdicionarItemDeFestaExtra(null);
        });
    }

    [Fact]
    public void DeveFalharAoAdicionarItemExtraComFestaFinalizada()
    {
        Assert.Throws<DomainException>(() =>
        {
            _festaValida.FinalizarFesta();
            _festaValida.AdicionarItemDeFestaExtra(new ItemDeFesta());
        });
    }


    [Fact]
    public void DeveFalharAoAdicionarItemExtraComFestaEmAndamento()
    {
        Assert.Throws<DomainException>(() =>
        {
            _festaValida.ConfirmarFesta();
            _festaValida.AdicionarItemDeFestaExtra(new ItemDeFesta());
        });
    }

    [Fact]
    public void DeveInserirItemExtraComSucessoEmUmaFestaValida()
    {
        var sucess = true;

        try
        {
            _festaValida.AdicionarItemDeFestaExtra(new ItemDeFesta());
        }
        catch (DomainException ex)
        {
            sucess = false;
        }

        Assert.True(sucess);
    }
}

