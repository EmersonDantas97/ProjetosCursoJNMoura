using System;
using System.IO;

namespace web_api.Utils
{
    public static class Logger
    {
        public static void RegistraLog(string path, Exception ex)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write("Data:");
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sw.Write("Erro:");
                sw.WriteLine(ex.Message);
                sw.Write("StackTrace:");
                sw.WriteLine(ex.StackTrace);
                sw.Write("---------------------------------------------------------------------------------");
            }
        }
    }
}