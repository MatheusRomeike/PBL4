using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL4.Domain.Pessoa
{
    public class Pessoa
    {
        #region Propriedades
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public DateTime DataNascimento { get; set; }
        #endregion

        #region Construtor
        public Pessoa() { }
        #endregion

        #region
        public int CalcularIdade()
        {
            return (int)(DateTime.Now - DataNascimento).TotalDays / 365;
        }
        #endregion
    }
}
