using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
namespace Negocio
{
    public class nPasajero
    {
        dPasajero pasajerodatos;

        public nPasajero()
        {
            pasajerodatos = new dPasajero();
        }

        public string Registrarpasajero(string nombrepasajero, string apellido, int idpais)
        {
            ePais pais = new ePais()
            {
                Idpais = idpais
            };

            ePasajero pasajero = new ePasajero()
            {
                Nombre = nombrepasajero,
                Apellido = apellido,
                pais = pais
            };

            return pasajerodatos.Insertar(pasajero);
        }

        public string Modificarpasajero(int idpasajero, string nombrepasajero, string apellido, int idpais)
        {
            ePais pais = new ePais()
            {
                Idpais = idpais
            };

            ePasajero pasajero = new ePasajero()
            {
                Idpasajero = idpasajero,
                Nombre = nombrepasajero,
                Apellido = apellido,
                pais = pais
            };
            return pasajerodatos.Modificar(pasajero);
        }

        public string Eliminarpasajero(int id)
        {
            return pasajerodatos.Eliminar(id);
        }

        public List<ePasajero> Listarpasajero()
        {
            return pasajerodatos.ListarTodo();
        }
    }
}
