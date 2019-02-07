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
    public class CartaBLL : RepositorioBase<Carta>
    {
        public bool Guardar(Carta entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                if (contexto.carta.Add(entity) != null)
                {

                    var destinario = contexto.destinario.Find(entity.DestinarioID);
                    //Incrementar el balance
                    destinario.CartasRecibidas += entity.Cantidad;


                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }

        public bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Carta carta = contexto.carta.Find(id);

                if (carta != null)
                {
                    var destinario = contexto.destinario.Find(carta.DestinarioID);
                    //Incrementar la cantidad
                    destinario.CartasRecibidas -= carta.Cantidad;

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


        public override bool Modificar(Carta entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            RepositorioBase<Carta> repositorio = new RepositorioBase<Carta>();
            try
            {

                //Buscar

                var cartaanterior = repositorio.Buscar(entity.CartaID);

                var destinario = contexto.destinario.Find(entity.DestinarioID);
                var destinarioanterior = contexto.destinario.Find(cartaanterior.DestinarioID);

                if (entity.DestinarioID != cartaanterior.DestinarioID)
                {
                    destinario.CartasRecibidas += entity.Cantidad;
                    destinarioanterior.CartasRecibidas -= cartaanterior.Cantidad;
                }



                //identificar la diferencia ya sea restada o sumada
                int diferencia;
                diferencia = entity.Cantidad - cartaanterior.Cantidad;



                //aplicar diferencia al inventario 
                destinario.CartasRecibidas += diferencia;

                contexto.Entry(entity).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }
    }
}
