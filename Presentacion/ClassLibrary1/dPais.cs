using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class dPais
    {
        Database db = new Database();
        public string Insertar(ePais obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string insert = string.Format("INSERT INTO Pais (nombre) VALUES ('{0}')",obj.Nombrepais);
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                return "Inserto";
            }
            catch(Exception e)
            {
                return e.Message;
            }
            finally
            {
                db.DesconectaDb();
            }
        }
        public string Modificar(ePais obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string update = string.Format("UPDATE pais SET Nombre='{0}' Where idpais={1}", obj.Nombrepais, obj.Idpais);
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
                string delete = string.Format("DELETE from pais WHERE idpais={0}", id);
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
        public ePais BuscarPorId(int id)
        {
            try
            {
                ePais pais = null;
                SqlConnection con = db.ConectaDb();
                string select = string.Format("select idpais,nombre from Pais where idpais={0}",id);
                SqlCommand cmd = new SqlCommand(select, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    pais = new ePais();
                    pais.Idpais =(int)reader["idpais"];
                    pais.Nombrepais =(string)reader["nombre"];
                }
                reader.Close();
                return pais;
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
        public List<ePais> ListarTodo()
        {
            try
            {
                List<ePais> lsPais = new List<ePais>();
                ePais pais = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("select idpais,nombre from pais",con);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    pais = new ePais();
                    pais.Idpais = (int)reader["idpais"];
                    pais.Nombrepais = (string)reader["nombre"];
                    lsPais.Add(pais);
                }
                reader.Close();
                return lsPais;
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
    }
}
