using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDeDiversao02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Criando parque
            Parque betoCarreiro = new Parque();

            MontanhaRussa montanhaRussa = new MontanhaRussa();
            TrombaTromba trombaTromba = new TrombaTromba();
            Carrossel carrossel = new Carrossel();
            RodaGigante rodaGigante = new RodaGigante();
            TiroAoAlvo tiroAoAlvo = new TiroAoAlvo();
            Pescaria pescaria = new Pescaria();

            Bilheteria bilheteria1 = new Bilheteria();
            Bilheteria bilheteria2 = new Bilheteria();
            Bilheteria bilheteria3 = new Bilheteria();

            Pessoa visitante1 = new Pessoa("Pedro", 28);
            Pessoa visitante2 = new Pessoa("Joao", 28);
            Pessoa visitante3 = new Pessoa("Maria", 45);

            // Adicionando brinquedos a lista do parque
            betoCarreiro.AdicionarAListaDeBrinquedos(montanhaRussa);
            betoCarreiro.AdicionarAListaDeBrinquedos(trombaTromba);
            betoCarreiro.AdicionarAListaDeBrinquedos(carrossel);
            betoCarreiro.AdicionarAListaDeBrinquedos(rodaGigante);
            betoCarreiro.AdicionarAListaDeBrinquedos(tiroAoAlvo);
            betoCarreiro.AdicionarAListaDeBrinquedos(pescaria);

            // Adicionando brinquedos a lista do parque de briquedos eletricos
            betoCarreiro.AdicionarAListaDeBrinquedosEletricos(montanhaRussa);
            betoCarreiro.AdicionarAListaDeBrinquedosEletricos(trombaTromba);
            betoCarreiro.AdicionarAListaDeBrinquedosEletricos(carrossel);
            betoCarreiro.AdicionarAListaDeBrinquedosEletricos(rodaGigante);

            // Adicionando bilheterias a lista do parque
            betoCarreiro.AdicionarBilheteriasNaListaDoParque(bilheteria1);
            betoCarreiro.AdicionarBilheteriasNaListaDoParque(bilheteria2);
            betoCarreiro.AdicionarBilheteriasNaListaDoParque(bilheteria3);

            betoCarreiro.Abrir();

            // Criando visitante

            // Adicionando visitantes
            betoCarreiro.AdicionarVisitante(visitante1);
            betoCarreiro.AdicionarVisitante(visitante2);
            betoCarreiro.AdicionarVisitante(visitante3);

            betoCarreiro.Fechar();

        }
    }
}
