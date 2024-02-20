using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercicio_POO_Parte02_Ex08
{
    internal class Calendario
    {
        public int Ano { get; set; }

        public Calendario(int ano)
        {
            this.Ano = ano;
        }

        public void MostrarCalendarioAnual()
        {
            Console.WriteLine($"Calendário para o ano de {Ano}:\n");

            for (int mes = 1; mes <= 12; mes++)
            {
                MostrarCalendarioMensal(mes);
            }
        }
        public void MostrarCalendarioMensal(int mes)
        {
            int diasNoMes = DateTime.DaysInMonth(Ano, mes);
            DateTime primeiroDiaDoMes = new DateTime(Ano, mes, 1);
            string nomeMes = primeiroDiaDoMes.ToString("MMMM");

            Console.WriteLine($"Calendário para {nomeMes} {Ano}:\n");

            for (int dia = 1; dia <= diasNoMes; dia++)
            {
                DateTime data = new DateTime(Ano, mes, dia);
                string nomeDiaSemana = data.ToString("dddd");
                Console.WriteLine($"{dia} - {nomeDiaSemana}");
            }

            Console.WriteLine();
        }
        public void ExibirFeriados()
        {
            Console.WriteLine($"Feriados para o ano de {Ano}:\n");
            Console.WriteLine("1 de Janeiro - Ano Novo");
            Console.WriteLine("12 de Fevereiro - Carnaval");
            Console.WriteLine("13 de Fevereiro - Carnaval");
            Console.WriteLine("29 de Março - Paixão de Cristo");
            Console.WriteLine("21 de Abril - Tiradentes");
            Console.WriteLine("1 de Maio - Dia do Trabalho");
            Console.WriteLine("30 de Maio - Corpus Christi");
            Console.WriteLine("7 de Setembro - Independência do Brasil");
            Console.WriteLine("12 de Outubro - Dia de Nossa Senhora Aparecida");
            Console.WriteLine("2 de Novembro - Finados");
            Console.WriteLine("15 de Novembro - Proclamação da República");
            Console.WriteLine("20 de Novembro - Dia Nacional de Zumbi e da Consciência Negra");
            Console.WriteLine("25 de Dezembro - Natal");
        }
        public void CalcularDiferençaDatas(DateTime data1, DateTime data2)
        {
            TimeSpan diferenca = data2 - data1;
            Console.WriteLine($"A diferença entre as datas é de {diferenca.TotalDays} dias.");
        }
    }
}
