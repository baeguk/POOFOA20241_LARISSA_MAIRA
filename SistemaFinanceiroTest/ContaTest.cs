using ControleContas.Model;
using SistemaFinanceiro.Model;

namespace SistemaFinanceiroTest
{
    [TestClass]
    public class ContaTest
    {


        [TestMethod]
        public void DepositoTest()
        {
            //cenario

            Banco bradesco = new Banco(123, "Bradesco");
            Agencia agencia123b = new Agencia(1, "12345667878", "334455678", bradesco);

            Cliente cliente1 = new Cliente("Frederico", "12345678923", 1999);
            decimal saldoInicial = 1000;
            decimal valorDeposito = 1000;
            decimal saldoFinal = 2000;
            Conta conta1 = new Conta("123", saldoInicial, cliente1, agencia123b);

            //ação
            conta1.Deposito(valorDeposito);

            //verificação
            Assert.AreEqual(saldoFinal, conta1.Saldo);
        }

        [TestMethod]
        public void SaqueTest()
        {
            //cenario

            Banco bradesco = new Banco(123, "Bradesco");
            Agencia agencia123b = new Agencia(1, "12345667878", "334455678", bradesco);

            Cliente cliente1 = new Cliente("Frederico", "12345678923", 1999);
            decimal saldoInicial = 1000;
            decimal valorSaque = 500;
            decimal saldoFinal = 499.90m;
            Conta conta1 = new Conta("123", saldoInicial, cliente1, agencia123b);

            //ação
            conta1.Saque(valorSaque);

            //verificação
            Assert.AreEqual(saldoFinal, conta1.Saldo);
        }

        [TestMethod]
        public void ValorSaqueMaiorSaldo()
        {
            //cenario
            Banco bradesco = new Banco(123, "Bradesco");
            Agencia agencia123b = new Agencia(1, "12345667878", "334455678", bradesco);

            Cliente cliente1 = new Cliente("Frederico", "12345678923", 1999);
            decimal saldoInicial = 1000;
            decimal valorSaque = 1500;
            Conta conta1 = new Conta("123", saldoInicial, cliente1, agencia123b);

            //verificação (Espera error)
            Assert.ThrowsException<ArgumentException>(() => conta1.Saque(valorSaque));
        }

        [TestMethod]
        public void TransferenciaTest()
        {
            //cenario
            Banco bradesco = new Banco(123, "Bradesco");
            Agencia agencia123b = new Agencia(1, "12345667878", "334455678", bradesco);
            Cliente cliente1 = new Cliente("Frederico", "12345678923", 1999);
            Cliente cliente2 = new Cliente("Borges", "99999999999", 1982);

            decimal saldoInicialConta2 = 5000;

            decimal saldoInicialConta1 = 1000;
            decimal valorTransferencia = 500;

            Conta conta1 = new Conta("123", saldoInicialConta1, cliente1, agencia123b);
            Conta conta2 = new Conta("666", saldoInicialConta2, cliente2, agencia123b);

            conta1.Transferir(conta2, valorTransferencia);

            //verificação
            Assert.AreEqual(saldoInicialConta1 - (valorTransferencia + 0.10m), conta1.Saldo);
            Assert.AreEqual(saldoInicialConta2 + valorTransferencia, conta2.Saldo);
        }
    }
}