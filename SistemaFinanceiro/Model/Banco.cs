using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Model
{
    public class Banco
    {
        private string _nome;
        private int _numero;

        public Banco(int numero, string nome)
        {
            _numero = numero;
            _nome = nome;
        }
        public int Numero { get => _numero; }
        public string Nome
        {
            get => _nome;
            set => _nome = value;
        }

    }
}
