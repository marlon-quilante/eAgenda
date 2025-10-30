using eAgenda.Dominio.ModuloTarefa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgenda.Infraestrutura.Orm.ModuloTarefa
{
    public class MapeadorItemTarefaEmOrm : IEntityTypeConfiguration<ItemTarefa>
    {
        public void Configure(EntityTypeBuilder<ItemTarefa> builder)
        {
            builder.ToTable("TBItemTarefa");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.StatusConclusao).IsRequired().HasDefaultValue(false);
            builder.HasOne(x => x.Tarefa).WithMany(i => i.ItensTarefa).OnDelete(DeleteBehavior.Cascade).IsRequired();
            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey(x => x.UsuarioId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
