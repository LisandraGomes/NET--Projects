using API.Aplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Aplication.Servicos.Interface
{
    public interface IPessoaServico
    {
        Task<ResultadoDoServico<PessoaDto>> CreateAsync(PessoaDto pessoaDTO);

    }
}
