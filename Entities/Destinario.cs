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
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public int CartasRecibidas { get; set; }

        public Destinario(int DestinarioId, string nombres,string direccion, int cartasrecibidas)
        {
            DestinarioID = DestinarioID;
            Nombres = nombres;
            Direccion = direccion;
            CartasRecibidas = cartasrecibidas;
        }

        public Destinario()
        {
            DestinarioID = 0;
            Nombres = string.Empty;
            Direccion = string.Empty;
            CartasRecibidas = 0;
        }
    }
}
