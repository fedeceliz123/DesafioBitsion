using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class ConexionDB
    {
        private SqlConnection Conexion = new SqlConnection();

        private string Cadena = @"Data Source=159.65.222.2; User ID=SA;Password=DevCervantes2022;Initial Catalog=FicticiaSA";

        public SqlConnection Conetar()
        {

            try
            {

                Conexion = new SqlConnection(Cadena);

                if (Conexion.State.Equals(ConnectionState.Open))
                {
                    Conexion.Close();
                }
                else
                {
                    Conexion.Open();
                }


            }
            catch
            {



                Conexion.FireInfoMessageEventOnUserErrors.ToString();


            }

            return Conexion;

        }

    }
}
