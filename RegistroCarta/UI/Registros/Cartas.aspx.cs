using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroCarta.UI.Registros
{
    public partial class Cartas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CartaidTextBox.Text = "0";
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        public Carta Llenaclase()
        {
            Carta cuentas = new Carta();

            cuentas.CartaID = Utilities.Utils.ToInt(CartaidTextBox.Text);
            cuentas.Fecha = Convert.ToDateTime(FechaTextBox.Text);
            cuentas.DestinarioID = Utilities.Utils.ToInt(DestinatarioTextBox.Text);
            cuentas.Cuerpo = CuerpoTextbox.Text;
            return cuentas;
        }
        public void Limpiar()
        {
            CartaidTextBox.Text = "0";
            DestinatarioTextBox.Text = string.Empty;
            CuerpoTextbox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void LlenaCampos(Carta cartas)

        {

            CartaidTextBox.Text = cartas.CartaID.ToString();
            FechaTextBox.Text = cartas.Fecha.ToString("yyyy-MM-dd");
            DestinatarioTextBox.Text = cartas.DestinarioID.ToString();
            CuerpoTextbox.Text = cartas.Cuerpo;

        }

        public void LimpiarBE()
        {
            DestinatarioTextBox.Text = string.Empty;
            CuerpoTextbox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Carta> repositorio = new Repositorio<Carta>();

            Carta cartas = Llenaclase();

            bool paso = false;

            if (Page.IsValid)
            {
                if (CartaidTextBox.Text == "0")
                {
                    paso = repositorio.Guardar(cartas);

                }


                else
                {
                    var verificar = repositorio.Buscar(Utilities.Utils.ToInt(CartaidTextBox.Text));

                    if (verificar != null)
                    {
                        paso = repositorio.Modificar(cartas);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
                     "toastr.error('Esta carta No Existe','Fallo',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                        return;
                    }
                }

                if (paso)

                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
                     "toastr.success('carta Registrada','Exito',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);

                }

                else

                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
                 "toastr.error('No pudo Guardar','Fallo',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                }
                Limpiar();
                return;
            }
        }

        protected void ElminarButton_Click(object sender, EventArgs e)
        {
            LimpiarBE();
            Repositorio<Carta> repositorio = new Repositorio<Carta>();

            int id = Utilities.Utils.ToInt(CartaidTextBox.Text);
            var carta = repositorio.Buscar(id);


            if (carta == null)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
               "toastr.info('Este Numero de carta no Existe o ya a Sido Eliminado','Informacion',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
            }

            else
            {
                repositorio.Eliminar(id);

                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
               "toastr.success('carta a sido Borrada','Eliminado',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                Limpiar();
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Carta> repositorio = new Repositorio<Carta>();


            Carta cartas = repositorio.Buscar(Utilities.Utils.ToInt(CartaidTextBox.Text));

            LimpiarBE();
            if (cartas != null)
            {
                LlenaCampos(cartas);

                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
               "toastr.success('Encontrada','Exito',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
             "toastr.info('Numero de carta no Existe','No Existe',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
            }
        }
    }
}