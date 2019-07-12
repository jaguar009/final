using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ePais
    {
        public int Idpais { get; set; }
        public string Nombrepais { get; set; }
        public override string ToString()
        {
            return Nombrepais;
        }
    }
}
