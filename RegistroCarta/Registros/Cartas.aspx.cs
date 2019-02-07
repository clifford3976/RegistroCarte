using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroCarta.Registros
{
    public partial class Cartas : System.Web.UI.Page
    {
        string condicion = "Select One";
        RepositorioBase<Carta> repositorio = new RepositorioBase<Carta>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                LlenaComboDestinarioID();
                FechadateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                CartaIDTextbox.Text = "0";
            }
        }

        public Carta LlenaClase()
        {
            Carta carta = new Carta();
            int id;
            bool result = int.TryParse(CartaIDTextbox.Text, out id);
            if (result == true)
            {
                carta.CartaID = id;
            }
            else
            {
                carta.CartaID = 0;
            }

            carta.DestinarioID = Convert.ToInt32(DropDownList.SelectedValue);

            carta.Cuerpo = CuerpoTxtbox.Text;
            carta.Fecha = Convert.ToDateTime(FechadateTime.Text);
            carta.Cantidad = Convert.ToInt32(CantidadTextbox.Text.ToString());

            return carta;
        }

        private void LlenaCampos(Carta carta)
        {
            CartaIDTextbox.Text = carta.CartaID.ToString();
            LlenaComboDestinarioID();
            CuerpoTxtbox.Text = carta.Cuerpo;
            CantidadTextbox.Text = carta.Cantidad.ToString();

        }
        private void Limpiar()
        {
            CartaIDTextbox.Text = "";
            LlenaComboDestinarioID();
            CuerpoTxtbox.Text = "";
            CantidadTextbox.Text = "";
            FechadateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");

        }

        void MostrarMensaje(TiposMensajes tipo, string mensaje)

        {

            ErrorLabel.Text = mensaje;

            if (tipo == TiposMensajes.Success)

                ErrorLabel.CssClass = "alert-success";

            else

                ErrorLabel.CssClass = "alert-danger";

        }

        private void LlenaComboDestinarioID()
        {
            RepositorioBase<Destinario> destinario = new RepositorioBase<Destinario>();
            DropDownList.Items.Clear();
            DropDownList.Items.Add(condicion);
            DropDownList.DataSource = destinario.GetList(x => true);
            DropDownList.DataValueField = "DestinarioID";
            DropDownList.DataTextField = "Nombres";
            DropDownList.DataBind();
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (DropDownList.SelectedValue == condicion)
                return;


            CartaBLL repositorio = new CartaBLL();
            Carta carta = LlenaClase();
            RepositorioBase<Destinario> destinario = new RepositorioBase<Destinario>();

            var validar = destinario.Buscar(Utilities.Utils.ToInt(DropDownList.SelectedValue));

            bool paso = false;


            if (validar != null)
            {

                if (Page.IsValid)
                {
                    if (CartaIDTextbox.Text == "0")
                    {
                        paso = repositorio.Guardar(carta);

                    }

                    else
                    {
                        var verificar = repositorio.Buscar(Utilities.Utils.ToInt(CartaIDTextbox.Text));
                        if (verificar != null)
                        {
                            paso = repositorio.Modificar(carta);
                        }
                        else
                        {
                            Utilities.Utils.ShowToastr(this, "No se encuentra el ID", "Fallo", "success");
                            return;
                        }
                    }

                    if (paso)

                    {
                        Utilities.Utils.ShowToastr(this, "Registro Con Exito", "Exito", "success");

                    }

                    else

                    {
                        Utilities.Utils.ShowToastr(this, "No se pudo Guardar", "Fallo", "success");
                    }
                    Limpiar();
                    return;
                }


            }
            else
            {
                Utilities.Utils.ShowToastr(this, "El numero dela carta no existe", "Fallo", "success");
                return;


            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            CartaBLL repositorio = new CartaBLL();
            RepositorioBase<Carta> dep = new RepositorioBase<Carta>();


            int id = Utilities.Utils.ToInt(CartaIDTextbox.Text);
            var carta = repositorio.Buscar(id);


            if (carta == null)
            {
                Utilities.Utils.ShowToastr(this, "la carta no existe", "Fallo", "success");
            }

            else
            {
                repositorio.Eliminar(id);



                Utilities.Utils.ShowToastr(this, "Elimino Correctamente", "Exito", "success");
                Limpiar();
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Carta> repositorio = new RepositorioBase<Carta>();


            Carta carta = repositorio.Buscar(Utilities.Utils.ToInt(CartaIDTextbox.Text));

            Limpiar();
            if (carta != null)
            {
                LlenaCampos(carta);

                Utilities.Utils.ShowToastr(this, "Se ha Encontrado su carta", "Exito", "success");
            }
            else
            {
                Utilities.Utils.ShowToastr(this, "el ID registrado no existe", "Fallido", "success");
            }
        }
    }
}