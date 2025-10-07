using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Infraestrutura.Orm.ModuloCategoria;
using eAgenda.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace eAgenda.WebApp.Controllers
{
    [Route("Categorias")]
    public class CategoriaController : Controller
    {
        private readonly IRepositorioCategoria repositorioCategoria;

        public CategoriaController(IRepositorioCategoria repositorioCategoria)
        {
            this.repositorioCategoria = repositorioCategoria;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Categoria> categorias = repositorioCategoria.SelecionarRegistros();

            VisualizarCategoriaViewModel visualizarVM = new VisualizarCategoriaViewModel(categorias);

            return View(visualizarVM);
        }

        [HttpGet("Cadastrar")]
        public IActionResult Cadastrar()
        {
            CadastrarCategoriaViewModel cadastrarVM = new CadastrarCategoriaViewModel();

            return View(cadastrarVM);
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(CadastrarCategoriaViewModel cadastrarVM)
        {
            if (!ModelState.IsValid)
                return View(cadastrarVM);

            Categoria categoria = new Categoria(cadastrarVM.Titulo);

            repositorioCategoria.Cadastrar(categoria);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Editar/{id:guid}")]
        public IActionResult Editar(Guid id)
        {
            Categoria categoria = repositorioCategoria.SelecionarRegistroPorId(id);

            EditarCategoriaViewModel editarVM = new EditarCategoriaViewModel(id, categoria.Titulo);

            return View(editarVM);
        }

        [HttpPost("Editar/{id:guid}")]
        public IActionResult Editar(EditarCategoriaViewModel editarVM)
        {
            if (!ModelState.IsValid)
                return View(editarVM);

            Categoria categoriaEditada = new Categoria(editarVM.Titulo);

            repositorioCategoria.Editar(editarVM.Id, categoriaEditada);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Excluir/{id:guid}")]
        public IActionResult Excluir(Guid id)
        {
            Categoria categoria = repositorioCategoria.SelecionarRegistroPorId(id);

            ExcluirCategoriaViewModel excluirVM = new ExcluirCategoriaViewModel(id, categoria.Titulo);

            return View(excluirVM);
        }

        [HttpPost("Excluir/{id:guid}")]
        public IActionResult ExclusaoConfirmada(Guid id)
        {
            repositorioCategoria.Excluir(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
