using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Application.Interfaces.Model;

namespace Teste.Application.Validation
{
    public class PessoaDTOValidator : AbstractValidator<PessoaDTO>
    {

        public PessoaDTOValidator()
        {
            Validate();
        }

        private void Validate()
        {
            RuleFor(s => s.Nome)
                  .NotEmpty()
                  .WithErrorCode("1")
                  .WithMessage("Nome")
                  .MaximumLength(50)
                  .WithErrorCode("1")
                  .WithMessage("Nome");

            RuleFor(s => s.Sobrenome)
              .NotEmpty()
              .WithErrorCode("2")
              .WithMessage("Sobrenome")
              .MaximumLength(70)
              .WithErrorCode("2")
              .WithMessage("Sobrenome");
        }
    }
}
