using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Clientes
    {

        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string identificacion { get; set; }
        public int edad { get; set; }
        public string genero { get; set; }
        public bool estado { get; set; }
        public string atributosAdicionales { get; set; }
        public bool maneja { get; set; }
        public bool usaLentes { get; set; }
        public bool diabetico { get; set; }
        public bool enfermedadOtra { get; set; }
        public string descripcionOtraEnfermedad { get; set; }


    }
}
