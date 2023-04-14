using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL4.Domain.Funcionario.Enums
{
    public enum Setor
    {
        [Description("Adminstrativo")]
        Administrativo = 1,
        [Description("Financeiro")]
        Financeiro = 2
    }
}
