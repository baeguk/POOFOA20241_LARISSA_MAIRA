using ControleContas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Model
{
    public class Conta
    {

        private string _numero;
        protected decimal _saldo;
        private static decimal _saldoTotal;
        private static string _contaMaiorSaldo = "";
        private static decimal _maiorSaldo = 0;
        public Cliente Titular { get; set; }

        public Agencia Agencia { get; set; }

        public Agencia? agencia;

        /*
        public Conta(string numero, Cliente titular)
        {
            _numero = numero;
            Titular = titular;
        }
        */

        public Conta(string numero, decimal saldo, Cliente titular, Agencia agencia) 
        {

            _saldo = saldo;
            _numero = numero;
            _saldoTotal += saldo;
            Agencia = agencia;
            Titular = titular;

            if(_saldo < 10)
            {
                throw new ArgumentException("Saldo deve ser pelo menos R$10,00");
            }
            if (_saldo > _maiorSaldo)
            {
                _maiorSaldo = _saldo;
                _contaMaiorSaldo = _numero;
            }

        }

        public string Numero
        {
            get => _numero;
            private set => _numero = value;
        }
        public  decimal Saldo
        {
            get => _saldo;
            protected set => _saldo = value;
        }
        public static decimal SaldoTotal
        {
            get => _saldoTotal;
            private set => _saldoTotal = value;
        }

        public static string ContaMaiorSaldo
        {
            get => _contaMaiorSaldo;
        }

        public static decimal MaiorSaldo
        {
            get => _maiorSaldo;
        }


        public decimal Deposito(decimal valor)
        {
            _saldo += valor;
            return _saldo;
        }

        public bool Saque(decimal valor)
        {

            if (_saldo + 0.10m < valor)
            {
                throw new ArgumentOutOfRangeException("Valor do Saque insuficiente");
            }
            if (valor < 0)
            {
                throw new ArgumentOutOfRangeException("Valor do Saque tem que ser positivo");
            }
            _saldo -= valor + 0.10m;

            return true;

        }

        public bool Transferir(Conta destino, decimal valor)
        {
            if (Saque(valor))
            {
                destino.Deposito(valor);
                return true;
            }
            return false;
        }
    }
}
