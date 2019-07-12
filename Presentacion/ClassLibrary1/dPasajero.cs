using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;
namespace Datos
{
    public class dPasajero
    {
        Database db = new Database();
        public string Insertar(ePasajero obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string insert = string.Format("insert into pasajero(nombre,apellido,idpais) values('{0}','{1}',{2})", obj.Nombre, obj.Apellido, obj.pais.Idpais);
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                return "Inserto";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaDb();
            }
        }

        public string Modificar(ePasajero obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string update = string.Format("update pasajero set nombre='{0}',apellido='{1}',idpais={2} where idpasajero={3}", obj.Nombre, obj.Apellido, obj.pais.Idpais, obj.Idpasajero);
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                return "Modifico";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaDb();
            }
        }

        public string Eliminar(int id)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string delete = string.Format("delete from pasajero where idpasajero={0}", id);
                SqlCommand cmd = new SqlCommand(delete, con);
                cmd.ExecuteNonQuery();
                return "Elimino";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaDb();
            }
        }

        public ePasajero BuscarPorId(int id)
        {
            try
            {
                ePasajero pasajero = null;
                ePais pais = null;
                SqlConnection con = db.ConectaDb();

                string select = string.Format("select pas.idpasajero,pas.Nombre, pas.Apellido, pa.Nombre as Pais,pa.idpais  from Pais as pa,Pasajero as pas  where pa.IdPais=pas.IdPais and pas.idpasajero={0}", id);
                SqlCommand cmd = new SqlCommand(select, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    pasajero = new ePasajero();
                    pais = new ePais();
                    pasajero.Idpasajero = (int)reader["idpasajero"];
                    pasajero.Nombre = (string)reader["Nombre"];
                    pasajero.Apellido = (string)reader["Apellido"];
                    pais.Nombrepais = (string)reader["Pais"];
                    pasajero.pais = pais;
                }
                reader.Close();
                return pasajero;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.DesconectaDb();
            }
        }

        public List<ePasajero> ListarTodo()
        {
            try
            {
                //TODO
                List<ePasajero> lsPasajero = new List<ePasajero>();
                ePasajero pasajero = null;
                ePais pais = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("select pas.idpasajero,pas.Nombre, pas.Apellido, pa.Nombre as Pais,pa.idpais  from Pais as pa,Pasajero as pas  where pa.IdPais=pas.IdPais", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pasajero = new ePasajero();
                    pais = new ePais();
                    pasajero.Idpasajero = (int)reader["idpasajero"];
                    pasajero.Nombre = (string)reader["Nombre"];
                    pasajero.Apellido = (string)reader["Apellido"];
                    pais.Nombrepais = (string)reader["Pais"];
                    pasajero.pais = pais;
                    lsPasajero.Add(pasajero);
                }
                reader.Close();
                return lsPasajero;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.DesconectaDb();
            }
        }

        public List<ePasajero> ListarpasajerosPais(string nombrepais)
        {
            //Implementarlo
            return null;
        }
    }
}
