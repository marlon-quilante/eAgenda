using eAgenda.Dominio.ModuloCompromisso;
using Microsoft.EntityFrameworkCore;

namespace eAgenda.Infraestrutura.Orm.ModuloCompromisso
{
    public class RepositorioCompromisso : IRepositorioCompromisso
    {
        private readonly AppDbContext context;

        public RepositorioCompromisso(AppDbContext context)
        {
            this.context = context;
        }

        public void Cadastrar(Compromisso novoRegistro)
        {
            context.Compromissos.Add(novoRegistro);
            context.SaveChanges();
        }

        public void Editar(Guid idParaEditar, Compromisso registroEditado)
        {
            Compromisso compromisso = SelecionarRegistroPorId(idParaEditar);

            if (compromisso is null)
                return;

            compromisso.Assunto = registroEditado.Assunto;
            compromisso.Data = registroEditado.Data;
            compromisso.HoraInicio = registroEditado.HoraInicio;
            compromisso.HoraTermino = registroEditado.HoraTermino;
            compromisso.Tipo = registroEditado.Tipo;
            compromisso.Local = registroEditado.Local;
            compromisso.Link = registroEditado.Link;
            compromisso.Contato = registroEditado.Contato;

            context.SaveChanges();
        }

        public void Excluir(Guid idParaDeletar)
        {
            Compromisso compromisso = SelecionarRegistroPorId(idParaDeletar);

            if (compromisso is null)
                return;

            context.Compromissos.Remove(compromisso);
            context.SaveChanges();
        }

        public Compromisso? SelecionarRegistroPorId(Guid id)
        {
            return context.Compromissos.Include(x => x.Contato).FirstOrDefault(x => x.Id == id);
        }

        public List<Compromisso> SelecionarRegistros()
        {
            return context.Compromissos.Include(x => x.Contato).ToList();
        }
    }
}
