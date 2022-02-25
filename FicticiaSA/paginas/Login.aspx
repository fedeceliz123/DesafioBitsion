<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FicticiaSA.paginas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="../Scripts/bootstrap.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" >
            <div style="display:flex;justify-content:center;height:100vh;align-items:center;">

            <div style="height:400px;width:400px;background-color:darkgrey;border-radius:20px;">
                <div class="row align-content-center" style="text-align:center">

                    <asp:Label runat="server" Text="Login Ficticia S.A." CssClass="m-2"></asp:Label>

                </div>
                  <div class="row m-4">

                      <div class="col-12" style="text-align:center">
                          <asp:Label runat="server" Text="Usuario" ></asp:Label>
                   <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" Width="100%" />

                      </div>
                </div>
                <div class="row m-4">

                      <div class="col-12" style="text-align:center">
                          <asp:Label runat="server" Text="Contraseña" ></asp:Label>
                   <asp:TextBox runat="server" ID="txtContraseña" CssClass="form-control" TextMode="Password" Width="100%" />

                      </div>
                </div>
               <div class="row m-5">
               <asp:Button runat="server" Text="Ingresar"  CssClass="btn-primary" style="border-radius:10px" ID="btnIngresar"  OnClick="btnIngresar_Click" /> 
               
               </div>

            </div>
            </div>

        </div>
    </form>
</body>
</html>
