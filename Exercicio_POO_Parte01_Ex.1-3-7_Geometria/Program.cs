namespace Exercicio_POO_Parte01_Ex._1_3_7_Geometria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var opcao = "1";
            while (true)
            {
                Console.WriteLine("Qual forma geométrica deseja consultar?");
                Console.WriteLine("1.Círculo.");
                Console.WriteLine("2.Triângulo");
                Console.WriteLine("3.Retângulo");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        VerCirculo();
                        break;

                    case "2":
                        VerTriangulo();

                        break;

                    case "3":
                        VerRetangulo();
                        break;
                }

                Console.WriteLine("Deseja consultar outra forma? (s/n):");
                string novaConsulta = Console.ReadLine();
                if (novaConsulta.ToLower() != "s")
                {
                    break;
                }
                Console.Clear();
            }
        }

        private static void VerRetangulo()
        {
            Console.WriteLine("Digite a altura do retângulo:");
            double altura = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite a largura do retângulo:");
            double largura = double.Parse(Console.ReadLine());
            Console.WriteLine();
            Retangulo retangulo01 = new Retangulo(altura, largura);
            var areaRetangulo = retangulo01.calcularArea();
            var perimetroRetangulop = retangulo01.calcularPerimetro();
            Console.WriteLine($"A área do retângulo é de {areaRetangulo} e seu perimetro é de {perimetroRetangulop}");
        }

        private static void VerTriangulo()
        {
            Console.WriteLine("Digite os três lados do triangulo separando por espaço:");
            string lados = Console.ReadLine();
            string[] ladosString = lados.Split(' ');

            double ladoA = double.Parse(ladosString[0]);
            double ladoB = double.Parse(ladosString[1]);
            double ladoC = double.Parse(ladosString[2]);

            Triangulo triangulo01 = new Triangulo(ladoA, ladoB, ladoC);
            if (triangulo01.valido())
            {
                var areaTriangulo = triangulo01.calcularArea();
                Console.WriteLine($"A area do triãngulo é:{areaTriangulo}");
            }
            else
            {
                Console.WriteLine($"Erro ao calcular área do triângulo.\nValores informados não formam um triângulo");
            }
        }

        private static void VerCirculo()
        {
            Console.WriteLine("Digite o raio do círculo a ser calculado:");
            double raio = double.Parse(Console.ReadLine());
            Circulo circulo01 = new Circulo(raio);
            var area = circulo01.CalcularArea();
            Console.WriteLine($"A area do circulo é:{area}");
            var perimetro = circulo01.CalcularPerimetro();
            Console.WriteLine($"O perimetro do circulo é:{perimetro}");
        }
    }
}