using System;

/*
 Faça um Programa que pergunte quanto você ganha por hora 
 e o número de horas trabalhadas no mês. 
 Calcule e mostre o total do seu salário no referido mês, 
 sabendo-se que são descontados 11% para o Imposto de Renda, 
 8% para o INSS e 5% para o sindicato, 
 
 Assim, o programa de exibir:
    salário bruto = gnho por hora * horas trabalhadas no mês
    quanto pagou ao IR
    quanto pagou ao INSS
    quanto pagou ao Sindicato
    Salário líquido = Salário Bruto - Descontos

dessa forma:

+ Salário Bruto : R$  
- IR (11%) : R$
- INSS (8%) : R$
- Sindicato (5%) : R$
= Salário Liquido : R$

 */

namespace Salario
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const double descontoImpostoRenda = 0.11;
            const double descontoINSS = 0.08;
            const double descontoSindicato = 0.05;

            double salarioBruto;
            double valorDescontoImpostoRendaEmRS;
            double valorDescontoINSSEmRS;
            double valorDescontoSindicatoEmRS;
            double descontosTotais;
            double salarioLiquido;

            Console.WriteLine("\n--------- CALCULO DE SALÁRIO");

            Console.Write("\nDigite o valor que você recebe por hora: ");
            double salarioPorHora = double.Parse(Console.ReadLine());

            Console.Write("\nDigite a quantidade de horas trabalhadas no mês: ");
            int horasTrabalhadasNoMes = int.Parse(Console.ReadLine());

            salarioBruto = salarioPorHora * horasTrabalhadasNoMes;
            valorDescontoImpostoRendaEmRS = salarioBruto * descontoImpostoRenda;
            valorDescontoINSSEmRS = salarioBruto * descontoINSS;
            valorDescontoSindicatoEmRS = salarioBruto * descontoSindicato;
            descontosTotais = valorDescontoImpostoRendaEmRS + valorDescontoINSSEmRS + valorDescontoSindicatoEmRS;
            salarioLiquido = salarioBruto - descontosTotais;

            Console.WriteLine($"\n+ Salário Bruto : R$ {salarioBruto:0.00}");
            Console.WriteLine($"- IR (11%) : R$ {valorDescontoImpostoRendaEmRS:0.00}");
            Console.WriteLine($"- INSS (8%) : R$ {valorDescontoINSSEmRS:0.00}");
            Console.WriteLine($"- Sindicato (5%) : R$ {valorDescontoSindicatoEmRS:0.00}");
            Console.WriteLine($"= Salário Liquido : R$ {salarioLiquido:0.00}");

            Console.Write("\nPressione ENTER para finalizar o programa!");
            Console.ReadLine();
        }
    }
}
