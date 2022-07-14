using GerenciaControler.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaControler.Data
{
    //BancoContext Herda de DbContext
    public class BancoContext : DbContext
    {
        //Constructor injeta DbContextOptions com tipagem da propria Classe (BancoContext) e passar a informação pra dentro com o base:options
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        //Configura a Model pra dentor pegando a tabela de acordo com a Model criada
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
