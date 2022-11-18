using Api.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Entidades
{
    public sealed class Pessoa
    {
        public Guid Id { get; private set; }
        public string Usuario { get; set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; private set; }

        public Pessoa(string Nome, string Sobrenome, string Telefone, DateTime DataNascimento, string Email, string Senha)
        {
            Validacao(Nome, Sobrenome, Telefone, DataNascimento, Email, Senha);
        }

        //METODO PARA EDITAR A PESSOA
        public Pessoa(int id,string Usuario, string Nome, string Sobrenome, string Telefone, DateTime DataNascimento, string Email, string Senha) 
        {
            DomainValidationException.When(id < 0, "Id de Usuario Inválido!");
            DomainValidationException.When(string.IsNullOrEmpty(Usuario), "Usuário é Invalido");
            DomainValidationException.When(Usuario.Equals("1234"), "Usuário não pode ser alterado!");

            Validacao(Nome, Sobrenome, Telefone, DataNascimento, Email, Senha);
        }

        //Validação Generica de Entidades
        private void Validacao(string Nome, string Sobrenome, string Telefone, DateTime DataNascimento, string Email, string Senha)
        {
            DomainValidationException.When(string.IsNullOrEmpty(Nome), "Nome deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(Sobrenome), "Sobrenome deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(Telefone), "Telefone deve ser informado");
            DateTime data = DataNascimento;
            DomainValidationException.When(data.Equals(null), "Data deve ser informada!");
            DomainValidationException.When(string.IsNullOrEmpty(Email), "Email deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(Senha), "Senha deve ser informada!");

            Nome = Nome;
            Sobrenome = Sobrenome;
            Telefone = Telefone;
            DataNascimento = DataNascimento;
            Email = Email;  
            Senha = Senha;
        }
    }
}
