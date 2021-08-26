using FluentValidation;
using DS.Domain.ClientControll;

namespace DS.Infrastructure.ClientControll.Validators
{
    public class ClientePessoaFisicaValidator : AbstractValidator<ClientePessoaFisica>
    {
        public ClientePessoaFisicaValidator()
        {
            RuleSet("insert", () =>
            {
                RuleFor(x => x.nome).NotEmpty().WithMessage("É necessário um nome válido");
                RuleFor(x => x.cpf).NotEmpty().WithMessage("É necessário um CPF válido");
            });

            RuleSet("update", () =>
            {
                RuleFor(x => x.nome).NotEmpty().WithMessage("É necessário um nome válido.");
                RuleFor(x => x.codigo).NotEmpty().WithMessage("É necessário um código válido.");
            });
        }
    }

}
