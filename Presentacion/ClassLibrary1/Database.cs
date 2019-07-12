using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
namespace Datos
{
    public class Database
    {
        private SqlConnection conn;
        public SqlConnection ConectaDb()
        {
            try
            {
                string cadenaconexion = "Data Source=JAGUAR009\\MYSQL;Initial Catalog=dbsesion10;Integrated Security=True";
                conn = new SqlConnection(cadenaconexion);
                conn.Open();
                return conn;
            }
            catch(SqlException e)
            {
                return null;
            }
        }
        public void DesconectaDb()
        {
            conn.Close();
        }
    }
}
