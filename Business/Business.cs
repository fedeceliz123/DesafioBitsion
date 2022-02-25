using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity;
using Data;

namespace Business
{
   public class Business
    {

        Data.Data data = new Data.Data();


        public string iniciarSesion(string user, string pass)
        {
            string token = Guid.NewGuid().ToString();

            DataTable dt = data.inicioSesion(user,pass,token);

            if (dt.Rows.Count > 0 )
            {
                return token;
            }
            else
            {
                 return "";

            }
           
        }

        public string altaCliente(Clientes cliente)
        {
            if (data.clientePorIdentificacion(cliente.identificacion).Rows.Count > 0)
            {
                return "Ya existe un cliente con ese numero de identificacion";
            }

            if (string.IsNullOrEmpty(cliente.nombre))
            {
                return "Falta ingresar nombre del cliente";
            }
            else if (string.IsNullOrEmpty(cliente.identificacion))
            {
                return "Falta ingresar identificacion del cliente";
            }
            else if (string.IsNullOrEmpty(cliente.identificacion))
            {
                return "Falta ingresar identificacion del cliente";
            }
            if (cliente.enfermedadOtra == true)
            {
                if (string.IsNullOrEmpty(cliente.descripcionOtraEnfermedad))
                {
                    return "Falta ingresar enfermedad del cliente";
                }
                
            }


           

             if (data.altaCliente(cliente) == 1)
            {
                return "Cliente registrado correctamente";
            }
            else
            {
                return "Error al registrar cliente";
            }



        }

        public string editarCliente(Clientes cliente )
        {
          


            if (string.IsNullOrEmpty(cliente.nombre))
            {
                return "Falta ingresar nombre del cliente";
            }
            else if (string.IsNullOrEmpty(cliente.identificacion))
            {
                return "Falta ingresar identificacion del cliente";
            }
            else if (string.IsNullOrEmpty(cliente.identificacion))
            {
                return "Falta ingresar identificacion del cliente";
            }
           
            if (cliente.enfermedadOtra == true)
            {
                if (string.IsNullOrEmpty(cliente.descripcionOtraEnfermedad))
                {
                    return "Falta ingresar enfermedad del cliente";
                }
            }

          



             if(data.editarCliente(cliente) == 1)
            {
                return "Cliente editado correctamente";
            }
            else
            {
                return "Error al editar cliente";
            }


        }




            public string eliminarCliente(string identificacion)
            {



          

            if(data.eliminarCliente(identificacion) == 1)
                {
                    return "Cliente eliminado correctamente";
                }
                else
                {
                    return "Error al registrar cliente";
                }





            }

        public DataTable listarClientes()
        {
           return data.listaClientes();
        }

        public Clientes listarClientesPorIdentificacion(string identificacion)
        {
            Clientes cliente = new Clientes();
            
            DataTable dt= data.clientePorIdentificacion(identificacion);

            if (dt.Rows.Count == 1)
            {

            foreach(DataRow r in dt.Rows)
            {
                    cliente.nombre = r[1].ToString();
                    cliente.identificacion = r[2].ToString();
                    cliente.edad = int.Parse(r[3].ToString());
                    cliente.genero = r[4].ToString() == null ? "" : r[4].ToString();
                    cliente.estado = bool.Parse(r[5].ToString());
                    cliente.atributosAdicionales = r[6].ToString()==null?"": r[6].ToString();
                    cliente.maneja = bool.Parse(r[7].ToString());
                    cliente.usaLentes = bool.Parse(r[8].ToString());
                    cliente.diabetico = bool.Parse(r[9].ToString());
                    cliente.enfermedadOtra = bool.Parse(r[10].ToString());
                    cliente.descripcionOtraEnfermedad = r[11].ToString()==null?"" : r[11].ToString();
                }
            }
            else
            {
                cliente = null;
            }



            return cliente;


        }


        public bool verificarToken(string token)
        {
            return data.VerificarToken(token);
        }


        }
}
