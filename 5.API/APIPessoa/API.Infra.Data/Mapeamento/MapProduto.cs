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
    internal class MapProduto : IEntityTypeConfiguration<Produtos>
    {
        public void Configure(EntityTypeBuilder<Produtos> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("PROD_ID_PRODUTO").UseIdentityColumn();
            builder.Property(x => x.Nome).HasColumnName("PROD_NOME").UseIdentityColumn();
            builder.Property(x => x.Codigo).HasColumnName("PROD_COD_ERP").UseIdentityColumn();
            builder.Property(x => x.Descricao).HasColumnName("PROD_DESCRICAO_P1").UseIdentityColumn();
            builder.Property(x => x.Imagem).HasColumnName("PROD_IMG_PRODUTO").UseIdentityColumn();
            builder.Property(x => x.Valor).HasColumnName("PROD_VALOR_BRUTO").UseIdentityColumn();
            builder.Property(x => x.Peso).HasColumnName("PROD_PESO").UseIdentityColumn();
            builder.Property(x => x.Tamanho).HasColumnName("PROD_TAMANHO").UseIdentityColumn();
            builder.Property(x => x.Modelo).HasColumnName("PROD_MODELO_PRODUTO").UseIdentityColumn();
            builder.Property(x => x.Cor).HasColumnName("PROD_COR_PRODTO").UseIdentityColumn();
            builder.Property(x => x.QtdDisponivel).HasColumnName("PROD_QTD_PRODUTOS").UseIdentityColumn();


            //COLOCAR 1 PRA N e N pra 1 e FK
            builder.HasMany(c => c.Compras).WithOne(p => p.Produtos).HasForeignKey(c => c.IdProduto);
            
        }
    }
}
