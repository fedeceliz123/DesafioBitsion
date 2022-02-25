using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Data
{
    public class Data:ConexionDB
    {
      

        // Alta de clientes

        public int altaCliente(Clientes cliente)
        {

         

            try
            {

            SqlCommand command = new SqlCommand("addCliente", Conetar());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@nombre", cliente.nombre);
            command.Parameters.AddWithValue("@identificacion", cliente.identificacion);
            command.Parameters.AddWithValue("@edad", cliente.edad);
            command.Parameters.AddWithValue("@genero", cliente.genero);            
            command.Parameters.AddWithValue("@atributosAdicionales", cliente.atributosAdicionales);
            command.Parameters.AddWithValue("@maneja", cliente.maneja);
            command.Parameters.AddWithValue("@usaLentes", cliente.usaLentes);
            command.Parameters.AddWithValue("@diabetico", cliente.diabetico);
            command.Parameters.AddWithValue("@enfermedadOtra", cliente.enfermedadOtra);
            command.Parameters.AddWithValue("@descripcionOtraEnfermedad", cliente.descripcionOtraEnfermedad);
            command.ExecuteNonQuery();

                return 1;

            }
            catch (Exception e)

            {
                return 0;
            }
            

        }

        // editar empleado
        public int editarCliente(Clientes cliente)
        {

            
            try
            {

                SqlCommand command = new SqlCommand("editarCliente", Conetar());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nombre", cliente.nombre);
                command.Parameters.AddWithValue("@identificacion", cliente.identificacion);
                command.Parameters.AddWithValue("@edad", cliente.edad);
                command.Parameters.AddWithValue("@genero", cliente.genero);
                
                command.Parameters.AddWithValue("@atributosAdicionales", cliente.atributosAdicionales);
                command.Parameters.AddWithValue("@maneja", cliente.maneja);
                command.Parameters.AddWithValue("@usaLentes", cliente.usaLentes);
                command.Parameters.AddWithValue("@diabetico", cliente.diabetico);
                command.Parameters.AddWithValue("@enfermedadOtra", cliente.enfermedadOtra);
                command.Parameters.AddWithValue("@descripcionOtraEnfermedad", cliente.descripcionOtraEnfermedad);
                command.ExecuteNonQuery();

                return 1;

            }
            catch
            {
                return 0;
            }


        }

        // eliminar cliente 

        public int eliminarCliente(string  identificacion)
        {
          
            try
            {

                SqlCommand command = new SqlCommand("eliminarCliente", Conetar());
                command.CommandType = CommandType.StoredProcedure;
                
                command.Parameters.AddWithValue("@identificacion", identificacion);
               
                command.ExecuteNonQuery();

                return 1;

            }
            catch
            {
                return 0;
            }


        }

        // listar clientes

        public DataTable listaClientes()
        {
            DataTable clientes = new DataTable();
            try
            {



            SqlDataAdapter da = new SqlDataAdapter("ListarClientes", Conetar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            

            DataSet ds = new DataSet();
            da.Fill(ds);
            clientes = ds.Tables[0];

            }
            catch (Exception e)
            {

                clientes = null;
            }



            return clientes;
        }

        // datos de cliente por identificacion 

        public DataTable clientePorIdentificacion(string identificacion)
        {

            DataTable clientes = new DataTable();
            try
            {



                SqlDataAdapter da = new SqlDataAdapter("FiltrarClientesPorIdentificacion", Conetar());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@identificacion", identificacion);

                DataSet ds = new DataSet();
                da.Fill(ds);
                clientes = ds.Tables[0];

            }
            catch
            {
                clientes = null;
            }



            return clientes;


        }

        // inicio de sesion 

        public DataTable inicioSesion(string user,string pass,string token)
        {

            DataTable clientes = new DataTable();
            try
            {



                SqlDataAdapter da = new SqlDataAdapter("access", Conetar());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@user", user);
                da.SelectCommand.Parameters.AddWithValue("@pass", pass);
                DataSet ds = new DataSet();
                da.Fill(ds);
                clientes = ds.Tables[0];

                if (clientes.Rows.Count > 0)
                {
                    SqlCommand command = new SqlCommand("actualizartoken", Conetar());
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.Parameters.AddWithValue("@token", token);
                    command.ExecuteNonQuery();
                }


            }
            catch (Exception e)
            {
                clientes = null;
            }



            return clientes;


        }

        public bool VerificarToken(string token)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("verifyToken", Conetar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@token", token);
           
            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
