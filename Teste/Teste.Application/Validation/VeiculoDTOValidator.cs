using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Application.Model;

namespace Teste.Application.Validation
{
    public class VeiculoDTOValidator: AbstractValidator<VeiculoDTO>
    {
        public VeiculoDTOValidator()
        {
            Validate();
        }

        private void Validate()
        {
            RuleFor(s => s.Placa)
                .NotEmpty()
                .WithErrorCode("3")
                .WithMessage("Placa")
                .MaximumLength(8)
                .WithErrorCode("3")
                .WithMessage("Placa");

        }
    }
}
