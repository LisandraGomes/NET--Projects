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
    public class RepPessoa : IRepPessoa
    {
        private readonly APIPessoaConect _db;

        public RepPessoa(APIPessoaConect db)
        {
            _db = db;
        }


         public async Task<Pessoa> CreateAsync(Pessoa pessoa)
        {
            _db.Add(pessoa);
            await _db.SaveChangesAsync();
            return pessoa;
        }

        public async Task DeleteAsync(Pessoa pessoa)
        {
           _db.Remove(pessoa);
            await _db.SaveChangesAsync();
           
        }

        public async Task EditAsync(Pessoa pessoa)
        {
            _db.Update(pessoa);
            await _db.SaveChangesAsync();
        }

        public async Task<Pessoa> GetByIdAsync(int id)
        {
            return await _db.Pessoas.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<Pessoa>> GetPessoaAsync()
        {
            return await _db.Pessoas.ToListAsync();
        }
    }
}
