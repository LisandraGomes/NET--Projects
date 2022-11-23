using Api.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Entidades
{
    public sealed class Produtos
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Codigo { get; private set; }
        public decimal Valor { get; private set; }
        public string Descricao { get; private set; }
        public int QtdDisponivel { get; set; }
        public string Imagem { get; private set; }//caminho da imagem no sistema
        public decimal Peso { get; set; }
        public string Tamanho { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public ICollection<Compra> Compras { get; set; }
        public Produtos(string nome, string codigo, string descricao, int qtdDisponivel, string imagem, decimal valor)
        {
            Validation(nome,codigo,qtdDisponivel,imagem,valor);
            Descricao = descricao;
            Compras = new List<Compra>();
        }

        //Validação se os dados que estão chegando são válidos
        private void Validation(string nome, string codigo, int qtdDisponivel, string imagem, decimal valor)
        {
            DomainValidationException.When(string.IsNullOrWhiteSpace(nome), "Nome não pode ser vazio!");
            DomainValidationException.When(string.IsNullOrWhiteSpace(codigo), "Código não pode ser vazio!");
            DomainValidationException.When(qtdDisponivel < 0, "Quantidade de produtos indisponível para venda!");
            DomainValidationException.When(string.IsNullOrWhiteSpace(imagem), "imagem precisa ser informada!");
            DomainValidationException.When(valor < 0, "Valor deve ser informado!");

            Nome = nome.Trim();
            Codigo = codigo.Trim();
            QtdDisponivel = qtdDisponivel;
            Imagem = imagem.Trim();
            Valor = valor;
        }
    }
}
