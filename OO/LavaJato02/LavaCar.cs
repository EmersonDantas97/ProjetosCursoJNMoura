using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaJato02
{
    public class LavaCar
    {
        private Queue<Carro> filaDeCarrosParaLavar { get; }
        private List<Carro> carrosNoPatio { get; }

        public LavaCar()
        {
            filaDeCarrosParaLavar = new Queue<Carro>();
            carrosNoPatio = new List<Carro>();
        }

        public void AdicionarCarroParaLavar(Carro carro)
        {
            filaDeCarrosParaLavar.Enqueue(carro);
        }

        public int QuantidadeDeCarrosParaLavar()
        {
            int qtdCarros = filaDeCarrosParaLavar.Count();
            return qtdCarros;
        }

        public int QuantidadeDeCarrosNoPatio()
        {
            int qtdCarros = carrosNoPatio.Count();
            return qtdCarros;
        }

        public List<Carro> ListaDeCarrosNoPatio()
        {
            return carrosNoPatio;
        }

        public Carro LavarCarro()
        {
            Carro carroSendoLavado = filaDeCarrosParaLavar.Dequeue();
            carrosNoPatio.Add(carroSendoLavado);
            return carroSendoLavado;
        }

        public bool RemoveCarro(uint IdCarro)
        {
            bool carroRemovido = false;


            return carroRemovido;
        }

        public bool TemCarroNoLavaCar()
        {
            bool temCarro = false;

            if (filaDeCarrosParaLavar.Count > 0 || carrosNoPatio.Count > 0)
                temCarro = true;

            return temCarro;
        }

        public bool TemCarroNoPatio()
        {
            bool temCarro = false;

            if (carrosNoPatio.Count > 0)
                temCarro = true;

            return temCarro;
        }

        public bool TemCarroParaLavar()
        {
            bool temCarro = false;

            if (filaDeCarrosParaLavar.Count > 0)
                temCarro = true;

            return temCarro;
        }
    }
}
