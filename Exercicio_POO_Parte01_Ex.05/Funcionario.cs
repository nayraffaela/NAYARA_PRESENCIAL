namespace Exercicio_POO_Parte01_Ex._05
{
    internal class Funcionario
    {
        public string Nome { get; set; }
        public double SalarioBruto { get; set; }
        public double DescontoOutros { get; set; }
        public string Cargo { get; set; }

        public Funcionario(string nome, double salarioBruto,  string cargo, double descontoOutros)
        {
            Nome = nome;
            SalarioBruto = salarioBruto;
           
            Cargo = cargo;
        }
        public double CalcularSalarioLiquido()
        {
            
            double salarioLiquido = SalarioBruto - DescontoOutros - CalculaInss() - CalculaIrpf();
            return salarioLiquido;
        }

        public double CalculaInss()
        {
            if (SalarioBruto < 1200)
            {
                return 0.075;
            }
            else if (SalarioBruto < 2417)
            {
                return 0.09;
            }
            else if (SalarioBruto < 3641)
            {
                return 0.12;
            }
            else return 0.14;
        }

        public double CalculaIrpf()
        {
            if (SalarioBruto < 1200)
            {
                return 0.075;
            }
            else if (SalarioBruto < 2417)
            {
                return 0.09;
            }
            else if (SalarioBruto < 3641)
            {
                return 0.12;
            }
            else return 0.14;
        }
    }
}
