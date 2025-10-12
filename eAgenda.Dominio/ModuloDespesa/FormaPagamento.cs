using System.ComponentModel.DataAnnotations;

namespace eAgenda.Dominio.ModuloDespesa
{
    public enum FormaPagamento
    {
        [Display(Name = "Pix")] Pix,
        [Display(Name = "Dinheiro")] Dinheiro,
        [Display(Name = "Cartão de Crédito")] Credito,
        [Display(Name = "Cartão de Débito")] Debito
    }
}
