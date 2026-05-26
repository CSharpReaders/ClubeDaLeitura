using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Arquivos;
using ClubeDaLeituraWeb.WebApp.ModuloAmigos.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloAmigos.Infra
{
    public class ReposiotiroAmigoEmArquivo : RepositorioBaseEmArquivo<Amigo>, IRepositorioAmigo
    {
        public ReposiotiroAmigoEmArquivo(ContextoJson contexto) : base(contexto) { }

        protected override List<Amigo> CarregarRegistros()
        {
            return contexto.Amigos;
        }
    }


}