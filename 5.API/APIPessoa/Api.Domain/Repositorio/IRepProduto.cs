using Api.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Repositorio
{
    public interface IRepProduto
    {
        Task<Produtos> GetIdProdutosAsync(int id);
        Task<ICollection<Produtos>> GetProdutosAsync();
        Task<Produtos> CreateProdutosAsync(Produtos produtos);
        Task EditProdutosAsync(Produtos produtos);
        Task DeleteProdutosAsync(int id);
    }
}
