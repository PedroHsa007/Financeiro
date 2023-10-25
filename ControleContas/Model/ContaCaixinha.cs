using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas.Model
{
   public  class ContaCaixinha: Conta
    {
        public ContaCaixinha(string numero, Cliente titular) : base(numero, titular)
        {

        }
        public decimal inserir = 1;
        public decimal Descontar = 0.5m;

        public ContaCaixinha(string numero, decimal saldo, Cliente titular) : base(numero, saldo, titular)
        {

        }
        public override bool Depositar(decimal valor)
        {
            if (valor < 1)
            {

                throw new ArgumentException("Valor do deposito deve ser maior que 1 real");


            }
            _saldo += valor + Inserir;

            return false;
        }



        public override bool Sacar(decimal valor)
        {
            if (valor > _saldo)
            {
                throw new InvalidOperationException("Valor do Saque´ultrapassou o valor perimitido");

            }
            _saldo = valor - Descontar;
            return true;
        }
    }
}
