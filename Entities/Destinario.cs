using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Destinario
    {
        [Key]

        public int DestinarioID { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public int CartasRecibidas { get; set; }

        public Destinario(int DestinarioId, DateTime fecha, string nombres, int cartasrecibidas)
        {
            DestinarioID = DestinarioID;
            Fecha = fecha;
            Nombres = nombres;
            CartasRecibidas = cartasrecibidas;
        }

        public Destinario()
        {
            DestinarioID = 0;
            Fecha = DateTime.Now;
            Nombres = string.Empty;
            CartasRecibidas = 0;
        }
    }
}
