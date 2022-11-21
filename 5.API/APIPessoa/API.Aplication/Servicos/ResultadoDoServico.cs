using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Aplication.Servicos
{
    public class ResultadoDoServico
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public ICollection<ValidacaoDeErro> Erros { get; set; }

        //Metodos dos possiveis retornos de erros 1 pra cada classe
        //Para Classe Princial
        public static ResultadoDoServico RequestErro(string mensagem, ValidationResult validationResult)
        {
            return new ResultadoDoServico
            {
                Sucesso = false,
                Mensagem = mensagem,
                Erros = validationResult.Errors.Select(x => new ValidacaoDeErro { Field = x.PropertyName, Menssage = x.ErrorMessage }).ToList()
            };
        }
        //Para classe genérica
        public static ResultadoDoServico<T> RequestErro<T>(string mensagem, ValidationResult validationResult)
        {
            return new ResultadoDoServico<T>
            {
                Sucesso = false,
                Mensagem = mensagem,
                Erros = validationResult.Errors.Select(x => new ValidacaoDeErro { Field = x.PropertyName, Menssage = x.ErrorMessage }).ToList()
            };
        }

        //
        public static ResultadoDoServico Fail(string mensagem) => new ResultadoDoServico { Sucesso = false, Mensagem = mensagem };
        public static ResultadoDoServico<T> Fail<T>(string mensagem) => new ResultadoDoServico<T> { Sucesso = false, Mensagem = mensagem };

        public static ResultadoDoServico Ok(string mensagem) => new ResultadoDoServico { Sucesso = true, Mensagem = mensagem };
        public static ResultadoDoServico<T> Ok<T>(T data) => new ResultadoDoServico<T> { Sucesso = true, Data = data };
    }

    public class ResultadoDoServico<T> : ResultadoDoServico
    {
        public T Data { get; set; }
    }
}
