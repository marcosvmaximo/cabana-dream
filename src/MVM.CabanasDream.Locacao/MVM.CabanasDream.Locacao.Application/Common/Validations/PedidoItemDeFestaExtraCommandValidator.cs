using FluentValidation;
using MVM.CabanasDream.Locacao.Application.Commands;

namespace MVM.CabanasDream.Locacao.Application.Validations;

public class PedidoItemDeFestaExtraCommandValidator : AbstractValidator<ArtigoDeFestaCommand>
{
    public PedidoItemDeFestaExtraCommandValidator()
    {
        RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("O Nome não pode ser vazio.")
            .NotNull().WithMessage("O Nome não pode ser nulo.");

        RuleFor(c => c.Quantidade)
            .GreaterThan(0).WithMessage("A quantidade de items deve ser maior que zero.")
            .LessThanOrEqualTo(100).WithMessage("Quantidade de items inválida.");
    }
}

