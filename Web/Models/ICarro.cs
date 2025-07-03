using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal interface ICarro
    {

        int Id { get; set; }

        string Nome { get; set; }

        double Valor { get; set; }

    }
}
