using eAgenda.Dominio.Compartilhado;
using eAgenda.Dominio.ModuloCategoria;

namespace eAgenda.Dominio.ModuloDespesa
{
    public class Despesa : EntidadeBase<Despesa>
    {
        public string Descricao { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public decimal Valor { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public List<Categoria> Categorias { get; set; }

        public Despesa() { }

        public Despesa(string descricao, DateTime dataOcorrencia, decimal valor, FormaPagamento formaPagamento, List<Categoria> categorias)
        {
            Descricao = descricao;
            DataOcorrencia = dataOcorrencia;
            Valor = valor;
            FormaPagamento = formaPagamento;
            Categorias = categorias;
        }
    }
}
