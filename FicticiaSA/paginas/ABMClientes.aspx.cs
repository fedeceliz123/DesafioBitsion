using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entity;
using Business;

namespace FicticiaSA.paginas
{
    public partial class ABMClientes : System.Web.UI.Page
    {

        Clientes clientes = new Clientes();
        Business.Business negocio = new Business.Business();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarTabla();
            }
        }

        private void llenarEntidadCliente()
        {
            clientes.nombre = txtNombre.Text;
            clientes.identificacion = txtIdentificacion.Text;
            clientes.edad = int.Parse(txtEdad.Text);
            clientes.genero = DroplistGenero.SelectedItem.Text;
            clientes.atributosAdicionales = txtAtributos.Text;
            clientes.maneja = chManeja.Checked ? true : false;
            clientes.usaLentes=chLentes.Checked ? true : false;
            clientes.diabetico=chDiabetes.Checked ? true : false;
            clientes.enfermedadOtra=chOtro.Checked ? true : false;
            clientes.descripcionOtraEnfermedad = txtOtra.Text;
        }
        protected void chOtro_CheckedChanged(object sender, EventArgs e)
        {
            if (chOtro.Checked)
            {
                txtOtra.Enabled = true;
            }
            else
            {
                txtOtra.Enabled = false;
                txtOtra.Text = "";

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            if (DroplistGenero.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Seleccione un genero');", true);
                return;
            }

            llenarEntidadCliente();

            string token = Session["token"].ToString();
            if (verificarToken(token) == false)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Acceso denegado');", true);
                Response.Redirect("~/paginas/Login.aspx");

            }

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('"+negocio.altaCliente(clientes) +"');", true);
            cargarTabla();
            limpiar();
         
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            if (DroplistGenero.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Seleccione un genero');", true);
                return;
            }

            llenarEntidadCliente();

            string token = Session["token"].ToString();

            if (verificarToken(token) == false)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Acceso denegado');", true);
                Response.Redirect("~/paginas/Login.aspx");

            }


            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + negocio.editarCliente(clientes) + "');", true);
            cargarTabla();
            txtIdentificacion.Enabled = true;
            btnAgregar.Enabled = true;
            btnCancelar.Visible = false;
            limpiar();
           
        }

        

       

        private void cargarTabla()
        {
            GridView1.DataSource = negocio.listarClientes();
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
                int index = Convert.ToInt32(e.CommandArgument);
                string id = (GridView1.DataKeys[index].Value).ToString();
                Session["identificador"] = id.ToString();
            if (e.CommandName == "editar")
            {
              

                txtIdentificacion.Enabled = false;
                btnModificar.Enabled = true;
                btnAgregar.Enabled = false;
                btnCancelar.Visible = true;

                clientes = negocio.listarClientesPorIdentificacion(Session["identificador"].ToString());

                llenarCampos(clientes);


            }
            else if (e.CommandName == "eliminar")
            {
                string token = Session["token"].ToString();

                if (verificarToken(token) == false)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Acceso denegado');", true);
                    Response.Redirect("~/paginas/Login.aspx");

                }


                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + negocio.eliminarCliente(Session["identificador"].ToString()) + "');", true);
                cargarTabla();
                limpiar();

                
            }
        }

        private void limpiar()
        {
            txtNombre.Text = "";
            txtIdentificacion.Text = "";
            txtEdad.Text = "";
            txtAtributos.Text = "";
            txtOtra.Text = "";
            chDiabetes.Checked = false;
            chLentes.Checked = false;
            chManeja.Checked = false;
            chOtro.Checked = false;
            txtOtra.Enabled = false;
            DroplistGenero.SelectedIndex = 0;
        }

        private void llenarCampos(Clientes cli)
        {
            txtNombre.Text =cli.nombre ;
            txtIdentificacion.Text = cli.identificacion;
            txtEdad.Text = (cli.edad).ToString();
            txtAtributos.Text = cli.atributosAdicionales;
            txtOtra.Text = cli.enfermedadOtra ? cli.descripcionOtraEnfermedad : "";
            chDiabetes.Checked = cli.diabetico;
            chLentes.Checked = cli.usaLentes;
            chManeja.Checked = cli.maneja;
            chOtro.Checked = cli.enfermedadOtra;
            txtOtra.Enabled = cli.enfermedadOtra?true:false;
            if (cli.genero == "Masculino")
            {
                DroplistGenero.SelectedIndex = 1;

            }
            else
            {
                DroplistGenero.SelectedIndex = 2;
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            btnModificar.Enabled = false;
            btnAgregar.Enabled = true;
            btnCancelar.Visible = false;
        }


        private bool verificarToken(string token )
        {
            return negocio.verificarToken(token);
        }
    }
}