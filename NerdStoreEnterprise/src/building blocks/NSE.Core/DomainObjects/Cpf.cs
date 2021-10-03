using System;
using System.Collections.Generic;
using System.Text;

namespace NSE.Core.DomainObjects
{
    public class Cpf
    {
        public const int CpfMaxLength = 11;

        public string Numero { get; private set; }

        // Construtor do EF
        protected Cpf() { }

        public Cpf(string numero)
        {
            if (!Validar(Numero)) throw new DomainException("Cpf inválido.");
            Numero = numero;
        }

        public static bool Validar(string numeroCpf) => true;
    }
}
