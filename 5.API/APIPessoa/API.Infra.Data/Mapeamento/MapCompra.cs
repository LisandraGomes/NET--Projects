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
    internal class MapCompra : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.ToTable("Compra");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("COM_ID_COMPRA").UseIdentityColumn();
            builder.Property(t => t.IdPessoa).HasColumnName("PES_ID_PESSOA").UseIdentityColumn();
            builder.Property(t => t.Data).HasColumnName("COM_DT_COMPRA").UseIdentityColumn();
            builder.Property(t => t.IdProduto).HasColumnName("PRDO_ID_PRODUTO").UseIdentityColumn();

            //Setar N pra 1 e 1 pra N

            builder.HasOne(p => p.Pessoa).WithMany(p => p.Compras);
            builder.HasOne(p => p.Produtos).WithMany(p => p.Compras);

        }
    }
}
