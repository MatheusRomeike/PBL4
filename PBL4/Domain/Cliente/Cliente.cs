using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL4.Domain.Cliente
{
    public class Cliente : Pessoa.Pessoa
    {
        #region Propriedades
        public string Apelido { get; set; }
        public decimal RendaMensal { get; set; }
        public bool Novo { get; set; }
        #endregion

        #region Construtor
        public Cliente(Pessoa.Pessoa pessoa)
        {
            Nome = pessoa.Nome;
            Cpf = pessoa.Cpf;
            DataNascimento = pessoa.DataNascimento;
            Email = pessoa.Email;
            Celular = pessoa.Celular;
            DataNascimento = pessoa.DataNascimento;
        }
        #endregion
    }
}
