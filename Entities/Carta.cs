using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Carta
    {
        [Key]

        public int CartaID { get; set; }
        public DateTime Fecha { get; set; }
        public int DestinarioID { get; set; }
        public string Cuerpo { get; set; }
        public int Cantidad { get; set; }

        public Carta(int cartaID, DateTime fecha, int destinarioID, string cuerpo, int cantidad)
        {
            CartaID = cartaID;
            Fecha = fecha;
            DestinarioID = destinarioID;
            Cuerpo = cuerpo;
            Cantidad = cantidad;
        }

        public Carta()
        {
            CartaID = 0;
            Fecha = DateTime.Now;
            DestinarioID = 0;
            Cuerpo = string.Empty;
            Cantidad = 0;
        }
    }
}
