using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace web_api.Utils
{
    public static class Logger
    {
        public static async Task RegistraLog(string path, Exception ex)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\nData: ");
            sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.Append("\nMensagem: ");
            sb.Append(ex.Message);
            sb.Append("\nStackTrace: ");
            sb.Append(ex.StackTrace);
            sb.Append("\n-----------------------------------------------");

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                await sw.WriteAsync(sb.ToString());
            }
        }
    }
}