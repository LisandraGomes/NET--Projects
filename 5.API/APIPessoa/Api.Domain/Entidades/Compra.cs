﻿using Api.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Entidades
{
    public sealed class Compra
    {
        public int Id { get; private set; }
        public int IdProduto { get; private set; }
        public int IdPessoa { get; private set; }
        public DateTime Data { get; private set; }

        //Classe virtual de pessoa e produto para mapeamento de 1 pra N
        public Pessoa Pessoa { get; set; }
        public Produtos Produtos { get; set; }

        public Compra(int idProduto, int idPessoa)
        {
            Validacao(idProduto, idPessoa);
        }

        public Compra(int id,int idProduto, int idPessoa)
        {
            DomainValidationException.When(idPessoa < 0, "Pessoa deve ser informado!");
            Id = id;
            Validacao(idProduto, idPessoa);
        }

        private void Validacao(int idProduto, int idPessoa) 
        {
            DomainValidationException.When(idPessoa < 0, "Pessoa deve ser informado!");
            DomainValidationException.When(idProduto > 0, "Produto deve ser informado!");

            IdPessoa = idPessoa;
            IdProduto = idProduto;
            Data = DateTime.Now;

        }

    }
}
