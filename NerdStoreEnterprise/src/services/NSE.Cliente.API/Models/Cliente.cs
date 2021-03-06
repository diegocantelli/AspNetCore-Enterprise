using NSE.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Cliente.API.Models
{
    public class ClienteEntity : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }
        public bool Excluido { get; private set; }
        public Endereco Endereco { get; private set; }

        //necessário para o EF
        protected ClienteEntity(){ }
        public ClienteEntity(Guid id, string nome, string email, string cpf)
        {
            Id = id;
            Nome = nome;
            Email = new Email(email);
            Cpf = new Cpf(cpf);
        }

        public void TrocarEmail(string novoEmail)
        {
            Email = new Email(novoEmail);
        }

        public void TrocarEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }
    }
}
