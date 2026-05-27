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
                r.Caixa.Etiqueta
            );
            listarVmS.Add(vm);
        }
        return View(listarVmS);
    }
}