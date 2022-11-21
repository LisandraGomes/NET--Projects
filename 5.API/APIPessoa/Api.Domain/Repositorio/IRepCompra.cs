using Api.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Repositorio
{
    public interface IRepCompra
    {
        Task<Compra> GetByIdAsync(int id);
        Task<ICollection<Compra>> GetPessoaAsync();
        Task<Compra> CreateAsync(Compra compra);
        Task EditAsync(Compra compra);
        Task DeleteAsync(Compra compra);

    }
}
