using PBL4.Domain.Funcionario.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL4.Domain.Funcionario
{
    public class Funcionario : Pessoa.Pessoa
    {
        #region Propriedades
        public Setor Setor { get; set; }
        public DateTime DataAdmissao { get; set; }
        public bool PrimeiroEmprego { get; set; }
        #endregion

        #region Construtor
        public Funcionario(Pessoa.Pessoa pessoa)
        {
            Nome = pessoa.Nome;
            Cpf = pessoa.Cpf;
            DataNascimento = pessoa.DataNascimento;
            Email = pessoa.Email;
            Celular = pessoa.Celular;
            DataNascimento = pessoa.DataNascimento;
        }
        #endregion

        #region Métodos
        public int CalcularAnosNaEmpresa()
        {
            return (int)(DateTime.Now - DataAdmissao).TotalDays / 365;
        }
        #endregion
    }
}
