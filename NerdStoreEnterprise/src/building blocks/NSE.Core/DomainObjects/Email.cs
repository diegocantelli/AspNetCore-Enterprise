using System;
using System.Collections.Generic;
using System.Text;

namespace NSE.Core.DomainObjects
{
    public class Email
    {
        public const int EnderecoMaxLength = 254;
        public const int EnderecoMinLength = 5;

        public string Endereco { get; private set; }

        // Construtor para uso do EF
        protected Email() { }

        public Email(string endereco)
        {
            if (!Validar(endereco)) throw new DomainException("Email inválido.");
            Endereco = endereco;
        }

        public static bool Validar(string endereco) => true;
    }
}
