using Api.Domain.Repositorio;
using API.Aplication.Map;
using API.Aplication.Servicos;
using API.Aplication.Servicos.Interface;
using API.Infra.Data.Context;
using API.Infra.Data.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infra.IOC.Dependencias
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection servicos, IConfiguration configuration)
        {
            servicos.AddDbContext<APIPessoaConect>(options => options.UseSqlServer(
                configuration.GetConnectionString(
                    "DefaultConnection")));

            servicos.AddScoped<IRepPessoa, RepPessoa>();

            return servicos;
        }

        public static IServiceCollection AddServicos(this IServiceCollection servicos, IConfiguration configuration)
        {
            servicos.AddAutoMapper(typeof(DomainDtoMap));

            servicos.AddScoped<IPessoaServico, ServicoPessoa>();

            return servicos;
        }
    }
}
