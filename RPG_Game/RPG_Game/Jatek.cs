using System;
using System.Threading;
using System.Text;
using System.IO;

namespace RPG_Game
{
    public class Jatek
    {
        private int renderx = 60;
        private int rendery = 20;
        private int display = 0; // 0 = game 1 = harc
        private int gamestate = 0; // 0 = beszélgetés, 1 = játék indul, stb.
        private DateTime startTime;
        private Karakter karakter;
        private Palya palya;
        private Kijelzo kijelzo;

        public Jatek()
        {
            int x = 147;
            int y = 365;
            karakter = new Karakter(x, y, "Játékos", 10, 5, 0, 1, 70, 100, new string[10]);
            palya = new Palya(renderx, rendery);
            kijelzo = new Kijelzo();
            startTime = DateTime.Now;
        }

        public void Fut()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.CursorVisible = false;
            Console.Title = "RPG Game";
            Console.OutputEncoding = Encoding.UTF8;

            palya.Betolt("map.txt");
            KarakterElhelyezes();

            while (true)
            {
                if (gamestate == 0)
                {
                    // Párbeszéd megjelenítése
                    Párbeszéd();
                }
                else
                {
                    kijelzo.Megjelenit(display, karakter, palya, renderx, rendery);
                    Kezeles();
                    Thread.Sleep(1);
                }
            }
        }

        private void Kezeles()
        {
            if (display == 0)
            {
                Mozgas();
            }
        }

        private void Mozgas()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                int newX = karakter.x;
                int newY = karakter.y;

                if (key.Key == ConsoleKey.W)
                {
                    newX -= 1;
                }
                if (key.Key == ConsoleKey.S)
                {
                    newX += 1;
                }
                if (key.Key == ConsoleKey.A)
                {
                    newY -= 1;
                }
                if (key.Key == ConsoleKey.D)
                {
                    newY += 1;
                }

                if (EllenorizMozgas(newX, newY, key.Key))
                {
                    UjKarakterPozicio(newX, newY);
                }

                // Shop
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Vasarlas(50, 20, "Kard");
                        break;
                    case ConsoleKey.D2:
                        Vasarlas(25, 10, "Íj");
                        break;
                    case ConsoleKey.D3:
                        Vasarlas(20, 10, "Pajzs");
                        break;
                }
            }
        }

        private void Vasarlas(int ar, int novekedes, string targy)
        {
            if (karakter.Gold >= ar)
            {
                karakter.Gold -= ar;
                if (targy == "Kard")
                {
                    karakter.Sebzes += novekedes;
                }
                else if (targy == "Íj")
                {
                    karakter.Sebzes += novekedes;
                }
                else if (targy == "Pajzs")
                {
                    karakter.Armor += novekedes;
                }

                for (int i = 0; i < karakter.Inventory.Length; i++)
                {
                    if (karakter.Inventory[i] == null)
                    {
                        karakter.Inventory[i] = targy;
                        break;
                    }
                }
            }
        }

        private bool EllenorizMozgas(int ujX, int ujY, ConsoleKey key)
        {
            int characterHeight = karakter.kinezet.Length;
            int characterWidth = karakter.kinezet[0].Length;
            string[,] terkep = palya.GetTerkep();

            switch (key)
            {
                case ConsoleKey.W:
                    for (int j = 0; j < characterWidth; j++)
                    {
                        if (terkep[ujX, karakter.y + j] != " ")
                        {
                            return false;
                        }
                    }
                    break;
                case ConsoleKey.S:
                    for (int j = 0; j < characterWidth; j++)
                    {
                        if (terkep[ujX + characterHeight - 1, karakter.y + j] != " ")
                        {
                            return false;
                        }
                    }
                    break;
                case ConsoleKey.A:
                    for (int i = 0; i < characterHeight; i++)
                    {
                        if (terkep[karakter.x + i, ujY] != " ")
                        {
                            return false;
                        }
                    }
                    break;
                case ConsoleKey.D:
                    for (int i = 0; i < characterHeight; i++)
                    {
                        if (terkep[karakter.x + i, ujY + characterWidth - 1] != " ")
                        {
                            return false;
                        }
                    }
                    break;
            }

            return true;
        }

        private void UjKarakterPozicio(int ujX, int ujY)
        {
            // Törli a karakter korábbi helyét
            for (int i = 0; i < karakter.kinezet.Length; i++)
            {
                for (int j = 0; j < karakter.kinezet[i].Length; j++)
                {
                    if (karakter.kinezet[i][j] != ' ')
                    {
                        palya.GetTerkep()[karakter.x + i, karakter.y + j] = " ";
                    }
                }
            }

            karakter.x = ujX;
            karakter.y = ujY;

            // Beállítja a karakter új helyét
            for (int i = 0; i < karakter.kinezet.Length; i++)
            {
                for (int j = 0; j < karakter.kinezet[i].Length; j++)
                {
                    if (karakter.kinezet[i][j] != ' ')
                    {
                        palya.GetTerkep()[karakter.x + i, karakter.y + j] = karakter.kinezet[i][j].ToString();
                    }
                }
            }
        }

        private void KarakterElhelyezes()
        {
            for (int i = 0; i < karakter.kinezet.Length; i++)
            {
                for (int j = 0; j < karakter.kinezet[i].Length; j++)
                {
                    if (karakter.kinezet[i][j] != ' ')
                    {
                        palya.GetTerkep()[karakter.x + i, karakter.y + j] = karakter.kinezet[i][j].ToString();
                    }
                }
            }
        }

        private void Párbeszéd()
        {
            Console.Clear();
            Thread.Sleep(1000);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            string parbeszed1 = File.ReadAllText("parbeszed1.txt");
            Console.WriteLine(parbeszed1);
            Thread.Sleep(1000);
            Console.ReadKey();
            Console.Clear();
            string parbeszed2 = File.ReadAllText("parbeszed2.txt");
            Console.WriteLine(parbeszed2);
            Thread.Sleep(1000);
            Console.ReadKey();
            Console.Clear();
            string parbeszed3 = File.ReadAllText("parbeszed3.txt");
            Console.WriteLine(parbeszed3);
            Thread.Sleep(1000);
            Console.ReadKey();
            Console.Clear();


            // 10 másodperc várakozás
            Thread.Sleep(1000);

            gamestate = 1; // Játék indul
            startTime = DateTime.Now;
        }

        private void EllenorizGameState()
        {
            if (gamestate == 6)
            {
                DateTime endTime = DateTime.Now;
                double teljesitesiIdo = (endTime - startTime).TotalSeconds;
                int pontszam = 1000 - (int)teljesitesiIdo;
                Console.WriteLine($"Játék vége! Pontszám: {pontszam}");
                Environment.Exit(0); // Program befejezése
            }
        }
    }
}
