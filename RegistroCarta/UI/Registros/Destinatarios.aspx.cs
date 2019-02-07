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
    public partial class Destinatarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                DestinatarioidTextBox.Text = "0";
                CartasRecibidasTextbox.Text = "0";

            }
        }
        public Destinario Llenaclase()
        {
            Destinario destinario = new Destinario();

            destinario.DestinarioID = Utilities.Utils.ToInt(DestinatarioidTextBox.Text);
            destinario.Nombres = NombreTextBox.Text;
            destinario.Direccion = DireccionTextBox.Text;
            destinario.CartasRecibidas = 0;
            return destinario;
        }
        public void Limpiar()
        {
            DestinatarioidTextBox.Text = "0";
            NombreTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            CartasRecibidasTextbox.Text = "0";
        }

        private void LlenaCampos(Destinario destinario)
        {

            DestinatarioidTextBox.Text = destinario.DestinarioID.ToString();
            NombreTextBox.Text = destinario.Nombres;
            DireccionTextBox.Text = destinario.Direccion;
            CartasRecibidasTextbox.Text = destinario.CartasRecibidas.ToString();
        }

        public void LimpiarBE()
        {
            NombreTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            CartasRecibidasTextbox.Text = "0";
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Destinario> repositorio = new Repositorio<Destinario>();

            Destinario destinario = Llenaclase();

            bool paso = false;

            if (Page.IsValid)
            {
                if (DestinatarioidTextBox.Text == "0")
                {
                    paso = repositorio.Guardar(destinario);

                }


                else
                {
                    var verificar = repositorio.Buscar(Utilities.Utils.ToInt(DestinatarioidTextBox.Text));

                    if (verificar != null)
                    {
                        paso = repositorio.Modificar(destinario);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
                     "toastr.error('Este destinatario No Existe','Fallo',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                        return;
                    }
                }

                if (paso)

                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
                     "toastr.success('destinatario Registrada','Exito',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);

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
            Repositorio<Destinario> repositorio = new Repositorio<Destinario>();



            int id = Utilities.Utils.ToInt(DestinatarioidTextBox.Text);
            var destinario = repositorio.Buscar(id);


            if (destinario == null)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
               "toastr.info('Este Numero de destinatario no Existe o ya a Sido Eliminado','Informacion',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
            }

            else
            {
                repositorio.Eliminar(id);

                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
               "toastr.success('destinatario a sido Borrada','Eliminado',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                Limpiar();
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Destinario> repositorio = new Repositorio<Destinario>();


            Destinario destinario = repositorio.Buscar(Utilities.Utils.ToInt(DestinatarioidTextBox.Text));

            LimpiarBE();
            if (destinario != null)
            {
                LlenaCampos(destinario);

                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
               "toastr.success('Encontrada','Exito',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
             "toastr.info('Numero de destinatario no Existe','No Existe',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
            }
        }
    }
}