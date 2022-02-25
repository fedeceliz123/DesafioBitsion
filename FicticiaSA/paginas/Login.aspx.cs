using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace FicticiaSA.paginas
{
    public partial class Login : System.Web.UI.Page
    {
        Business.Business negocio = new Business.Business();
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Usuario: ficticia . Contraseña: 123456');", true);

                txtUsuario.Text = "ficticia";
                txtContraseña.Text = "123456";
            }
            
        }

        

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (negocio.iniciarSesion(txtUsuario.Text, txtContraseña.Text) != "")
            {
                Session["token"] = negocio.iniciarSesion(txtUsuario.Text, txtContraseña.Text);
            Response.Redirect("~/paginas/ABMClientes.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Usuario o contraseña incorrecta');", true);
            }

        }
    }
}