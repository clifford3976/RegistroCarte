<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" 
    CodeBehind="Destinatarios.aspx.cs" Inherits="RegistroCarta.UI.Registros.Destinatarios" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

   

        <div class="container">
            <div class="form-group">
                <div style="text-align: center;">

                    <asp:Label ID="LabelCuentas" runat="server" Text="Registro de Destinatario" Font-Size="XX-Large" ForeColor="#0099FF"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="columns" style="width: 350px;">
                    <div class="form-group ">
                        <div class="row" style="align-items: center;">
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorId" ControlToValidate="DestinatarioidTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionBE"></asp:RequiredFieldValidator>

                            <div style="width: 85px;">
                                <asp:Label for="DestinatarioidTextBox" ID="Label6" runat="server" Text="DestinatarioID:"></asp:Label>

                            </div>

                            <asp:TextBox ID="DestinatarioidTextBox" runat="server" class="form-control" TextMode="Number" placeholder="DestinatarioID" Width="250px"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row" style="align-items: center;">
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorNombre" ControlToValidate="NombreTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar">*</asp:RequiredFieldValidator>

                            <div style="width: 85px;">
                                <asp:Label for="NombreTextBox" ID="Label1" runat="server" Text="Nombre:"></asp:Label>
                            </div>

                            <asp:TextBox ID="NombreTextBox" runat="server" class="form-control" placeholder="Nombre" Width="250px"></asp:TextBox>
                        </div>

                    </div>

                    <div class="form-group">
                        <div class="row" style="align-items: center;">
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorBalance" ControlToValidate="DireccionTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar">*</asp:RequiredFieldValidator>

                            <div style="width: 85px;">

                                <asp:Label for="DireccionTextBox" ID="Label5" runat="server" Text="Direccion:"></asp:Label>
                            </div>

                            <asp:TextBox ID="DireccionTextBox" runat="server" class="form-control" placeholder="Direccion" Width="250px" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>

                    
                    <div class="form-group">
                        <div class="row" style="align-items: center;">
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidator1" ControlToValidate="DireccionTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar">*</asp:RequiredFieldValidator>

                            <div style="width: 85px;">

                                <asp:Label for="CartasRecibidasTextbox" ID="Label2" runat="server" Text="CartasRecib:"></asp:Label>
                            </div>

                            <asp:TextBox ID="CartasRecibidasTextbox" runat="server" class="form-control" placeholder="CartasRecib" Width="250px" ReadOnly="True">0</asp:TextBox>
                        </div>
                    </div>

                </div>

                <div class="columns" style="width: 400px;">
                    <div class="form-group">
                        <div class="row" style="align-items: center;">
                            <asp:Button ValidationGroup="ValidacionBE" ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" OnClick="BuscarButton_Click" />
                        </div>
                    </div>
                </div>

               

            </div>
        </div>

        <div class="row" style="justify-content: center;">
            <div class="form-group">

                <asp:Button ID="NuevoButton" class="btn btn-info" runat="server" Text="Nuevo" OnClick="NuevoButton_Click"  />

                <asp:Button ValidationGroup="ValidacionGuardar" ID="GuardarButton" class="btn btn-success" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />

                <asp:Button ValidationGroup="ValidacionBE" ID="ElminarButton" class="btn btn-danger" runat="server" Text="Eliminar" OnClick="ElminarButton_Click"/>


            </div>
        </div>


</asp:Content>
