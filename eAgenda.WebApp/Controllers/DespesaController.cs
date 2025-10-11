using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Dominio.ModuloDespesa;
using eAgenda.Infraestrutura.Orm;
using eAgenda.Infraestrutura.Orm.ModuloCategoria;
using eAgenda.Infraestrutura.Orm.ModuloDespesa;
using eAgenda.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace eAgenda.WebApp.Controllers
{
    [Route("Despesas")]
    public class DespesaController : Controller
    {
        private readonly IRepositorioDespesa repositorioDespesa;
        private readonly IRepositorioCategoria repositorioCategoria;
        private readonly AppDbContext context;

        public DespesaController(IRepositorioDespesa repositorioDespesa, IRepositorioCategoria repositorioCategoria, AppDbContext context)
        {
            this.repositorioDespesa = repositorioDespesa;
            this.repositorioCategoria = repositorioCategoria;
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Despesa> despesas = repositorioDespesa.SelecionarRegistros();

            VisualizarDespesasViewModel visualizarVM = new VisualizarDespesasViewModel(despesas);

            return View(visualizarVM);
        }

        [HttpGet("Cadastrar")]
        public IActionResult Cadastrar()
        {
            List<Categoria> categoriasDisponiveis = repositorioCategoria.SelecionarRegistros();

            CadastrarDespesaViewModel cadastrarVM = new CadastrarDespesaViewModel(categoriasDisponiveis);

            return View(cadastrarVM);
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(CadastrarDespesaViewModel cadastrarVM)
        {
            List<Categoria> categorias = repositorioCategoria.SelecionarRegistros();

            if (!ModelState.IsValid)
            {
                categorias = repositorioCategoria.SelecionarRegistros();
                cadastrarVM = new CadastrarDespesaViewModel(categorias);
                return View(cadastrarVM);
            }

            Despesa novaDespesa = new Despesa(cadastrarVM.Descricao, cadastrarVM.DataOcorrencia, cadastrarVM.Valor, 
                cadastrarVM.FormaPagamento, new List<Categoria>());

            foreach (var cs in cadastrarVM.CategoriasSelecionadas)
            {
                foreach (Categoria c in categorias)
                {
                    if (cs == c.Id)
                        novaDespesa.Categorias.Add(c);
                }
            }

            repositorioDespesa.Cadastrar(novaDespesa);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Editar/{id:guid}")]
        public IActionResult Editar(Guid id)
        {
            Despesa despesa = repositorioDespesa.SelecionarRegistroPorId(id);

            List<Categoria> categoriasDisponiveis = repositorioCategoria.SelecionarRegistros();

            EditarDespesaViewModel editarVM = new EditarDespesaViewModel(despesa.Id, despesa.Descricao, despesa.DataOcorrencia, despesa.Valor, categoriasDisponiveis, despesa.Categorias);

            return View(editarVM);
        }

        [HttpPost("Editar/{id:guid}")]
        public IActionResult Editar(EditarDespesaViewModel editarVM)
        {
            List<Categoria> categoriasDisponiveis = repositorioCategoria.SelecionarRegistros();

            if (!ModelState.IsValid)
            {
                Despesa despesa = repositorioDespesa.SelecionarRegistroPorId(editarVM.Id);
                categoriasDisponiveis = repositorioCategoria.SelecionarRegistros();
                editarVM = new EditarDespesaViewModel(despesa.Id, despesa.Descricao, despesa.DataOcorrencia, despesa.Valor, categoriasDisponiveis, despesa.Categorias);
                return View(editarVM);
            }

            Despesa despesaAtualizada = new Despesa(editarVM.Descricao, editarVM.DataOcorrencia, editarVM.Valor, editarVM.FormaPagamento, new List<Categoria>());

            foreach (var cs in editarVM.CategoriasSelecionadas)
            {
                foreach (Categoria c in categoriasDisponiveis)
                {
                    if (cs == c.Id)
                        despesaAtualizada.Categorias.Add(c);
                }
            }

            repositorioDespesa.Editar(editarVM.Id, despesaAtualizada);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Excluir/{id:guid}")]
        public IActionResult Excluir(Guid id)
        {
            Despesa despesa = repositorioDespesa.SelecionarRegistroPorId(id);

            ExcluirDespesaViewModel excluirVM = new ExcluirDespesaViewModel(despesa.Id, despesa.Descricao);

            return View(excluirVM);
        }

        [HttpPost("Excluir/{id:guid}")]
        public IActionResult ExclusaoConfirmada(Guid id)
        {
            repositorioDespesa.Excluir(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
