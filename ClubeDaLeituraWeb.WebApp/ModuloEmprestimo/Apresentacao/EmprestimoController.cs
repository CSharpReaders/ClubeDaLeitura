using ClubeDaLeituraWeb.WebApp.ModuloAmigos.Apresentacao;
using ClubeDaLeituraWeb.WebApp.ModuloAmigos.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloEmprestimo.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloRevista.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloRevista.Infra;
using Microsoft.AspNetCore.Mvc;

namespace ClubeDaLeituraWeb.WebApp.ModuloEmprestimo.Apresentacao;

public class EmprestimoController : Controller
{
    private readonly IRepositorioEmprestimo repositorioEmprestimo;
    private readonly IRepositorioAmigo repositorioAmigo;
    private readonly IRepositorioRevista repositorioRevista;

    public EmprestimoController(IRepositorioEmprestimo repositorioEmprestimo, IRepositorioAmigo repositorioAmigo, IRepositorioRevista repositorioRevista)
    {
        this.repositorioEmprestimo = repositorioEmprestimo;
        this.repositorioAmigo = repositorioAmigo;
        this.repositorioRevista = repositorioRevista;
    }

    public ActionResult Listar()
    {
        List<Emprestimo> emprestimos = repositorioEmprestimo.SelecionarTodos();

        List<ListarEmprestimoViewModel> vmListar = new();

        foreach (Emprestimo e in emprestimos)
        {
            ListarEmprestimoViewModel vm = new(
                e.Id,
                e.Amigo.Nome,
                e.Revista.Titulo,
                e.DataEmprestimo.ToShortDateString(),
                e.DataDevolucao.ToShortDateString(),
                e.Status.ToString()
            );
            vmListar.Add(vm);
        }
        return View(vmListar);
    }
    public ActionResult Cadastrar()
    {
        ViewBag.Amigos = CarregarAmigo();
        ViewBag.Revistas = CarregarRevista();

        return View();
    }
    [HttpPost]
    public ActionResult Cadastrar(CadastrarEmprestimoViewModel vmCadastro)
    {
        Amigo? amigo = repositorioAmigo.SelecionarPorId(vmCadastro.IdAmigo);
        Revista? revista = repositorioRevista.SelecionarPorId(vmCadastro.IdRevista);

        if (amigo != null && revista != null)
        {
            Emprestimo e = new(amigo, revista);

            //muda o status da revista para Emprestado
            if (revista.Status == StatusRevista.Disponivel && amigo.Emprestimo == null)
            {
                //muda o status da revista para Emprestada
                revista.Emprestar();

                //adiciona o emprestimo ao amigo
                amigo.AddEmprestimo(e);

                repositorioEmprestimo.Cadastrar(e);

                return RedirectToAction(nameof(Listar));

            }
            //aqui tem que fazer o else para caso as condicoes do IF forem falsas
        }
        return RedirectToAction(nameof(Cadastrar));
    }
    private List<ListarRevistaNomeViewModels> CarregarRevista()
    {
        List<Revista> revistas = repositorioRevista.SelecionarTodos();

        List<ListarRevistaNomeViewModels> vmListar = new();

        foreach (Revista r in revistas)
        {
            ListarRevistaNomeViewModels vm = new(
                r.Id,
                r.Titulo
            );
            vmListar.Add(vm);
        }
        return vmListar;
    }
    private List<ListarAmigoNomeViewModel> CarregarAmigo()
    {
        List<Amigo> amigos = repositorioAmigo.SelecionarTodos();

        List<ListarAmigoNomeViewModel> vmListar = new();

        foreach (Amigo r in amigos)
        {
            ListarAmigoNomeViewModel vm = new(
                r.Id,
                r.Nome
            );
            vmListar.Add(vm);
        }
        return vmListar;
    }
}
