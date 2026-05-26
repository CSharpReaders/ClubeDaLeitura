
namespace ClubeDaLeituraWeb.WebApp.ModuloAmigos.Apresentacao
{
    public record ListarAmigoViewModel(
        string Id,
        string Nome,
        string NomeResponsavel,
        string Telefone
    );
    public record CadastrarAmigoViewModel(
        string Nome,
        string NomeResponsavel,
        string Telefone
    );
    public record ExcluirAmigoViewModel(
        string Id,
        string Nome,
        string NomeResponsavel,
        string Telefone
    );
    public record EditarAmigoViewModel(
        string Id,
        string Nome,
        string NomeResponsavel,
        string Telefone
    );
}