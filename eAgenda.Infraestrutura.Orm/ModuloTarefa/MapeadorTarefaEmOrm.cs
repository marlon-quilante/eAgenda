using eAgenda.Dominio.ModuloTarefa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgenda.Infraestrutura.Orm.ModuloTarefa
{
    public class MapeadorTarefaEmOrm : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("TBTarefa");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Prioridade).IsRequired();
            builder.Property(x => x.DataCriacao).IsRequired();
            builder.Property(x => x.DataConclusao);
            builder.Property(x => x.StatusConclusao).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.PercentualConclusao);
        }
    }
}
