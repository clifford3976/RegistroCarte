using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioCarta : Repositorio<Carta>
    {
        public override bool Guardar(Carta cartas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {


                if (contexto.carta.Add(cartas) != null)
                {

                    var carta = contexto.destinario.Find(cartas.DestinarioID);
                    //aumentar el balance
                    carta.CartasRecibidas += 1;


                    contexto.SaveChanges();
                    paso = true;


                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }

        public override bool Modificar(Carta carta)
        {

            bool paso = false;
            Contexto contexto = new Contexto();
            Repositorio<Carta> repositorio = new Repositorio<Carta>();
            try
            {

                //Buscar

                var Cartaanterior = repositorio.Buscar(carta.CartaID);

                var destinario = contexto.destinario.Find(carta.DestinarioID);
                var destinarioanterior = contexto.destinario.Find(Cartaanterior.CartaID);

                if (carta.DestinarioID != Cartaanterior.DestinarioID)
                {
                    destinario.CartasRecibidas += 1;
                    destinarioanterior.CartasRecibidas -= 1;
                }



                //diferencia
                int diferencia;
                diferencia = 1 - 1;



                //aplicar diferencia
                destinario.CartasRecibidas += diferencia;

                contexto.Entry(carta).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }


        public override bool Eliminar(int id)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Carta carta = contexto.carta.Find(id);

                if (carta != null)
                {
                    var cuenta = contexto.destinario.Find(carta.DestinarioID);
                    //Incrementar la cantidad
                    cuenta.CartasRecibidas -= 1;

                    contexto.Entry(carta).State = EntityState.Deleted;

                }

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                    contexto.Dispose();
                }


            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }




    }
}
