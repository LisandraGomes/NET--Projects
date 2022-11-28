using Api.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Aplication.DTOs
{
    public class PessoaDto // Ponte entre o externo e a aplicação
    {
        public int Id { get; private set; }
        public string Usuario { get; private set; } = "genT";
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get;  set; }

    }
}
