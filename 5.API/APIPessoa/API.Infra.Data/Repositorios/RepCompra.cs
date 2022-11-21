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
    internal class RepCompra : IRepCompra
    {
        private readonly APIPessoaConect _db;

        public RepCompra(APIPessoaConect db)
        {
            _db = db;
        }

        public async Task<Compra> CreateAsync(Compra compra)
        {
            _db.Add(compra);
            await _db.SaveChangesAsync();
            return compra;
        }

        public async Task DeleteAsync(Compra compra)
        {
            _db.Remove(compra);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Compra compra)
        {
            _db.Update(compra);
            await _db.SaveChangesAsync();
        }

        public async Task<Compra> GetByIdAsync(int id)
        {
            return await _db.Compras.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Compra>> GetPessoaAsync()
        {
            return await _db.Compras.ToListAsync();
        }
    }
}
