using eAgenda.Dominio.Compartilhado;

namespace eAgenda.Dominio.ModuloCategoria
{
    public class Categoria : EntidadeBase<Categoria>
    {
        public string Titulo { get; set; }

        public Categoria() { }

        public Categoria(string titulo)
        {
            Titulo = titulo;
        }
    }
}
