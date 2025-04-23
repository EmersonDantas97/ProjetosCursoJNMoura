using System;
using System.Collections.Generic;

namespace LojaEletrodomesticos
{
    internal class Loja
    {
        private Queue<Eletrodomestico> listaParaConserto = new Queue<Eletrodomestico>();
        private List<Eletrodomestico> listaEletrosConsertados = new List<Eletrodomestico>();

        public void EntregueParaConsertar(Eletrodomestico eletrodomestico)
        {
            listaParaConserto.Enqueue(eletrodomestico);
        }
        
        public Eletrodomestico ConsertarEletrodomestico()
        {
            Eletrodomestico eletrodomesticoConsertado = listaParaConserto.Dequeue();

            eletrodomesticoConsertado.Defeito = false;

            listaEletrosConsertados.Add(eletrodomesticoConsertado);

            return eletrodomesticoConsertado;
        }

        public bool TemEletrodomesticosProntosParaRetirada()
        {
            return listaEletrosConsertados.Count > 0 ? true : false;
        }

        public bool TemEletrodomesticoParaConserto()
        {
            return listaParaConserto.Count > 0 ? true : false;
        }

        public bool RetirarEletrodomestico(string nomeEletrodomestico)
        {
            bool itemRemovido = false;

            foreach (var item in listaEletrosConsertados)
            {
                if (item.Nome == nomeEletrodomestico)
                {
                    listaEletrosConsertados.Remove(item);
                    itemRemovido = true;
                    break;
                }
            }
            return itemRemovido;
        }
    }
}
