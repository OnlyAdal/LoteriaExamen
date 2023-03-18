using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoteriaExamen.Bussines
{
    public class Bcards
    {
        private LoteriaEntities db = new LoteriaEntities();
        public Bcards()
        {

        }

        public Dictionary<string, object> GetTarjetas(int total)
        {
            try
            {
                List<Tarjetas> tar = new List<Tarjetas>();
                List<int>[] tablass = new List<int>[total];
                Random rnd = new Random();
                var result = new Dictionary<string, object>();
                int contador = 1;
                int rndm = 0;
                bool repeat = false;
                foreach (var item in tablass)
                {
                    int[] numeros = new int[16];

                    for (int e = 0; e < numeros.Length;)
                    {
                        repeat = false;
                        rndm = rnd.Next(1, 54);
                        for (int j = 0; j < numeros.Length && !repeat; j++)
                        {
                            // si es igual , se encuentra cambiamos la bandera
                            if (numeros[j] == rndm) repeat = true;
                        }
                        //si se encuentra
                        if (repeat)
                        {
                            e = e;
                        }
                        else
                        {
                            //caso contrario añadimos el valor al array
                            // e incrementamos el numero de eementos ingresados

                            numeros[e] = rndm;
                            e++;

                        }
                        tar = (from t in db.Tarjetas where numeros.Contains(t.Carta) select t).ToList();
                    }
                    result.Add("tabla" + contador, tar);

                    contador++;


                }
                return result;


            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}