using System;
using FluentValidation;
using MVM.CabanasDream.Locacao.Application.Commands;

namespace MVM.CabanasDream.Locacao.Application.Validations;

public class CriarFestaValidator : AbstractValidator<CriarFestaCommand>
{
    public CriarFestaValidator()
    {
        RuleFor(c => c.ClienteId)
            .NotEmpty().WithMessage("O Cliente não pode ser nulo.")
            .NotEqual(Guid.Empty).WithMessage("O Cliente não pode ser vazio.");

        RuleFor(c => c.TemaId)
            .NotEmpty().WithMessage("O Tema não pode ser nulo.")
            .NotEqual(Guid.Empty).WithMessage("O Tema não pode ser vazio.");

        RuleFor(c => c.QuantidadeParticipantes)
            .GreaterThan(0).WithMessage("A quantidade de participantes deve ser maior que zero.")
            .LessThanOrEqualTo(100).WithMessage("Quantidade de participantes inválida.");

        RuleFor(c => c.DataRealizacao)
            .NotEmpty().WithMessage("A Data de Realizacao não pode ser nula.");

        RuleFor(c => c.ArtigosDeFesta)
            .NotNull().WithMessage("A lista de Items Extras não pode ser nula.")
            .ForEach(item =>
            {
                item.SetValidator(new PedidoItemDeFestaExtraCommandValidator());
            });
    }
}