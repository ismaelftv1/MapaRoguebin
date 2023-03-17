using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
                Malos.Add(new Orco(10,7));
            }
            else if (azar == 1)
            {
                Malos.Add(new Troll(32,7));
            }
        }

        public void imprimir() 
        {
            for (int i = 0; i < Malos.Count; i++)
            {
                if (Malos is not null)
                {
                    ((Enemigo)Malos[i]).dibuja();
                }
            }
        }

        public void Borrar()
        {
            Malos.Clear();
        }

        public void mover(Mapa map)
        {
            Random rng = new Random();

            for (int i = 0; i < Malos.Count; i++)
            {
                Console.SetCursorPosition(Malos[i].x, Malos[i].y);
                Celda celda = map.mapa[Malos[i].x, Malos[i].y];

                celda.Dibuja();

                int numero = rng.Next(1, 5);


                if (Malos[i].x++ < map.mapa.GetLength(0) &&
                    Malos[i].y++ < map.mapa.GetLength(1) &&
                    Malos[i].x++ >= 0 &&
                    Malos[i].y++ >= 0 &&
                    map.mapa[Malos[i].x++, Malos[i].y++] is not Muro)
                {
                    switch (numero)
                    {
                        case 1:
                            Malos[i].x++;
                            break;
                        case 2:
                            Malos[i].y++;
                            break;
                        case 3:
                            Malos[i].y--;
                            break;
                        case 4:
                            Malos[i].x--;
                            break;
                    }
                }
                

               
            }
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