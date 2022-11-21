using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Aplication.DTOs.Validações
{
    public class CompraDTOValidacao : AbstractValidator<CompraDto>
    {
        public CompraDTOValidacao()
        {
            RuleFor(x => x.IdPessoa).NotEmpty().NotNull().WithMessage("Para finalizar a compra é necessário estar cadastrado!");

            RuleFor(x => x.IdProduto).NotEmpty().NotNull().WithMessage("Não é possível finalizar uma compra sem produto!");
        }
    }
}
