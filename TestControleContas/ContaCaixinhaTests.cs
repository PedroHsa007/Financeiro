using ControleContas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestControleContas
{
    [TestClass]
    public class ContaCaixinhaTests
    {
        [TestMethod]
        public void ContaCaixinha_Depositar_SaldoIncrementaEm1()
        {
            // Arrange
            Cliente cliente = CriarCliente();
            ContaCaixinha contaCaixinha = new ContaCaixinha("12345", cliente);

            // Act
            contaCaixinha.Depositar(100);

            // Assert
            Assert.AreEqual(111.00m, contaCaixinha.Saldo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ContaCaixinha_Depositar_ValorMenorQue1_Falha()
        {
            // Arrange
            Cliente cliente = CriarCliente();
            ContaCaixinha contaCaixinha = new ContaCaixinha("67890", cliente);

            // Act
            contaCaixinha.Depositar(0.50m);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ContaCaixinha_Sacar_SaldoInsuficiente_Falha()
        {
            // Arrange
            Cliente cliente = CriarCliente();
            ContaCaixinha contaCaixinha = new ContaCaixinha("13579", cliente);

            // Act
            contaCaixinha.Sacar(100);
        }
        private Cliente CriarCliente()
        {
            return new Cliente("Fulano", "12345678901", 2000);
        }
    }
}
