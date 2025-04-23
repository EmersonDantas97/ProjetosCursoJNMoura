using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDeDiversao02
{
    internal class Parque : IParque
    {
        List<Pessoa> visitantes;
        List<Bilheteria> bilheterias;
        List<Brinquedo> brinquedos;
        List<IEletrico> brinquedosEletricos;

        public Parque()
        {

            visitantes = new List<Pessoa>();
            bilheterias = new List<Bilheteria>();
            brinquedos = new List<Brinquedo>();
            brinquedosEletricos = new List<IEletrico>();
        }

        public void Abrir()
        {
            foreach (var item in brinquedos)
            {
                item.Abrir();
            }

            foreach (var item in brinquedosEletricos)
            {
                item.Ligar();
            }
        }

        public void AdicionarVisitante(Pessoa p1)
        {
            visitantes.Add(p1);
        }
        public void AdicionarAListaDeBrinquedos(Brinquedo b1)
        {
            brinquedos.Add(b1);
        }
        public void AdicionarAListaDeBrinquedosEletricos(IEletrico Ibe1)
        {
            brinquedosEletricos.Add(Ibe1);
        }
        public void AdicionarBilheteriasNaListaDoParque(Bilheteria b1)
        {
            bilheterias.Add(b1);
        }
        public void Fechar()
        {
            foreach (var item in brinquedos)
            {
                item.Fechar();
            }
            foreach (var item in brinquedosEletricos)
            {
                item.Desligar();
            }
        }
    }
}
