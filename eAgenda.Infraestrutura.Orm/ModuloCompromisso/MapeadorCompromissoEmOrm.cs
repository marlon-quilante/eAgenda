using eAgenda.Dominio.ModuloCompromisso;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgenda.Infraestrutura.Orm.ModuloCompromisso
{
    public class MapeadorCompromissoEmOrm : IEntityTypeConfiguration<Compromisso>
    {
        public void Configure(EntityTypeBuilder<Compromisso> builder)
        {
            builder.ToTable("TBCompromisso");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Assunto).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.HoraInicio).IsRequired();
            builder.Property(x => x.HoraTermino).IsRequired();
            builder.Property(x => x.Tipo).IsRequired();
            builder.Property(x => x.Link).IsRequired(false);
            builder.Property(x => x.Local).IsRequired(false).HasMaxLength(250);
            builder.HasOne(x => x.Contato).WithMany(c => c.Compromissos).IsRequired(false);
        }
    }
}
