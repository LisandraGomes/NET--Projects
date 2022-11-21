using Api.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infra.Data.Context
{
    public class APIPessoaConect : DbContext
    {
        public APIPessoaConect(DbContextOptions<APIPessoaConect> options): base(options)
        {

        }
        //Declaração dos DbSets que vai ser usado nos Repositorios
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Produtos> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(APIPessoaConect).Assembly);
        }
    }
}
