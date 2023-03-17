using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mapa
{
    public class Ejercito
    {
        List<Enemigo> Malos = new List<Enemigo>();

        public Ejercito()
        {
        }

        public void Addmalo()
        {
            Random rng = new Random();
            int azar = rng.Next(0, 2);

            if (azar == 0) 
            {
                Malos.Add(new Orco());
            }
            else if (azar == 1)
            {
                Malos.Add(new Troll());
            }
        }

        public void Borrar()
        {
            Malos.Clear();
        }

        public void BorrarMuertos()
        {
            for (int i = Malos.Count-1; i > Malos.Count; i--)
            {
                if (Malos[i].vida <= 0)
                {
                    Malos.RemoveAt(i);
                }
            }
        }
    }
}