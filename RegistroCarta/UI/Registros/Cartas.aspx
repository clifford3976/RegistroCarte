<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" 
    CodeBehind="Cartas.aspx.cs" Inherits="RegistroCarta.UI.Registros.Cartas" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

   

        <div class="container">
            <div class="form-group">
                <div style="text-align: center;">

                    <asp:Label ID="LabelCuentas" runat="server" Text="Registro de Carta" Font-Size="XX-Large" ForeColor="#0099FF"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="columns" style="width: 350px;">
                    <div class="form-group ">
                        <div class="row" style="align-items: center;">
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorId" ControlToValidate="CartaidTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionBE"></asp:RequiredFieldValidator>

                            <div style="width: 95px;">
                                <asp:Label for="CartaidTextBox" ID="Label6" runat="server" Text="CartaID:"></asp:Label>

                            </div>
                           
                            <asp:TextBox ID="CartaidTextBox" runat="server" class="form-control" TextMode="Number" placeholder="Carta Id" Width="250px"></asp:TextBox>
                     
                            </div>
                    </div>

                    <div class="form-group">
                        <div class="row" style="align-items: center;">
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorNombre" ControlToValidate="FechaTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar">*</asp:RequiredFieldValidator>

                            <div style="width: 95px;">
                                <asp:Label for="FechaTextBox" ID="Fechalabel" runat="server" Text="Fecha:"></asp:Label>
                            </div>

                            <asp:TextBox ID="FechaTextBox" runat="server" class="form-control" TextMode="Date" Width="250px"></asp:TextBox>
                        </div>

                    </div>

                    <div class="form-group">
                        <div class="row" style="align-items: center;">
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorBalance" ControlToValidate="DestinatarioTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar">*</asp:RequiredFieldValidator>

                            <div style="width: 110px;">

                                <asp:Label for="DestinatarioTextBox" ID="destinatarioLabel" runat="server" Text="DestinatarioID:"></asp:Label>
                            </div>

                            <asp:TextBox ID="DestinatarioTextBox" runat="server" class="form-control" placeholder="DestinatarioID" Width="250px" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>

                    
                    <div class="form-group">
                        <div class="row" style="align-items: center;">
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidator1" ControlToValidate="CuerpoTextbox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar">*</asp:RequiredFieldValidator>

                            <div style="width: 95px;">

                                <asp:Label for="CuerpoTextbox" ID="Label2" runat="server" Text="Cuerpo:"></asp:Label>
                            </div>

                            <asp:TextBox ID="CuerpoTextbox" runat="server" class="form-control" placeholder="Cuerpo" Width="250px" TextMode="MultiLine"></asp:TextBox>
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

                <asp:Button ID="NuevoButton" class="btn btn-info" runat="server" Text="Nuevo" OnClick="NuevoButton_Click"   />

                <asp:Button ValidationGroup="ValidacionGuardar" ID="GuardarButton" class="btn btn-success" runat="server" Text="Guardar" OnClick="GuardarButton_Click"  />

                <asp:Button ValidationGroup="ValidacionBE" ID="ElminarButton" class="btn btn-danger" runat="server" Text="Eliminar" OnClick="ElminarButton_Click"/>


            </div>
        </div>

 

</asp:Content>
