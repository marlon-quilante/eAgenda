using eAgenda.Dominio.ModuloCategoria;

namespace eAgenda.Infraestrutura.Orm.ModuloCategoria
{
    public class RepositorioCategoria : IRepositorioCategoria
    {
        private readonly AppDbContext context;

        public RepositorioCategoria(AppDbContext context)
        {
            this.context = context;
        }

        public void Cadastrar(Categoria novoRegistro)
        {
            context.Categorias.Add(novoRegistro);
            context.SaveChanges();
        }

        public void Editar(Guid idParaEditar, Categoria registroEditado)
        {
            Categoria categoriaAtual = SelecionarRegistroPorId(idParaEditar);
            
            categoriaAtual.Titulo = registroEditado.Titulo;
            
            context.SaveChanges();
        }

        public void Excluir(Guid idParaDeletar)
        {
            Categoria categoria = SelecionarRegistroPorId(idParaDeletar);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
        }

        public Categoria? SelecionarRegistroPorId(Guid id)
        {
            return context.Categorias.Find(id);
        }

        public List<Categoria>? SelecionarRegistros()
        {
            return context.Categorias.ToList();
        }
    }
}
