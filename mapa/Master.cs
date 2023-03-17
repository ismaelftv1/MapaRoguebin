using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace mapa
{
    public class Master
    {
        Mapa map;
        Jugador player;
        Ejercito Malos = new Ejercito();

        public Master(Mapa map, Jugador player)
        {
            this.map = map;
            this.player = player;
        }

        public void Moverjugador(ConsoleKey tecla)
        {

            Console.SetCursorPosition(player.x, player.y);

            Celda celda = map.mapa[player.x, player.y];

            celda.Dibuja();
            switch (tecla)
            {
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (player.Inventario[0] is Pico)
                    {
                        PicarAbajo();
                    }
                    MoverAbajo();
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (player.Inventario[0] is Pico)
                    {
                        PicarDerecha();
                    }
                    MoverDerecha();
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (player.Inventario[0] is Pico)
                    {
                        PicarArriba();
                    }
                    MoverArriba();
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (player.Inventario[0] is Pico)
                    {
                        PicarIzquierda();
                    }
                    MoverIzquierda();
                    break;
            }
        }

        public void Comprobadores()
        {
            NuevoMapa();
            danotrampa();
            Beber();
            CogerMena();
            Crafteo();
            PicoRoto();
        }

        //Mecanicas Malos

        public void SpawnMalos()
        {
            for (int i = 0; i < 5; i++)
            {
                Malos.Addmalo();
            }
        }

        //Mecanicas items

        void Beber()
        {
            if (map.mapa[player.x, player.y].loot is Cerveza)
            {
                player.setvida(15);
                map.mapa[player.x, player.y].loot = null;
            }
        }

        void PicoRoto()
        {
            if (player.Inventario[0] is Pico)
            {
                if (((Pico)player.Inventario[0]).durabilidad <= 0)
                {
                    player.Inventario.RemoveAt(0);
                }
            }
        }

        void CogerMena()
        {
            if (map.mapa[player.x, player.y].loot is Mineral)
            {
                if (map.mapa[player.x, player.y].loot is Cobre)
                {
                    player.Inventario.Add(new Cobre());
                }
                else if (map.mapa[player.x, player.y].loot is Hierro)
                {
                    player.Inventario.Add(new Hierro());
                }
                else if (map.mapa[player.x, player.y].loot is Plata)
                {
                    player.Inventario.Add(new Plata());
                }
                else if (map.mapa[player.x, player.y].loot is Oro)
                {
                    player.Inventario.Add(new Oro());
                }
                else if (map.mapa[player.x, player.y].loot is Mithril)
                {
                    player.Inventario.Add(new Mithril());
                }
                map.mapa[player.x, player.y].loot = null;
            }
  
        }

        void Crafteo()
        {
            int CantidadCobre = player.Inventario.FindAll(x => x is Cobre).Count;
            int CantidadHierro = player.Inventario.FindAll(x => x is Hierro).Count;
            int CantidadOro = player.Inventario.FindAll(x => x is Oro).Count;
            int CantidadPlata = player.Inventario.FindAll(x => x is Plata).Count;
            int CantidadMithril = player.Inventario.FindAll(x => x is Mithril).Count;

            Pico PicoCobre = new Pico(20,1);
            Pico PicoHierro = new Pico(50,1);
            Pico PicoOro = new Pico(30,3);
            Pico PicoPlata = new Pico(70,2);
            Pico PicoMithril = new Pico(100,5);

            if (map.mapa[player.x,player.y] is Horno)
            {
                if (CantidadCobre >= 2)
                {
                    player.Inventario.RemoveAll(x => x is Cobre);
                    player.Inventario.Insert(0,PicoCobre);
                }
                if (CantidadHierro >= 2)
                {
                    player.Inventario.RemoveAll(x => x is Hierro);
                    player.Inventario.Insert(0, PicoHierro);
                }
                if (CantidadOro >= 2)
                {
                    player.Inventario.RemoveAll(x => x is Oro);
                    player.Inventario.Insert(0, PicoOro);
                }
                if (CantidadPlata >= 2)
                {
                    player.Inventario.RemoveAll(x => x is Plata);
                    player.Inventario.Insert(0, PicoPlata);
                }
                if (CantidadMithril >= 2)
                {
                    player.Inventario.RemoveAll(x => x is Mithril);
                    player.Inventario.Insert(0, PicoMithril);
                }
            }
        }
         
        // picar

        void Picar(int picarx, int picary)
        {
            picarx = player.x + picarx;
            picary = player.y + picary;

            if (picarx >= 0 &&
                picary >= 0 &&
                picarx < map.mapa.GetLength(0) &&
                picary < map.mapa.GetLength(1) &&
                map.mapa[picarx, picary].loot is Mineral &&
                ((Mineral)map.mapa[picarx, picary].loot).vida > 0)
            {
                ((Mineral)map.mapa[picarx, picary].loot).vida -= 1;
                ((Pico)player.Inventario[0]).durabilidad -= 1;
            }
            else if (player.Inventario[0] is Pico &&
                    picarx < map.mapa.GetLength(0) &&
                    picary < map.mapa.GetLength(1) &&
                    picarx >= 0 &&
                    picary >= 0 &&
                    map.mapa[picarx, picary] is Muro)
            {
                map.mapa[picarx, picary] = new Suelo();
                ((Pico)player.Inventario[0]).durabilidad -= 1;
            }
        }

        void PicarArriba()
        {
            Picar(0, -1);
        }
        void PicarAbajo()
        {
            Picar(0, 1);
        }
        void PicarDerecha()
        {
            Picar(1, 0);
        }
        void PicarIzquierda()
        {
            Picar(-1, 0);
        }

        //Mecanicas trampas

        void danotrampa()
        {
            if (map.mapa[player.x, player.y].trampa == 1)
            {
                player.setvida(-5);
            }
            else if (map.mapa[player.x, player.y].trampa == 2)
            {
                player.setvida(-15);
            }
            else if (map.mapa[player.x, player.y].trampa == 3)
            {
                player.setvida(-25);
            }
        }

        //Mecanicas generar nuevo mapa
        void NuevoMapa()
        {
            if (map.mapa[player.x, player.y].salida == 1 && map.nivel >= 5)
            {
                map.CellularAut();
                map.Imprimir();
                SpawnJugador();
                map.nivel++;
            }
            else if (map.mapa[player.x, player.y].salida == 1 && map.nivel < 5)
            {
                map.RamdonWalk();
                map.Imprimir();
                SpawnJugador();
                map.nivel++;
            }
        }

        //Mecanicas Jugador
        void MoverMecanica(int moverx, int movery)
        {
            moverx = player.x + moverx;
            movery = player.y + movery;
            if (moverx >= 0 &&
                movery >= 0 &&
                moverx < map.mapa.GetLength(0) &&
                movery < map.mapa.GetLength(1) &&
                map.mapa[moverx, movery].loot is Mineral &&
                map.mapa[moverx, movery] is not Muro)
            {
                if (((Mineral)map.mapa[moverx, movery].loot).vida <= 0)
                {
                    player.x = moverx;
                    player.y = movery;
                }
            }
            else if (moverx < map.mapa.GetLength(0) &&
                     movery < map.mapa.GetLength(1) &&
                     moverx >= 0 &&
                     movery >= 0 &&
                     map.mapa[moverx, movery] is not Muro)
            {
                player.x = moverx;
                player.y = movery;
            }
        }
        void MoverArriba()
        {
            MoverMecanica(0, -1);
        }
        void MoverAbajo()
        {
            MoverMecanica(0, 1);
        }
        void MoverDerecha()
        {
            MoverMecanica(1, 0);
        }
        void MoverIzquierda()
        {
            MoverMecanica(-1, 0);
        }
        public void SpawnJugador()
        {
            Random rng = new Random();
            if (map.mapa[player.x, player.y] is not Suelo)
            {
                do
                {
                    int x = rng.Next(map.mapa.GetLength(0));
                    int y = rng.Next(map.mapa.GetLength(1));
                    player.x = x;
                    player.y = y;
                } while (map.mapa[player.x, player.y] is not Suelo);
            }
        }



    }
}