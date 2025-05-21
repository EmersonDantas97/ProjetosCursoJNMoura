using System;
using System.IO;
using System.Web;

namespace web_api
{
    public static class DiretoriosSistema
    {
        public static string DiretorioArquivoLogs()
        {
            string nomeDoArquivo = System.Configuration.ConfigurationManager.AppSettings["DiretorioLogs"];

            //Pegando diretorio fisico da aplicacao
            string caminhoApp = HttpContext.Current.Server.MapPath("~/");

            return nomeDoArquivo.Replace("~", caminhoApp);
        }
    }
}

//Para pegar a home do pc.
//string caminhoHomeDoPc = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");