using Api.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Repositorio
{
    public interface IRepPessoa
    {
        //Métodos padrão
        Task<Pessoa> GetByIdAsync(int id);
        Task<ICollection<Pessoa>> GetPessoaAsync();
        Task<Pessoa> CreateAsync(Pessoa pessoa);
        Task EditAsync(Pessoa pessoa);
        Task DeleteAsync(Pessoa pessoa);
    }
}
