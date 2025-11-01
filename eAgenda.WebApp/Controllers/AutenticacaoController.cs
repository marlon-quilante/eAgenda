using eAgenda.Dominio.ModuloAutenticacao;
using eAgenda.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace eAgenda.WebApp.Controllers
{
    [Route("Autenticacao")]
    public class AutenticacaoController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager) : Controller
    {
        [HttpGet("Registro")]
        public IActionResult Registro()
        {
            var registroVM = new RegistroViewModel();

            return View(registroVM);
        }

        [HttpPost("Registro")]
        public async Task<IActionResult> Registro(RegistroViewModel registroVM)
        {
            Usuario usuario = new Usuario() { UserName = registroVM.Email, Email = registroVM.Email };

            if (!ModelState.IsValid)
            {
                registroVM = new RegistroViewModel();

                return View(registroVM);
            }

            IdentityResult? usuarioResult = await userManager.CreateAsync(usuario, registroVM.Senha);

            if (!usuarioResult.Succeeded)
            {
                var erros = usuarioResult.Errors.Select(err =>
                {
                    return err.Code switch
                    {
                        "DuplicateUserName" => "Já existe um usuário com esse nome!",
                        "DuplicateEmail" => "Já existe um usuário com esse email!",
                        "PasswordTooShort" => "A senha é muito curta!",
                        "PasswordRequiresNonAlphanumeric" => "A senha deve conter pelo menos um caractere especial!",
                        "PasswordRequiresDigit" => "A senha deve conter pelo menos um número!",
                        "PasswordRequiresUpper" => "A senha deve conter pelo menos uma letra maiúscula!",
                        "PasswordRequiresLower" => "A senha deve conter pelo menos uma letra minúscula!",
                        _ => err.Description
                    };
                }).ToList();

                return View(registroVM);
            }

            SignInResult resultadoLogin = await signInManager.PasswordSignInAsync(registroVM.Email, registroVM.Senha, isPersistent: true, lockoutOnFailure: false);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet("Login")]
        public IActionResult Login(string? returnUrl = null)
        {
            var loginVM = new LoginViewModel();

            ViewData["ReturnUrl"] = returnUrl;

            return View(loginVM);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel loginVM, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                loginVM = new LoginViewModel();

                ViewData["ReturnUrl"] = returnUrl;

                return View(loginVM);
            }

            SignInResult resultadoLogin = await signInManager.PasswordSignInAsync(loginVM.Email, loginVM.Senha, isPersistent: true, lockoutOnFailure: false);

            if (!resultadoLogin.Succeeded)
            {
                return View(loginVM);
            }

            if (Url.IsLocalUrl(returnUrl))
                return LocalRedirect(returnUrl);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }
    }
}
