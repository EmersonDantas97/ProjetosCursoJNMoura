using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porta
{
    internal class Porta
    {
        private bool aberta;
        private string cor;
        private double dimensaoX;
        private double dimensaoY;
        private double dimensaoZ; 

        public void vouAbrir()
        {
            this.aberta = true;
        }

        public void fechar()
        {
            this.aberta = false;
        }

        private void pintar(string cor)
        {
            this.cor = cor;
        }
        public void pintarAmarelo()
        {
            pintar("Amarelo");
        }

        public void pintarPreto()
        {
            pintar("Preto");
        }
        public void pintarVerde()
        {
            pintar("Verde");
        }

        //public bool pintarPadrao(string cor)
        //{
        //    if (cor == "Amarelo" || cor == "Verde" || cor == "Preto")
        //    {
        //        this.cor = cor;
        //        return true;
        //    }
        //        return false;
        //}

        public bool estaAberta()
        {
            return aberta;
        }

        public string getCor()
        {
            return cor;
        }

        public Porta()
        {
            this.aberta = false;
            this.cor = "Branca";
            this.dimensaoX = 0.00;
            this.dimensaoY = 0.00;
            this.dimensaoZ = 0.00;
        }

        public Porta(bool aberta, string cor,double dimensaoX, double dimensaoY, double dimensaoZ)
        {
            this.aberta = aberta;
            this.cor = cor;
            this.dimensaoX = dimensaoX;
            this.dimensaoY = dimensaoY;
            this.dimensaoZ = dimensaoZ;
        }
    }
}
