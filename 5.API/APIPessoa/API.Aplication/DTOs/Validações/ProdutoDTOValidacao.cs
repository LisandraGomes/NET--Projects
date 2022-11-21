using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Aplication.DTOs.Validações
{
    public class ProdutoDTOValidacao : AbstractValidator<ProdutoDto>
    {
        public ProdutoDTOValidacao()
        { 
        }
    }
}
