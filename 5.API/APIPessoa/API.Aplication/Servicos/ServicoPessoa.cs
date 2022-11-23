using Api.Domain.Entidades;
using Api.Domain.Repositorio;
using API.Aplication.DTOs;
using API.Aplication.DTOs.Validações;
using API.Aplication.Servicos.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Aplication.Servicos
{
    public class ServicoPessoa : IPessoaServico
    {
        private readonly IRepPessoa _repPessoa;
        private readonly IMapper _mapper;

        public ServicoPessoa(IRepPessoa repPessoa, IMapper mapper)
        {
            _repPessoa = repPessoa;
            _mapper = mapper;
        }

        public async Task<ResultadoDoServico<PessoaDto>> CreateAsync(PessoaDto pessoaDTO)
        {
            if (pessoaDTO == null)
                return ResultadoDoServico.Fail<PessoaDto>("Objeto deve ser informado.");

            var result = new PessoaDTOValidacao().Validate(pessoaDTO);

            if (!result.IsValid)
                return ResultadoDoServico.RequestErro<PessoaDto>("Problemas de validação, ", result);

            //Mapeia a entidade, pois no banco não pode inserir dto. por isso transforma a dto em entendida e insere a entidade. Função do DTO é trafegar entre as aplicações.
            var pessoa = _mapper.Map<Pessoa>(pessoaDTO);

            var data = await _repPessoa.CreateAsync(pessoa);

            return ResultadoDoServico.Ok<PessoaDto>(_mapper.Map<PessoaDto>(data));
        }
    }
}
