using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebAPI_HortiFruti.Utils.Log
{
    public class Logger
    {

        readonly string logPath;

        public Logger(string logPath)
        {
            this.logPath = logPath;
        }

        public async Task Log(Exception ex)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\nData");
            sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.Append("\nMensagem:");
            sb.Append(ex.Message);
            sb.Append("\nStackTrace:");
            sb.Append(ex.StackTrace);
            sb.Append("\n------------------------------------------------------------");

            using (StreamWriter sw = new StreamWriter(logPath, true))
            {
                await sw.WriteAsync(sb.ToString());
            }
        }

    }

}