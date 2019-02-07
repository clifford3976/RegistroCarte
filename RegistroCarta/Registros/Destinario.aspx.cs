using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroCarta.Registros
{
    public partial class Destinario : System.Web.UI.Page
    {

        RepositorioBase<Destinario> repositorio = new RepositorioBase<Destinario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechadateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                CartasRecibidasTexbox.Text = "0";
                DestinarioIDTextbox.Text = "0";
            }
        }

       
       
    }
}