using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porta
{

    public enum CorDaPorta
    {
        Nenhuma, Amarela, Verde, Vermelha
    }

    internal class Porta
    {
        private bool aberta;
        private CorDaPorta cor;
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

        private void pintar(CorDaPorta cor)
        {
            this.cor = cor;
        }
        public void pintarAmarelo()
        {
            pintar(CorDaPorta.Amarela);
        }

        public void pintarVermelha()
        {
            pintar(CorDaPorta.Vermelha);
        }
        public void pintarVerde()
        {
            pintar(CorDaPorta.Verde);
        }

        #region Maneira alternativa de fazer - Maneira mais primitiva
        //public bool pintarPadrao(string cor)
        //{
        //    if (cor == "Amarelo" || cor == "Verde" || cor == "Preto")
        //    {
        //        this.cor = cor;
        //        return true;
        //    }
        //        return false;
        //}
        #endregion

        public bool estaAberta()
        {
            return aberta;
        }

        public CorDaPorta getCor()
        {
            return cor;
        }

        public Porta()
        {
            this.aberta = false;
            this.cor = CorDaPorta.Nenhuma;
            this.dimensaoX = 0.00;
            this.dimensaoY = 0.00;
            this.dimensaoZ = 0.00;
        }

        public Porta(bool aberta, CorDaPorta cor, double dimensaoX, double dimensaoY, double dimensaoZ)
        {
            this.aberta = aberta;
            this.cor = cor;
            this.dimensaoX = dimensaoX;
            this.dimensaoY = dimensaoY;
            this.dimensaoZ = dimensaoZ;
        }
    }
}
