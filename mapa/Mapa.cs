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
                    mapa[i, j] = new Celda(rng.Next(3));
                }
            }

        }

        public void RamdonWalk()
        {
            int ancho = mapa.GetLength(0);
            int alto = mapa.GetLength(1);

            int x = mapa.GetLength(0)/2;
            int y = mapa.GetLength(1)/2;
            int suelo = 1500;
            int suelomin = 0;

            // initialize all map cells to walls.

            for (int i = 0; i < mapa.GetLength(0); i++)
            {
                for (int j = 0; j < mapa.GetLength(1); j++)
                {
                    mapa[i, j] = new Celda(0);
                }
            }
            //pick a map cell as the starting point.
            mapa[x,y].terreno = 2;
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

                if (x > ancho-1 || x < 0)
                {
                    x = ancho / 2;
                }
                else if (y > alto-1 || y < 0)
                {
                    y = alto / 2;
                }

                if (mapa[x, y].terreno == 0)
                {
                    mapa[x, y].terreno = 2;
                    suelomin++;
                }


            } while (suelomin != suelo);
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
                        mapa[i, j] = new Celda(Materiales.Muro);
                    }
                    else
                    {
                        mapa[i, j] = new Celda(Materiales.Tierra);

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
                            if (mapa[i + 1, j].terreno == 0)
                            {
                                mapa[i, j].vecinos++;
                            }
                        }
                        if (i > 0)
                        {
                            if (mapa[i - 1, j].terreno == 0)
                            {
                                mapa[i, j].vecinos++;
                            }
                        }
                        if (j < alto - 1)
                        {
                            if (mapa[i, j + 1].terreno == 0)
                            {
                                mapa[i, j].vecinos++;
                            }
                        }
                        if (j > 0)
                        {
                            if (mapa[i, j - 1].terreno == 0)
                            {
                                mapa[i, j].vecinos++;
                            }
                        }
                        if (j < alto - 1 && i < ancho - 1)
                        {
                            if (mapa[i + 1, j + 1].terreno == 0)
                            {
                                mapa[i, j].vecinos++;
                            }
                        }
                        if (i > 0 && j < alto - 1)
                        {
                            if (mapa[i - 1, j + 1].terreno == 0)
                            {
                                mapa[i, j].vecinos++;
                            }
                        }
                        if (i < ancho - 1 && j > 0)
                        {
                            if (mapa[i + 1, j - 1].terreno == 0)
                            {
                                mapa[i, j].vecinos++;
                            }
                        }
                        if (i > 0 && j > 0)
                        {
                            if (mapa[i - 1, j - 1].terreno == 0)
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
                        if (mapa[i, j].vecinos < 4 && mapa[i, j].terreno == 0)
                        {
                            mapa[i, j].terreno = 2;
                        }
                        else
                        {
                            if (mapa[i, j].vecinos > 6 && mapa[i, j].terreno == 2)
                            {
                                mapa[i, j].terreno = 0;
                            }
                        }

                        if (i == 0 || j == 0 || j == alto - 1 || i == ancho - 1)
                        {
                            mapa[i, j].terreno = 0;
                        }
                    }
                }
                vueltas++;
            } while (vueltas != vueltasmin);

            
            
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