using Api.Domain.Entidades;
using Api.Domain.Repositorio;
using API.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infra.Data.Repositorios
{
    public class RepProduto : IRepProduto
    {
        private APIPessoaConect _db;

        public RepProduto(APIPessoaConect db)
        {
            _db = db;
        }

        public async Task<Produtos> CreateProdutosAsync(Produtos produtos)
        {
            _db.Add(produtos);
            await _db.SaveChangesAsync();
            return produtos;
        }

        public async Task DeleteProdutosAsync(int id)
        {
            _db.Remove(id);
            await _db.SaveChangesAsync();
        }

        public async Task EditProdutosAsync(Produtos produtos)
        {
            _db.Update(produtos);
            await _db.SaveChangesAsync();
        }

        public async Task<Produtos> GetIdProdutosAsync(int id)
        {
            return await _db.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Produtos>> GetProdutosAsync()
        {
            return await _db.Produtos.ToListAsync();
        }
    }
}
