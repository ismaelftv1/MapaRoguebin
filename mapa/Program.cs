namespace mapa
{
    class Program
    {
        private static void Main(string[] args)
        {
            
            Master game;
            Mapa map;
            Jugador player;
            Ejercito test;

            Console.WindowWidth = 135;


            map = new Mapa(100, 25);
            player = new Jugador(10, 10);
            test = new Ejercito();
            
            game = new Master(map, player, test);
            game.SpawnJugador();
            map.Imprimir();

            Console.CursorVisible = false;
            ConsoleKey tecla;
            player.Inventario.Add(new Pico(20,2));

            do
            {

                HUB.DibujaHUB(player, map);

                test.imprimir();
                player.dibuja();
                tecla = Console.ReadKey(true).Key;

                game.Moverjugador(tecla);
                test.mover(map);
                game.Comprobadores();
            } while (tecla != ConsoleKey.Escape && player.getVida() > 0);

           
        }
    }
}