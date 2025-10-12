using eAgenda.Dominio.ModuloCategoria;
using Microsoft.EntityFrameworkCore;

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

            if (categoriaAtual is null)
                return;

            categoriaAtual.Titulo = registroEditado.Titulo;
            
            context.SaveChanges();
        }

        public void Excluir(Guid idParaDeletar)
        {
            Categoria categoria = SelecionarRegistroPorId(idParaDeletar);

            if (categoria is null)
                return;

            context.Categorias.Remove(categoria);
            context.SaveChanges();
        }

        public Categoria? SelecionarRegistroPorId(Guid id)
        {
            return context.Categorias.Include(x => x.Despesas).FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<Categoria>? SelecionarRegistros()
        {
            return context.Categorias.Include(x => x.Despesas).ToList();
        }
    }
}
