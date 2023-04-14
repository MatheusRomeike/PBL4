using PBL4.Domain.Administrador.Enums;
using PBL4.Domain.Funcionario.Enums;
using PBL4.Domain.Pessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL4.Domain.Administrador
{
    public class Administrador : Pessoa.Pessoa
    {
        #region Propriedades
        public Setor Setor { get; set; }
        public NivelGestor Nivel { get; set; }
        public DateTime DataAdmissao { get; set; }
        #endregion

        #region Construtor
        public Administrador(Pessoa.Pessoa pessoa)
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
