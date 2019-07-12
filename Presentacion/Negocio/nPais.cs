using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Datos;

namespace Negocio
{
    public class nPais
    {
        dPais paisdatos;
        public nPais()
        {
            paisdatos = new dPais();
        }
        public string RegistrarPais(string nombrepais)
        {
            ePais pais = new ePais()
            {
                Nombrepais = nombrepais
            };
            return paisdatos.Insertar(pais);
        }
        public string Modificarpais(int idpais, string nombrepais)
        {
            ePais pais = new ePais()
            {
                Idpais = idpais,
                Nombrepais = nombrepais
            };
            return paisdatos.Modificar(pais);
        }

        public string Eliminarpais(int id)
        {
            return paisdatos.Eliminar(id);
        }

        public List<ePais> Listarpais()
        {
            return paisdatos.ListarTodo();
        }
    }
}
