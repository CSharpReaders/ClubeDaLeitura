namespace ClubeDaLeituraWeb.WebApp.ModuloEmprestimo.Apresentacao;

public record ListarEmprestimoViewModel(
    string Id,
    string NomeAmigo,
    string NomeRevista,
    string DataInicial,
    string DataFinal,
    string Status
);
public record CadastrarEmprestimoViewModel(
    string IdAmigo,
    string IdRevista
);
