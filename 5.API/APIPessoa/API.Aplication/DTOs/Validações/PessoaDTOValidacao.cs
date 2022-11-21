using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Aplication.DTOs.Validações
{
    public class PessoaDTOValidacao : AbstractValidator<PessoaDto>
    {
        public PessoaDTOValidacao() 
        {
            RuleFor(x => x.Cpf).NotEmpty().NotNull().WithMessage("CPF não pode ser vazio!");

            RuleFor(x => x.Nome).NotEmpty().NotNull().WithMessage("Nome não pode ser vazio!");

            RuleFor(x => x.Sobrenome).NotEmpty().NotNull().WithMessage("Sobrenome não pode ser vazio!");
            RuleFor(x => x.Senha).NotEmpty().NotNull().WithMessage("Favor inserir senha!");
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Favor inserir email!");
            RuleFor(x => x.DataNascimento).NotEmpty().NotNull().WithMessage("Data de Nascimento não pode ser vazia!");
            RuleFor(x => x.Telefone).NotEmpty().NotNull().WithMessage("Telefone não pode ser vazio!");


        }
    }
}
