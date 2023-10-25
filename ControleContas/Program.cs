
using ControleContas.Model;
Cliente cliente1 = new Cliente("Fred", "12345678901", 2000);
Conta conta = new Conta("1234",cliente1);
Conta conta2 = new Conta("4321", 1000.99m, cliente1);
Console.WriteLine($"Conta: {conta.Numero}; Saldo: {conta.Saldo}");
Conta conta3 = new Conta("654321", 2341.42m, cliente1);

Console.WriteLine($"O saldo total é {conta2.SaldoTotal}");
Console.WriteLine($"A conta de maior saldo é {conta2.ContaMaiorSaldo}");

conta.Titular = cliente1;
conta2.Titular = cliente1;

Console.WriteLine($"O titular da conta {conta.Numero} é o cliente {conta.Titular.Nome}");
