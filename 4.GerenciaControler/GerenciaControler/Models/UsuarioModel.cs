using GerenciaControler.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaControler.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira Matrícula")]
        public string Matricula { get; set; }
        [Required(ErrorMessage ="Insira Nome")]
        public string Nome { get; set; }
        public string Cargo { get; set; }
        //Select idade from usuarios where 
        public int Idade { get; set; }
        [Required(ErrorMessage ="Data Inválida", AllowEmptyStrings = false)]
        public DateTime DataNascimento { get; set; }

        public string Senha { get; set; }
        public string SenhasAntigas { get; set; }
        public bool Admin { get; set; }


        //Funções de verificação
        public bool SenhaValida(string senhaInformada)
        {
            return Senha == senhaInformada.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();

        }
    }
}
