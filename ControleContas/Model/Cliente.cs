using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas.Model
{
    public class Cliente
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public int AnoNascimento { get; private set; }

        public Cliente(string nome, string cpf, int anoNascimento)
        {
            if (2023 - anoNascimento < 18)
                throw new ArgumentException("O cliente deve ser maior de idade");
            if (cpf.Length != 11)
                throw new ArgumentException("O CPF deve ter 11 dígitos sem pontos e sem traço (somente números)");
            Nome = nome;
            Cpf = cpf;
            AnoNascimento = anoNascimento;
        }
    }
}
