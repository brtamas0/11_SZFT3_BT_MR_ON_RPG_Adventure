using System;
using System.Text;

namespace RPG_Game
{
    public class Kijelzo
    {
        public void Megjelenit(int display, Karakter karakter, Palya palya, int renderx, int rendery)
        {
            switch (display)
            {
                case 0:
                    JatekKijelzes(karakter, palya, renderx, rendery);
                    break;
                case 1:
                    MenuKijelzes();
                    break;
                case 2:
                    MapKijelzes();
                    break;
                case 3:
                    InventoryKijelzes();
                    break;
                case 4:
                    ShopKijelzes();
                    break;
                case 5:
                    HarcKijelzes();
                    break;
                case 6:
                    BeallitasokKijelzes();
                    break;
            }
        }

        private void JatekKijelzes(Karakter karakter, Palya palya, int renderx, int rendery)
        {
            StringBuilder terkepString = new StringBuilder();
            string[,] terkep = palya.GetTerkep();

            for (int i = karakter.x - rendery; i < karakter.x + rendery; i++)
            {
                for (int j = karakter.y - renderx; j < karakter.y + renderx; j++)
                {
                    terkepString.Append(terkep[i, j]);
                }
                terkepString.Append('\n');
            }

            Console.SetCursorPosition(0, 0);
            Console.Write(terkepString.ToString());
            Console.WriteLine($"{$"{new string('█', karakter.Hp / 10)}{new string('▒', 10 - karakter.Hp / 10)}"} {karakter.Hp}% ❤️ \n{karakter.Sebzes} 🗡️ \n{karakter.Armor} 🛡️\nX: {karakter.y - renderx * 3 - 1} \nY: {karakter.x - rendery * 3 - 1}");
        }

        private void MenuKijelzes()
        {
            Console.Clear();
            Console.WriteLine("Menü");
            Console.WriteLine("Képességek");
            Console.WriteLine("Irányítás");
            Console.WriteLine("Segítség");
            Console.WriteLine("Kinézet");
        }

        private void MapKijelzes()
        {
            Console.Clear();
            Console.WriteLine("Map");
        }

        private void InventoryKijelzes()
        {
            Console.Clear();
            Console.WriteLine("Inventory");
        }

        private void ShopKijelzes()
        {
            Console.Clear();
            Console.WriteLine("Shop");
        }

        private void HarcKijelzes()
        {
            Console.Clear();
            Console.WriteLine("Harc");
        }

        private void BeallitasokKijelzes()
        {
            Console.Clear();
            Console.WriteLine("Beállítások");
        }

        public static void MenuGombok(ref int display)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.M)
                {
                    display = display == 0 ? 2 : 0;
                }
                if (key.Key == ConsoleKey.E)
                {
                    display = display == 0 ? 3 : 0;
                }
                if (key.Key == ConsoleKey.G)
                {
                    display = display == 0 ? 4 : 0;
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    display = display == 0 ? 6 : 0;
                }
            }
        }
    }
}