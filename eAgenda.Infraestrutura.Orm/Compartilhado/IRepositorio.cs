using eAgenda.Dominio.Compartilhado;

namespace eAgenda.Infraestrutura.Orm.Compartilhado
{
    public interface IRepositorio<T> where T : EntidadeBase<T>
    {
        public void Cadastrar(T novoRegistro);
        public void Editar(Guid idParaEditar, T registroEditado);
        public void Excluir(Guid idParaDeletar);
        public List<T> SelecionarRegistros();
        public T SelecionarRegistroPorId(Guid id);
    }
}
