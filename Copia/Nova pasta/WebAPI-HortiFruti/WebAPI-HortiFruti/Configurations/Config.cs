using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;

namespace WebAPI_HortiFruti.Configurations
{
    public static class Config
    {

        // GetLogPath
        public static string GetLogPath()
        {
            return GetLogPath("logPath");
        }

        // GetLogPath
        public static string GetLogPath(string chave)
        {
            string logPath = System.Configuration.ConfigurationManager.AppSettings[chave];

            logPath = Path.Combine(logPath, $"{DateTime.Now.ToString("dd-MM-yyyyy")}.txt");

            return logPath;
        }

        // GetConnectionString
        public static string GetConnectionStringSQlServer()
        {
            return GetConnectionStringSQlServer("WebAPI-HortiFruti");
        }

        // GetConnectionStringSQLServer
        public static string GetConnectionStringSQlServer(string nome)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[nome].ConnectionString;
        }

        // GetCacheExpirationTimeInSeconds
        public static string GetCacheExpirationTimeInSeconds(string chave)
        {
            return System.Configuration.ConfigurationManager.AppSettings[chave];
        }


    }
}