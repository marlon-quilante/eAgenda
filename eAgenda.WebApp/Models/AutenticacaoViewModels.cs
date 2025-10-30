using System.ComponentModel.DataAnnotations;

namespace eAgenda.WebApp.Models
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "O email é um campo obrigatório!")]
        [RegularExpression(@"^(?:[\p{L}0-9!#$%&'*+/=?^_`{|}~.-]+)@(?:[A-Za-z0-9-]+\.)+[A-Za-z]{2,}$", ErrorMessage = "O email não está em um formato válido!")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é um campo obrigatório!")]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "A confirmação da senha é um campo obrigatório!")]
        [Compare(nameof(Senha), ErrorMessage = "A confirmação da senha não é igual à senha!")]
        public string SenhaConfirmada { get; set; } = string.Empty;
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "O email é um campo obrigatório!")]
        [RegularExpression(@"^(?:[\p{L}0-9!#$%&'*+/=?^_`{|}~.-]+)@(?:[A-Za-z0-9-]+\.)+[A-Za-z]{2,}$", ErrorMessage = "O email não está em um formato válido!")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é um campo obrigatório!")]
        public string Senha { get; set; } = string.Empty;
    }
}
