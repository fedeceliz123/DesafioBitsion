<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMClientes.aspx.cs" Inherits="FicticiaSA.paginas.ABMClientes" %>

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
        <div class="container">
            

              <div style="display:flex;height:100vh;flex-direction:column">
                    
                 

                  <div class="row pt-5" style="width:100%">
                      <div class="col-4">
                           <asp:Label runat="server" Text="Nombre" ></asp:Label>
                          <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"  />
                      </div>
                       <div class="col-4">
                           <asp:Label runat="server" Text="Identificacion" ></asp:Label>
                          <asp:TextBox runat="server" ID="txtIdentificacion" CssClass="form-control" />
                      </div>
                  </div>


                    <div class="row pt-1" style="width:100%">
                      <div class="col-4">
                           <asp:Label runat="server" Text="Edad"  ></asp:Label>
                          <asp:TextBox runat="server" ID="txtEdad" TextMode="Number" CssClass="form-control"  />
                      </div>
                       <div class="col-4">
                           <asp:Label runat="server" Text="Genero" ></asp:Label>
                           <asp:DropDownList runat="server" ID="DroplistGenero" CssClass=" form-select">
                               <asp:ListItem>
                                              ---Seleccione---
                                   
                               </asp:ListItem>
                               <asp:ListItem>Masculino</asp:ListItem>
                               <asp:ListItem>Femenino</asp:ListItem>
                           </asp:DropDownList>
                      </div>
                  </div>


                  <div class="row pt-1" style="width:100%">
                      <div class="col-4">
                           <asp:Label runat="server" Text="Atributos adicionales" ></asp:Label>
                          <asp:TextBox runat="server" ID="txtAtributos" CssClass="form-control"  />
                      </div>
                       <div class="col-5">
                          <div class="row">
                              <div class="col-4 pt-4">
                                  <asp:CheckBox runat="server" ID="chManeja" Text="Maneja" />
                              </div>
                              <div class="col-4 pt-4">
                                  <asp:CheckBox runat="server" ID="chLentes" Text="Usa lentes" />
                              </div>
                              <div class="col-4 pt-4">
                                  <asp:CheckBox runat="server" ID="chDiabetes" Text="Diabetes" />
                              </div>
                              <div class="col-4 pt-4">
                              </div>
                          </div>
                      </div>
                  </div>

                   <div class="row pt-1" style="width:100%">

                        <div class="col-4" >
                           <asp:Label runat="server" Text="Otra enfermedad" ></asp:Label>
                          <asp:TextBox runat="server" ID="txtOtra" CssClass="form-control"  Enabled="false" />
                      </div>
                       <div class="col-4 pt-4">
                              <asp:CheckBox runat="server" ID="chOtro" Text="Otras enfermedades" AutoPostBack="true" OnCheckedChanged="chOtro_CheckedChanged" />

                       
                       </div>
                    </div>
                  <div class="row pt-3" style="width:100%">
                    
                      <div class="col-1">
                          <asp:Button Text="Agregar" runat="server" ID="btnAgregar" CssClass="btn btn-primary"  OnClick="btnAgregar_Click" />
                      </div>
                      <div class="col-1">
                          <asp:Button Text="Modificar" runat="server" ID="btnModificar" CssClass="btn btn-success"  Enabled="false" OnClick="btnModificar_Click" />
                      </div>
                      <div class="col-1">
                          <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" CssClass="btn btn-secondary"  Visible="false"  OnClick="btnCancelar_Click" />
                      </div>
                      
                  </div>

                   


        <div style="margin-left:50px;margin-top:50px;">

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
             DataKeyNames="identificacion"
             CssClass=" table"
             Width="80%"
             OnRowCommand="GridView1_RowCommand"
            >
            <Columns>
                <asp:BoundField DataField="nombre"   HeaderText="Nombre Completo"/>
                <asp:BoundField DataField="identificacion" HeaderText="Identificacion" />
                <asp:BoundField DataField="edad" HeaderText="Edad" />
                <asp:BoundField DataField="genero" HeaderText="Genero" />
                
                <asp:ButtonField Text="Editar" CommandName="editar" ControlStyle-CssClass="btn btn-primary" HeaderText="Editar" />
                <asp:ButtonField Text="Eliminar" CommandName="eliminar" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" />
                
            </Columns>


        </asp:GridView>
        </div>
                </div>

        </div>
    </form>
</body>
</html>
