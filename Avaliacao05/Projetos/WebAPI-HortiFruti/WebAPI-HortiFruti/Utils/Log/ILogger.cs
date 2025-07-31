using System;
using System.Threading.Tasks;

namespace WebAPI_HortiFruti.Utils.Log
{
    internal interface ILogger
    {
        Task Log(Exception ex);
    }
}
