﻿using eAgenda.Dominio.ModuloDespesa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgenda.Infraestrutura.Orm.ModuloDespesa
{
    public class MapeadorDespesaEmOrm : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder.ToTable("TBDespesa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DataOcorrencia);
            builder.Property(x => x.Valor).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.FormaPagamento).IsRequired();
            builder.HasMany(x => x.Categorias).WithMany(c => c.Despesas).UsingEntity(x => x.ToTable("TBCategoria_TBDespesa"));
            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey(x => x.UsuarioId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
