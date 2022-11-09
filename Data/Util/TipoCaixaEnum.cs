using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Business.Util
{
    public enum TipoCaixaEnum
    {
        [Description("Despesa")]
        Despesa = 1,

        [Description("Receita")]
        Receita = 2,
    }
}
