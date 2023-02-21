using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mapa
{
    public class Mapa
    {
        public Celda[,] mapa;
        Random rng = new Random();
        public int nivel = 0;

        public Mapa(int ancho, int alto)
        {
            mapa = new Celda[ancho, alto];
            CellularAut();
        }

        public void Rellenar()
        {
            for (int i = 0; i < mapa.GetLength(0); i++)
            {
                for (int j = 0; j < mapa.GetLength(1); j++)
                {
                    mapa[i, j] = new Muro();
                }
            }
        }

        public void RamdonWalk()
        {
            int ancho = mapa.GetLength(0);
            int alto = mapa.GetLength(1);

            int x = mapa.GetLength(0) / 2;
            int y = mapa.GetLength(1) / 2;
            int suelo = 1500;
            int suelomin = 0;

            // initialize all map cells to walls.

            for (int i = 0; i < mapa.GetLength(0); i++)
            {
                for (int j = 0; j < mapa.GetLength(1); j++)
                {
                    mapa[i, j] = new Muro();
                }
            }
            //pick a map cell as the starting point.
            mapa[x, y] = new Suelo();
            //turn the selected map cell into floor.

            //while insufficient cells have been turned into floor,
            //    take one step in a random direction.
            //   if the new map cell is wall,
            //        turn the new map cell into floor and increment the count of floor tiles.
            do
            {
                int numero = rng.Next(1, 5);


                switch (numero)
                {
                    case 1:
                        x++;
                        break;
                    case 2:
                        y++;
                        break;
                    case 3:
                        y--;
                        break;
                    case 4:
                        x--;
                        break;
                }

                if (x > ancho - 1 || x < 0)
                {
                    x = ancho / 2;
                }
                else if (y > alto - 1 || y < 0)
                {
                    y = alto / 2;
                }

                if (mapa[x, y] is Muro)
                {
                    mapa[x, y] = new Suelo();
                    suelomin++;
                }

            } while (suelomin != suelo);
            SpawnSalida();
            Trampas();
        }

        public void CellularAut()
        {

            int ancho = mapa.GetLength(0);
            int alto = mapa.GetLength(1);
            int vueltas = 0;
            int vueltasmin = 7;

            for (int i = 0; i < mapa.GetLength(0); i++)
            {
                for (int j = 0; j < mapa.GetLength(1); j++)
                {

                    if (rng.Next(100) < 60)
                    {
                        mapa[i, j] = new Muro();
                    }
                    else
                    {
                        mapa[i, j] = new Suelo();

                    }


                }
            }

            do
            {
                for (int i = 0; i < mapa.GetLength(0); i++)
                {
                    for (int j = 0; j < mapa.GetLength(1); j++)
                    {
                        mapa[i, j].vecinos = 0;
                        if (i < ancho - 1)
                        {
                            if (mapa[i + 1, j] is Muro)
                            {
                                mapa[i, j].vecinos++;
                            }
                        }
                        if (i > 0)
                        {
                            if (mapa[i - 1, j] is Muro)
                            {
                                mapa[i, j].vecinos++;
                            }
                        }
                        if (j < alto - 1)
                        {
                            if (mapa[i, j + 1] is Muro)
                            {
                                mapa[i, j].vecinos++;
                            }
                        }
                        if (j > 0)
                        {
                            if (mapa[i, j - 1] is Muro)
                            {
                                mapa[i, j].vecinos++;
                            }
                        }
                        if (j < alto - 1 && i < ancho - 1)
                        {
                            if (mapa[i + 1, j + 1] is Muro)
                            {
                                mapa[i, j].vecinos++;
                            }
                        }
                        if (i > 0 && j < alto - 1)
                        {
                            if (mapa[i - 1, j + 1] is Muro)
                            {
                                mapa[i, j].vecinos++;
                            }
                        }
                        if (i < ancho - 1 && j > 0)
                        {
                            if (mapa[i + 1, j - 1] is Muro)
                            {
                                mapa[i, j].vecinos++;
                            }
                        }
                        if (i > 0 && j > 0)
                        {
                            if (mapa[i - 1, j - 1] is Muro)
                            {
                                mapa[i, j].vecinos++;
                            }
                        }
                    }
                }

                for (int i = 0; i < mapa.GetLength(0); i++)
                {
                    for (int j = 0; j < mapa.GetLength(1); j++)
                    {
                        if (mapa[i, j].vecinos < 4 && mapa[i, j] is Muro)
                        {
                            mapa[i, j] = new Suelo();
                        }
                        else
                        {
                            if (mapa[i, j].vecinos > 6 && mapa[i, j] is Suelo)
                            {
                                mapa[i, j] = new Muro();
                            }
                        }

                        if (i == 0 || j == 0 || j == alto - 1 || i == ancho - 1)
                        {
                            mapa[i, j] = new Muro();
                        }
                    }
                }
                vueltas++;
            } while (vueltas != vueltasmin);
            SpawnSalida();
            SpawnHorno();
            Trampas();
            SpawnMenas();
            SpawnCerveza();
        }

        public void SpawnSalida()
        {
            int salida = 0;
            do
            {
                int x = rng.Next(mapa.GetLength(0));
                int y = rng.Next(mapa.GetLength(1));
                if (mapa[x, y] is not Muro)
                {
                    mapa[x, y].salida = 1;
                    salida++;
                }
            } while (salida != 1);
        }

        public void SpawnHorno()
        {
            int horno = 0;
            do
            {
                int x = rng.Next(mapa.GetLength(0));
                int y = rng.Next(mapa.GetLength(1));
                if (mapa[x, y] is not Muro)
                {
                    mapa[x, y] = new Horno();
                    horno++;
                }
            } while (horno != 1);
        }

        public void SpawnMenas()
        {
            int Menas = 0;

            do
            {
                int probabilidad = rng.Next(100);
                int x = rng.Next(mapa.GetLength(0));
                int y = rng.Next(mapa.GetLength(1));
                if (x != 0 || y != 0 || y != mapa.GetLength(1) - 1 || x != mapa.GetLength(0) - 1 && mapa[x,y].loot == null)
                {

                    if (probabilidad > 50)
                    {
                        mapa[x, y] = new Muro();
                        mapa[x, y].loot = new Cobre();
                        Menas++;

                    }
                    else if (probabilidad > 30)
                    {
                        mapa[x, y] = new Muro();
                        mapa[x, y].loot = new Hierro();
                        Menas++;
                    }
                    else if (probabilidad > 10)
                    {
                        mapa[x, y] = new Muro();
                        mapa[x, y].loot = new Plata();
                        Menas++;
                    }
                    else if (probabilidad > 5)
                    {
                        mapa[x, y] = new Muro();
                        mapa[x, y].loot = new Oro();
                        Menas++;
                    }
                    else if (probabilidad > 3)
                    {
                        mapa[x, y] = new Muro();
                        mapa[x, y].loot = new Mithril();
                        Menas++;
                    }
                }
            } while (Menas != 10);
        }

        public void SpawnCerveza()
        {
            int Cantidad = 0;
            do
            {
                
                int x = rng.Next(mapa.GetLength(0));
                int y = rng.Next(mapa.GetLength(1));
                if (mapa[x,y] is not Muro && mapa[x, y].loot == null)
                {
                    mapa[x, y].loot = new Cerveza();
                    Cantidad++;
                }
            } while (Cantidad != 10);
        }

        public void Trampas()
        {
            int trampasminimas = 20;
            int trampastotal = 0;
            do
            {
                int x = rng.Next(mapa.GetLength(0));
                int y = rng.Next(mapa.GetLength(1));
                int tipo = rng.Next(1, 4);

                if (mapa[x, y] is Suelo && mapa[x, y].trampa == 0)
                {
                    if (tipo == 1)
                    {
                        mapa[x, y].trampa = 1;
                        trampastotal++;
                    }
                    else if (tipo == 2)
                    {
                        mapa[x, y].trampa = 2;
                        trampastotal++;
                    }
                    else if (tipo == 3)
                    {
                        mapa[x, y].trampa = 3;
                        trampastotal++;
                    }
                }
            } while (trampastotal != trampasminimas);
        }

        public void Imprimir()
        {
            for (int i = 0; i < mapa.GetLength(0); i++)
            {
                for (int j = 0; j < mapa.GetLength(1); j++)
                {
                    Console.SetCursorPosition(i, j);
                    mapa[i, j].Dibuja();
                }
            }
        }
    }
}