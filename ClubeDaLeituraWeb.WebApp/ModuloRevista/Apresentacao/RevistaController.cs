using ClubeDaLeituraWeb.WebApp.ModuloCaixa.Apresentacao;
using ClubeDaLeituraWeb.WebApp.ModuloCaixa.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloRevista.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloRevista.Infra;
using Microsoft.AspNetCore.Mvc;

namespace ClubeDaLeituraWeb.WebApp.ModuloRevista.Apresentacao;

public class RevistaController : Controller
{
    private readonly IRepositorioCaixa repostiorioCaixa;
    private readonly IRepositorioRevista repositorioRevista;

    public RevistaController(IRepositorioCaixa repostiorioCaixa, IRepositorioRevista repositorioRevista)
    {
        this.repostiorioCaixa = repostiorioCaixa;
        this.repositorioRevista = repositorioRevista;
    }


    public ActionResult Listar()
    {
        List<Revista> listaDeRevista = repositorioRevista.SelecionarTodos();

        List<ListarRevistaViewModels> listarVmS = new();

        foreach (Revista r in listaDeRevista)
        {
            ListarRevistaViewModels vm = new(
                r.Id,
                r.Titulo,
                r.NumeroEdicao,
                r.AnoPublicacao,
                r.Caixa.Etiqueta,
                r.Status.ToString()
            );
            listarVmS.Add(vm);
        }
        return View(listarVmS);
    }
    [HttpGet]
    public ActionResult Cadastrar()
    {
        ViewBag.Caixas = CarregarCaixas();

        return View();
    }
    [HttpPost]
    public ActionResult Cadastrar(CadastrarRevistaViewModel vmCadastro)
    {
        // Aqui pegamos o IDCaixa da VM e fazemos um select no repositorio

        Caixa? caixaSelecionada = repostiorioCaixa.SelecionarPorId(vmCadastro.IdCaixa);

        if (caixaSelecionada != null)
        {
            Revista revistaCadastro = new(
            vmCadastro.Titulo,
            vmCadastro.NumeroEdicao,
            vmCadastro.AnoPublicacao,
            caixaSelecionada
        );
            repositorioRevista.Cadastrar(revistaCadastro);

        }
        return RedirectToAction(nameof(Listar));
    }
    [HttpGet]
    public ActionResult Editar(string id)
    {
        ViewBag.Caixas = CarregarCaixas();

        Revista? revista = repositorioRevista.SelecionarPorId(id);

        if (revista == null)
            return RedirectToAction(nameof(Listar));

        EditarRevistaViewModel vmEdidar = new(
            revista.Id,
            revista.Titulo,
            revista.NumeroEdicao,
            revista.NumeroEdicao,
            revista.Caixa.Id
        );

        return View(vmEdidar);
    }
    [HttpPost]
    public ActionResult Editar(EditarRevistaViewModel vmEditar)
    {
        Caixa? caixa = repostiorioCaixa.SelecionarPorId(vmEditar.IdCaixa);

        if (caixa != null)
        {
            Revista revistaAtualizada = new(
                vmEditar.Titulo,
                vmEditar.NumeroEdicao,
                vmEditar.AnoPublicacao,
                caixa
            );
            repositorioRevista.Editar(vmEditar.Id, revistaAtualizada);
        }

        return RedirectToAction(nameof(Listar));
    }
    [HttpGet]
    public ActionResult Excluir(string id)
    {

        ViewBag.Caixas = CarregarCaixas();

        Revista? revista = repositorioRevista.SelecionarPorId(id);

        if (revista == null)
            return RedirectToAction(nameof(Listar));

        ExcluirRevistaViewModel excluirVm = new(
            revista.Id,
            revista.Titulo,
            revista.NumeroEdicao,
            revista.AnoPublicacao,
            revista.Caixa.Id
        );

        return View(excluirVm);
    }
    [HttpPost]
    public ActionResult Excluir(ExcluirRevistaViewModel vmExlcuir)
    {
        Revista? revista = repositorioRevista.SelecionarPorId(vmExlcuir.Id);

        if (revista != null)
            repositorioRevista.Excluir(revista);

        return RedirectToAction(nameof(Listar));
    }
    private List<ListarCaixasViewModel> CarregarCaixas()
    {
        List<Caixa> caixas = repostiorioCaixa.SelecionarTodos();

        List<ListarCaixasViewModel> listarVms = new List<ListarCaixasViewModel>();

        foreach (Caixa c in caixas)
        {
            ListarCaixasViewModel viewModel = new ListarCaixasViewModel(
                c.Id,
                c.Etiqueta,
                c.Cor,
                c.DiasDeEmprestimo
            );

            listarVms.Add(viewModel);
        }

        return listarVms;
    }
}