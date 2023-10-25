using ControleContas.Model;

namespace TestControleContas
{
    [TestClass]
    public class ControleContasTests
    {
        [TestMethod]
        public void SaqueComSaldoSuficiente()
        {
            //cenario
            decimal saldoInicial = 1000;
            decimal valorSaque = 500;
            decimal novoSaldo = 499.9m;
            Cliente cliente = new Cliente("Fulano", "12345678901", 2000);
            Conta conta = new Conta("10000", saldoInicial, cliente);

            //acao
            conta.Sacar(valorSaque);

            //verificacao
            decimal saldoAtual = conta.Saldo;
            Assert.AreEqual(novoSaldo, saldoAtual, 0.001m, "O saque nao foi debitado corretamente");
        }

        [TestMethod]
        public void SaqueComValorMaiorQueSaldo()
        {
            //cenario
            decimal saldoInicial = 1000;
            decimal valorSaque = 1500;
            Cliente cliente = new Cliente("Fulano", "12345678901", 2000);
            Conta conta = new Conta("10000", saldoInicial, cliente);

            //acao 
            try
            {
                conta.Sacar(valorSaque);
            }
            catch(ArgumentOutOfRangeException e)
            {
                //verificacao
                StringAssert.Contains(e.Message, Conta.SaqueMaiorQueSaldoMessage);
                return;
            }
            Assert.Fail("A excecao experada nao foi lancada");
        }

        [TestMethod]
        public void DepositoValorPositivo()
        {
            //cenario
            decimal saldoInicial = 1000;
            decimal valorDeposito = 1000;
            decimal novoSaldo = 2000;
            Cliente cliente = CriarCliente();
            Conta conta = new Conta("1000", saldoInicial, cliente);

            //acao
            conta.Depositar(valorDeposito);

            //verificacao
            Assert.AreEqual(novoSaldo, conta.Saldo, 0.001m, "Depósito não foi realizado corretamente");
        }
        [TestMethod]
        public void ContaSemSaldoInicial()
        {
            //Cenario e ação
            var cliente = CriarCliente();
            Conta conta = new Conta("1000", cliente);

            //verificação
            Assert.AreEqual(10.00m, conta.Saldo, 0.001m, "Saldo inicial está incorreto");
        }
        [TestMethod]
        public void ContaEspecialComLimite()
        {
            //cenário e ação
            var cliente = CriarCliente();
            var contaEspecial = new ContaEspecial("2000", cliente);
            decimal limiteInicial = 1000;

            //verificação
            Assert.AreEqual(limiteInicial, contaEspecial.Limite, 0.001m, "Limite não corresponde ao limite inicial especificado");
        }
        [TestMethod]
        public void SaqueContaEspecialComLimite()
        {
            //cenario
            var cliente = CriarCliente();
            decimal saldoInicial = 1000;
            decimal valorSaque = 1500;
            decimal saldoFinal = -499.9m;
            var contaEspecial = new ContaEspecial("2000", saldoInicial, cliente);
            //açao
            contaEspecial.Sacar(valorSaque);
            //verificacao
            Assert.AreEqual(saldoFinal, contaEspecial.Saldo, 0.001m, "Saldo final da conta especial não corresponde ao desejado");
        }


        [TestMethod]
        public void Conta_Depositar_SaldoAumenta()
        {
            // Arrange
            Cliente cliente = CriarCliente();
            Conta conta = new Conta("12345", cliente);

            // Act
            conta.Depositar(1000);

            // Assert
            Assert.AreEqual(1010, conta.Saldo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Conta_Depositar_ValorNegativo_Falha()
        {
            // Arrange
            Cliente cliente = CriarCliente();
            Conta conta = new Conta("67890", cliente);

            // Act
            conta.Depositar(-500);
        }

        [TestMethod]
        public void Conta_Transferir_SaldoSuficiente_Sucesso()
        {
            // Arrange
            Cliente cliente1 = CriarCliente();
            Cliente cliente2 = CriarCliente();
            Conta conta1 = new Conta("12345", cliente1);
            Conta conta2 = new Conta("67890", cliente2);

            // Act
            conta1.Depositar(1000);
            conta1.Transferir(conta2, 500);

            // Assert
            Assert.AreEqual(509.9m, conta1.Saldo);
            Assert.AreEqual(510, conta2.Saldo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Conta_Transferir_ValorNegativo_Falha()
        {
            // Arrange
            Cliente cliente1 = CriarCliente();
            Cliente cliente2 = CriarCliente();
            Conta conta1 = new Conta("12345", cliente1);
            Conta conta2 = new Conta("67890", cliente2);

            // Act
            conta1.Depositar(1000);
            conta1.Transferir(conta2, -200);
        }

        private Cliente CriarCliente()
        {
            return new Cliente("Fulano", "12345678901", 2000);
        }
    }
}