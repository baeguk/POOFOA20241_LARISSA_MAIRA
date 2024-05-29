using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Model
{
    public class Agencia
    {
        private int _numero;
        private string _cep;
        private string _telefone;

        public Banco Banco {  get; set; }   

        public Agencia(int numero, string cep, string telefone, Banco banco)
        {
            _numero = numero;
            _cep = cep;
            _telefone = telefone;
            Banco = banco;
        }
        public int Numero { get => _numero; }
       
        public string Telefone
        {
            get => _telefone;
            set
            {
                _telefone = value;
            }
        }

        public string Cep
        {
            get => _cep;
            set
            {
                _cep = value;
            }
        }
    }
}
