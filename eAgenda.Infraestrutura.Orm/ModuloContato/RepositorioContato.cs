using eAgenda.Dominio.ModuloContato;

namespace eAgenda.Infraestrutura.Orm.ModuloContato
{
    public class RepositorioContato : IRepositorioContato
    {
        private readonly AppDbContext context;

        public RepositorioContato(AppDbContext context)
        {
            this.context = context;
        }

        public void Cadastrar(Contato novoRegistro)
        {
            context.Contatos.Add(novoRegistro);
            context.SaveChanges();
        }

        public void Excluir(Guid idParaDeletar)
        {
            Contato contato = SelecionarRegistroPorId(idParaDeletar);

            if (contato is null)
                return;

            context.Contatos.Remove(contato);
            context.SaveChanges();
        }

        public void Editar(Guid idParaEditar, Contato registroAtualizado)
        {
            Contato contato = SelecionarRegistroPorId(idParaEditar);

            if (contato is null)
                return;

            contato.Nome = registroAtualizado.Nome;
            contato.Telefone = registroAtualizado.Telefone;
            contato.Email = registroAtualizado.Email;
            contato.Empresa = registroAtualizado.Empresa;
            contato.Cargo = registroAtualizado.Cargo;

            context.SaveChanges();
        }

        public Contato? SelecionarRegistroPorId(Guid id)
        {
            return context.Contatos.Find(id);
        }

        public List<Contato> SelecionarRegistros()
        {
            return context.Contatos.ToList();
        }
    }
}
