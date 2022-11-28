using Api.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infra.Data.Mapeamento
{
    public class MapPessoa : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("PESSOA");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("PES_ID_PESSOA").UseIdentityColumn();
            builder.Property(x => x.Nome).HasColumnName("PES_NOME").UseIdentityColumn();
            builder.Property(x => x.Sobrenome).HasColumnName("PES_SOBRENOME").UseIdentityColumn();
            builder.Property(x => x.Usuario).HasColumnName("PES_ID_USUARIO").UseIdentityColumn();
            builder.Property(x => x.DataNascimento).HasColumnName("PES_DATA_NASCIMENTO").UseIdentityColumn();
            builder.Property(x => x.Cpf).HasColumnName("PES_CPF").UseIdentityColumn();
            builder.Property(x => x.Telefone).HasColumnName("PES_TELEFONE").UseIdentityColumn();
            builder.Property(x => x.Email).HasColumnName("PES_EMAIL").UseIdentityColumn();
            builder.Property(x => x.Senha).HasColumnName("PES_SENHA_ATUAL").UseIdentityColumn();
        
            //builder.HasMany(c => c.Compras).WithOne(p => p.Pessoa).HasForeignKey(c => c.IdPessoa);
        }
    }
}
