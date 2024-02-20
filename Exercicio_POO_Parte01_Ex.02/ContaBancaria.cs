using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_POO_Parte01_Ex._02
{
    internal class ContaBancaria
    {
        private double _numeroConta;
        private double _saldo;
        private string _nomeTitular;

        public ContaBancaria(double numeroConta, double saldo, string nomeTitular)
        {
            _numeroConta = numeroConta;
            _saldo = saldo;
            _nomeTitular = nomeTitular;
        }

        public double verSaldo()
        {
            return _saldo;
        }

        public void RealizarDeposito(double valor)
        {
            _saldo = _saldo + valor;
        }
        public void RealizarSaque(double valor)
        {
            _saldo = _saldo - valor;
        }
    }
}
    

