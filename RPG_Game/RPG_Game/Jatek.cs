using System;
using System.Threading;
using System.Text;

namespace RPG_Game
{
    public class Jatek
    {
        public int renderx = 60;
        public int rendery = 30;
        private int display = 0; // 0 = game 1 = menü 2 = map, 3 = inventory, 4 = shop, 5 = harc, 6 = beállítások
        private Karakter karakter;
        private Palya palya;
        private Kijelzo kijelzo;

        public Jatek()
        {
            int x = 10 + renderx * 3;
            int y = 10 + rendery * 3;
            karakter = new Karakter(x, y, "Játékos", 10, 5, 0, 1, 100, 0, new string[10]);
            palya = new Palya(renderx, rendery);
            kijelzo = new Kijelzo();
        }

        public void Fut()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.CursorVisible = false;
            Console.Title = "RPG Game";
            Console.OutputEncoding = Encoding.UTF8;

            palya.Betolt("map.txt");

            while (true)
            {
                kijelzo.Megjelenit(display, karakter, palya, renderx, rendery);
                Thread.Sleep(1);
            }
        }

    }

    static void Main(string[] args)
    {
        Bolt bolt = new Bolt(500); // Kezdeti arany a játékosnak
        bolt.BoltElemekMegjelenitese();
        
        Console.WriteLine("\nAdd meg a vásárolni kívánt tárgy nevét:");
        string targyNeve = Console.ReadLine();
        
        bolt.TargyVasarlas(targyNeve);
    }
}