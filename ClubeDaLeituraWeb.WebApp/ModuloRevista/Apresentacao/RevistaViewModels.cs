using ClubeDaLeituraWeb.WebApp.ModuloCaixa.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloRevista.Infra;

public record ListarRevistaViewModels(
    string Id,
    string Titulo,
    int NumeroEdicao,
    int AnoPublicacao,
    string NomeCaixa
);