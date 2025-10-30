using eAgenda.Dominio.ModuloContato;
using eAgenda.Infraestrutura.Orm.ModuloContato;
using eAgenda.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eAgenda.WebApp.Controllers
{
    [Authorize]
    [Route("Contatos")]
    public class ContatoController : Controller
    {
        private readonly IRepositorioContato repositorioContato;

        public ContatoController(IRepositorioContato repositorioContato)
        {
            this.repositorioContato = repositorioContato;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Contato> contatos = repositorioContato.SelecionarRegistros();

            VisualizarContatosViewModel visualizarVM = new VisualizarContatosViewModel(contatos);

            return View(visualizarVM);
        }

        [HttpGet("Cadastrar")]
        public IActionResult Cadastrar()
        {
            CadastrarContatoViewModel cadastrarVM = new CadastrarContatoViewModel();

            return View(cadastrarVM);
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(CadastrarContatoViewModel cadastrarVM)
        {
            if (!ModelState.IsValid)
                return View(cadastrarVM);

            Contato novoContato = new Contato(cadastrarVM.Nome, cadastrarVM.Telefone, cadastrarVM.Email, cadastrarVM.Empresa, cadastrarVM.Cargo);

            repositorioContato.Cadastrar(novoContato);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Editar/{id:guid}")]
        public IActionResult Editar(Guid id)
        {
            Contato contato = repositorioContato.SelecionarRegistroPorId(id);

            EditarContatoViewModel editarVM = new EditarContatoViewModel(contato.Id, contato.Nome, contato.Telefone, contato.Email, contato.Empresa, contato.Cargo);

            return View(editarVM);
        }

        [HttpPost("Editar/{id:guid}")]
        public IActionResult Editar(Guid id, EditarContatoViewModel editarVM)
        {
            if (!ModelState.IsValid)
                return View(editarVM);

            Contato contatoAtualizado = new Contato(editarVM.Nome, editarVM.Telefone, editarVM.Email, editarVM.Empresa, editarVM.Cargo);

            repositorioContato.Editar(id, contatoAtualizado);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Excluir/{id:guid}")]
        public IActionResult Excluir(Guid id)
        {
            Contato contato = repositorioContato.SelecionarRegistroPorId(id);

            ExcluirContatoViewModel excluirVM = new ExcluirContatoViewModel(id, contato.Nome);

            return View(excluirVM);
        }

        [HttpPost("Excluir/{id:guid}")]
        public IActionResult ExclusaoConfirmada(Guid id)
        {
            Contato contato = repositorioContato.SelecionarRegistroPorId(id);

            repositorioContato.Excluir(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
