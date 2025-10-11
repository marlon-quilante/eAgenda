using eAgenda.Dominio.Compartilhado;
using eAgenda.Dominio.ModuloDespesa;

namespace eAgenda.Dominio.ModuloCategoria
{
    public class Categoria : EntidadeBase<Categoria>
    {
        public string Titulo { get; set; }
        public List<Despesa> Despesas { get; set; }

        public Categoria() { }

        public Categoria(string titulo)
        {
            Titulo = titulo;
        }

        public Categoria(Guid id, string titulo)
        {
            Id = id;
            Titulo = titulo;
        }
    }
}
