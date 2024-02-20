using System;

namespace Exercicio_POO_Parte01.Ex08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Informe a marca do carro:");
                string marca = Console.ReadLine();

                Console.WriteLine("Informe o modelo do carro:");
                string modelo = Console.ReadLine();

                Carro carro = new Carro(marca, modelo, 0);

                Console.WriteLine("Velocidade inicial: " + carro.ExibirVelocidadeCarro());

                Console.WriteLine("Informe a aceleracao do carro:");
                int aceleracao = int.Parse(Console.ReadLine());
                carro.AcelerarCarro(aceleracao);
                Console.WriteLine("Velocidade após acelerar: " + carro.ExibirVelocidadeCarro());

                Console.WriteLine("Informe a desaceleração do carro:");
                int desaceleracao = int.Parse(Console.ReadLine());
                carro.FrearCarro(desaceleracao);
                Console.WriteLine("Velocidade após frear: " + carro.ExibirVelocidadeCarro());

                Console.ReadLine();

                Console.WriteLine("Deseja realizar uma nova consulta? (s/n):");
                string novaConsulta = Console.ReadLine();
                if (novaConsulta.ToLower() != "s")
                {
                    break;
                }
                Console.Clear();

            }
        }
    }
}
