using eAgenda.Dominio.ModuloAutenticacao;

namespace eAgenda.Dominio.Compartilhado
{
    public class EntidadeBase<T>
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
