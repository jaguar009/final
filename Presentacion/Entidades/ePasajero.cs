using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ePasajero
    {
        public int Idpasajero { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public ePais pais { get; set; }
        public override string ToString()
        {
            return Nombre + " " + Apellido;
        }
    }
}
