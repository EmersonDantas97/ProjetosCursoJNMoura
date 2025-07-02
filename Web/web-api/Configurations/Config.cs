using System;
using System.IO;

namespace web_api.Configurations
{
    public static class Config
    {
        public static string GetLogPath()
        {
            string logPath = System.Configuration.ConfigurationManager.AppSettings["DiretorioLogs"];

            logPath = Path.Combine(logPath, $"{DateTime.Now.ToString("yyyy-MM-dd")}.txt");

            return logPath;
        }
        public static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ConnectionString;
        }
        public static string GetConnectionString(string nome)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[nome].ConnectionString;
        }

        public static int GetCacheExpirationTime(string chave)
        {
            return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings[chave]);
        }

        internal static string GetConnectionStringSQLServer()
        {
            return GetConnectionString();
        }
    }
}