using System;
using System.IO;

namespace web_api.Configurations
{
    public static class Config
    {
        public static string GetLogPath()
        {
            string logPath = System.Configuration.ConfigurationManager.AppSettings["logPath"];

            logPath = Path.Combine(logPath, $"{DateTime.Now.ToString("yyyy-MM-dd")}.txt");

            return logPath;
        }
        public static string GetConnectionString(string nome)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[nome].ConnectionString;
        }
    }
}