using Api.Domain.Entidades;
using API.Aplication.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Aplication.Map
{
    public class DomainDtoMap : Profile
    {
        public DomainDtoMap()
        {
            CreateMap<Pessoa, PessoaDto>();
        }
    
    }
}
