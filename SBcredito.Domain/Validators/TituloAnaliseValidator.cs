using FluentValidation;
using SBcredito.Domain.Models;

namespace SBcredito.Domain.Validators
{
    public class TituloAnaliseValidator : AbstractValidator<TituloAnaliseModel>
    {
        public TituloAnaliseValidator()
        {
            RuleFor(titulo => titulo.CNPJ)
                .NotEmpty().WithMessage("O CNPJ é obrigatório.")
                .Length(14).WithMessage("O CNPJ deve ter 14 dígitos.");

            RuleFor(titulo => titulo.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.");

            RuleFor(titulo => titulo.Estado)
                .NotEmpty().WithMessage("O estado é obrigatório.");

            RuleFor(titulo => titulo.Bairro)
                .NotEmpty().WithMessage("O bairro é obrigatório.");

            RuleFor(titulo => titulo.EnderecoCobranca)
                .NotEmpty().WithMessage("O endereço de cobrança é obrigatório.");

            RuleFor(titulo => titulo.CEP)
                .NotEmpty().WithMessage("O CEP é obrigatório.");

            RuleFor(titulo => titulo.Cidade)
                .NotEmpty().WithMessage("A cidade é obrigatória.");

            RuleFor(titulo => titulo.ValorFace)
                .NotEmpty().WithMessage("O valor de face é obrigatório.");

            RuleFor(titulo => titulo.NomeSacado)
                .NotEmpty().WithMessage("O nome do sacado é obrigatório.");
        }
    }
}
