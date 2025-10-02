using eAgenda.Dominio.ModuloContato;
using eAgenda.Infraestrutura.Orm.ModuloContato;
using eAgenda.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace eAgenda.WebApp.Controllers
{
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
            Contato novoContato = new Contato(cadastrarVM.Nome, cadastrarVM.Telefone, cadastrarVM.Email, cadastrarVM.Empresa, cadastrarVM.Cargo);

            repositorioContato.Cadastrar(novoContato);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Editar/{idParaEditar:guid}")]
        public IActionResult Editar(Guid idParaEditar)
        {
            Contato contato = repositorioContato.SelecionarRegistroPorId(idParaEditar);

            EditarContatoViewModel editarVM = new EditarContatoViewModel(contato.Id, contato.Nome, contato.Telefone, contato.Email, contato.Empresa, contato.Cargo);

            return View(editarVM);
        }

        [HttpPost("Editar/{idParaEditar:guid}")]
        public IActionResult Editar(Guid idParaEditar, EditarContatoViewModel editarVM)
        {
            Contato contatoAtualizado = new Contato(editarVM.Nome, editarVM.Telefone, editarVM.Email, editarVM.Empresa, editarVM.Cargo);

            repositorioContato.Editar(idParaEditar, contatoAtualizado);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Excluir/{idParaExcluir:guid}")]
        public IActionResult Excluir(Guid idParaExcluir)
        {
            Contato contato = repositorioContato.SelecionarRegistroPorId(idParaExcluir);

            ExcluirContatoViewModel excluirVM = new ExcluirContatoViewModel(idParaExcluir, contato.Nome);

            return View(excluirVM);
        }

        [HttpPost("Excluir/{idParaExcluir:guid}")]
        public IActionResult ExclusaoConfirmada(Guid idParaExcluir)
        {
            Contato contato = repositorioContato.SelecionarRegistroPorId(idParaExcluir);

            repositorioContato.Excluir(idParaExcluir);

            return RedirectToAction(nameof(Index));
        }
    }
}
