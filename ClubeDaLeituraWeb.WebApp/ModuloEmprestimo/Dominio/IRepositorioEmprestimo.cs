using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra;
using ClubeDaLeituraWeb.WebApp.ModuloEmprestimo.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloRevista.Dominio;

public interface IRepositorioEmprestimo : IRepositorio<Emprestimo>
{
    List<Emprestimo> SelecionarConcluidos();
    List<Emprestimo> SelecionarEmAberto();
}
