using System;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.Domain.Models;
using MVM.CabanasDream.Core.Domain.ValueObjects;

namespace MVM.CabanasDream.Fiscal.API.Models.Entities;

public class Cliente : Entity
{
    public IList<Contrato> _contratos;

    public Cliente(string nome, DateTime dataNascimento, Documento documento, Contato contato, Endereco endereco)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Documento = documento;
        Contato = contato;
        Endereco = endereco;

        _contratos = new List<Contrato>();
    }

    protected Cliente() { }

    public string Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public Documento Documento { get; private set; }
    public Contato Contato { get; private set; }
    public Endereco Endereco { get; private set; }
    public IReadOnlyCollection<Contrato> Contratos => _contratos.ToList();

    public void AdicionarContrato(Contrato contrato)
    {
        if (!contrato.Vigente)
            throw new DomainException("Não é possível adicionar um contrato que não esteja mais vigente.");

        if (contrato.DataDevolucao <= DateTime.Now)
            throw new DomainException("Não é possível adicionar um contrato que a Data de Devolução esteja no passado.");

        _contratos.Add(contrato);
    }

    public override void Validar()
    {
        throw new NotImplementedException();
    }
}

