using eAgenda.Dominio.ModuloDespesa;
using Microsoft.EntityFrameworkCore;

namespace eAgenda.Infraestrutura.Orm.ModuloDespesa
{
    public class RepositorioDespesa : IRepositorioDespesa
    {
        private readonly AppDbContext context;

        public RepositorioDespesa(AppDbContext context)
        {
            this.context = context;
        }

        public void Cadastrar(Despesa novoRegistro)
        {
            context.Despesas.Add(novoRegistro);
            context.SaveChanges();
        }

        public void Editar(Guid idParaEditar, Despesa registroEditado)
        {
            Despesa despesaAtual = SelecionarRegistroPorId(idParaEditar);

            if (despesaAtual is null)
                return;

            despesaAtual.Descricao = registroEditado.Descricao;
            despesaAtual.DataOcorrencia = registroEditado.DataOcorrencia;
            despesaAtual.Valor = registroEditado.Valor;
            despesaAtual.FormaPagamento = registroEditado.FormaPagamento;
            despesaAtual.Categorias = registroEditado.Categorias;

            context.SaveChanges();
        }

        public void Excluir(Guid idParaDeletar)
        {
            Despesa despesa = SelecionarRegistroPorId(idParaDeletar);

            if (despesa is null)
                return;

            context.Despesas.Remove(despesa);
            context.SaveChanges();
        }

        public Despesa? SelecionarRegistroPorId(Guid id)
        {
            return context.Despesas.Include(x => x.Categorias).FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<Despesa>? SelecionarRegistros()
        {
            return context.Despesas.Include(x => x.Categorias).ToList();
        }
    }
}
