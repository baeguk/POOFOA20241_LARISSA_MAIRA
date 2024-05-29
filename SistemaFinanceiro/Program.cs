using ControleContas.Model;
using SistemaFinanceiro.Model;


Cliente cliente1 = new Cliente("Frederico", "12345678923", 1999);
Cliente cliente2 = new Cliente("Ramiro", "12345678910", 1976);

Banco bradesco = new Banco(123, "Bradesco");

Agencia agencia123b = new Agencia(101010,"12345667878","334455678",bradesco);

Conta conta1 = new Conta("123", 1000, cliente1,agencia123b);
Conta conta2 = new Conta("654321", 2341.42m,cliente2,agencia123b );


Console.WriteLine($"O saldo total de todas as contas cadastradas é R${Conta.SaldoTotal}");

Console.WriteLine($"O saldo total da conta {conta1.Numero} é R${conta1.Saldo}");

Console.WriteLine($"A conta de maior saldo é {Conta.ContaMaiorSaldo} com R${Conta.MaiorSaldo}");

Console.WriteLine($"A conta {conta2.Numero} pertence à agência de número {conta2.Agencia.Numero}, tem R${conta2.Saldo} de saldo e pertence ao cliente {conta2.Titular.Nome}");