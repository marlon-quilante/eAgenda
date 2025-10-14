using eAgenda.Dominio.ModuloTarefa;
using Microsoft.EntityFrameworkCore;

namespace eAgenda.Infraestrutura.Orm.ModuloTarefa
{
    public class RepositorioTarefa : IRepositorioTarefa
    {
        private readonly AppDbContext context;

        public RepositorioTarefa(AppDbContext context)
        {
            this.context = context;
        }

        public void Cadastrar(Tarefa novoRegistro)
        {
            context.Tarefas.Add(novoRegistro);
            context.SaveChanges();
        }

        public void Editar(Guid idParaEditar, Tarefa registroEditado)
        {
            Tarefa tarefaAtual = SelecionarRegistroPorId(idParaEditar);

            if (tarefaAtual is null) return;

            tarefaAtual.Titulo = registroEditado.Titulo;
            tarefaAtual.Prioridade = registroEditado.Prioridade;

            context.SaveChanges();
        }

        public void Excluir(Guid idParaDeletar)
        {
            Tarefa tarefa = SelecionarRegistroPorId(idParaDeletar);

            if (tarefa is null) return;

            context.Tarefas.Remove(tarefa);
            context.SaveChanges();
        }

        public Tarefa? SelecionarRegistroPorId(Guid id)
        {
            return context.Tarefas.Include(x => x.ItensTarefa).FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<Tarefa>? SelecionarRegistros()
        {
            return context.Tarefas.Include(x => x.ItensTarefa).ToList();
        }

        public void AtualizarPercentualConclusao(Guid id)
        {
            Tarefa tarefa = SelecionarRegistroPorId(id);

            if (tarefa is null) return;

            decimal qtdItensTotal = tarefa.ItensTarefa.Count();
            decimal qtdItensConcluidos = tarefa.ItensTarefa.Where(x => x.StatusConclusao == true).Count();

            if (qtdItensTotal == 0)
            {
                tarefa.PercentualConclusao = 0;
                return;
            }

            decimal percentualConclusao = (qtdItensConcluidos / qtdItensTotal) * 100;

            tarefa.PercentualConclusao = percentualConclusao;
            context.SaveChanges();
        }

        public void Concluir(Guid id)
        {
            Tarefa tarefa = SelecionarRegistroPorId(id);

            if (tarefa is null) return;

            tarefa.StatusConclusao = true;
            tarefa.DataConclusao = DateTime.Now;
            context.SaveChanges();
        }

        public void DesfazerConclusao(Guid id)
        {
            Tarefa tarefa = SelecionarRegistroPorId(id);

            if (tarefa is null) return;

            tarefa.StatusConclusao = false;
            tarefa.DataConclusao = null;
            context.SaveChanges();
        }
    }
}
