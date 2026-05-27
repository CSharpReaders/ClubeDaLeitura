
namespace ClubeDaLeituraWeb.WebApp.ModuloRevista.Infra;

public record ListarRevistaViewModels(
    string Id,
    string Titulo,
    int NumeroEdicao,
    int AnoPublicacao,
    string NomeCaixa
);
public record CadastrarRevistaViewModel(
    string Titulo,
    int NumeroEdicao,
    int AnoPublicacao,
    string IdCaixa
);
public record EditarRevistaViewModel(
    string Titulo,
    int NumeroEdicao,
    int AnoPublicacao,
    string IdCaixa
);