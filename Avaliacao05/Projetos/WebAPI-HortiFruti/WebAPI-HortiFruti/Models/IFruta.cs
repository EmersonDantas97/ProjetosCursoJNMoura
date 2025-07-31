using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_HortiFruti.Models
{
    internal interface IFruta
    {

        int Id { get; set; }
        string Nome { get; set; }
        DateTime DataVenc { get; set; }

    }
}
