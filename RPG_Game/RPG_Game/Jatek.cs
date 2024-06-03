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
        private int gamestate = 0; // 0 = párbeszéd, 1 = játék
        private DateTime startTime;
        private IKarakter karakter;
        private IPalya palya;
        private IKijelzo kijelzo;

        public Jatek()
        {
            int x = 148;
            int y = 366;
            karakter = new Karakter(x, y, "Játékos", 10, 5, 0, 1, 100, 100, new string[10]);
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
                    Parbeszed();
                }
                else
                {
                    kijelzo.Megjelenit(display, karakter, palya, renderx, rendery);
                    Kezeles();
                    Thread.Sleep(1);
                }
            }
        }

        private void Parbeszed()
        {
            Console.WriteLine("Nyomj meg egy gombot az indításhoz!");
            Console.WriteLine("Irányítás: WASD-vel történik.");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
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
            gamestate = 1;
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
                int newX = karakter.X;
                int newY = karakter.Y;

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
                    case ConsoleKey.F:
                        Harc();
                        break;
                }
            }
        }

        private void Vasarlas(int ar, int novekedes, string targy)
        {
            if (karakter.Gold >= ar)
            {
                karakter.Gold -= ar;
                if (targy == "Kard" || targy == "Íj")
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
            int characterHeight = karakter.Kinezet.Length;
            int characterWidth = karakter.Kinezet[0].Length;
            string[,] terkep = palya.GetTerkep();

            switch (key)
            {
                case ConsoleKey.W:
                    for (int j = 0; j < characterWidth; j++)
                    {
                        if (terkep[ujX, karakter.Y + j] != " ")
                        {
                            return false;
                        }
                    }
                    break;
                case ConsoleKey.S:
                    for (int j = 0; j < characterWidth; j++)
                    {
                        if (terkep[ujX + characterHeight - 1, karakter.Y + j] != " ")
                        {
                            return false;
                        }
                    }
                    break;
                case ConsoleKey.A:
                    for (int i = 0; i < characterHeight; i++)
                    {
                        if (terkep[karakter.X + i, ujY] != " ")
                        {
                            return false;
                        }
                    }
                    break;
                case ConsoleKey.D:
                    for (int i = 0; i < characterHeight; i++)
                    {
                        if (terkep[karakter.X + i, ujY + characterWidth - 1] != " ")
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
            for (int i = 0; i < karakter.Kinezet.Length; i++)
            {
                for (int j = 0; j < karakter.Kinezet[i].Length; j++)
                {
                    if (karakter.Kinezet[i][j] != ' ')
                    {
                        palya.GetTerkep()[karakter.X + i, karakter.Y + j] = " ";
                    }
                }
            }

            karakter.X = ujX;
            karakter.Y = ujY;

            // Beállítja a karakter új helyét
            for (int i = 0; i < karakter.Kinezet.Length; i++)
            {
                for (int j = 0; j < karakter.Kinezet[i].Length; j++)
                {
                    if (karakter.Kinezet[i][j] != ' ')
                    {
                        palya.GetTerkep()[karakter.X + i, karakter.Y + j] = karakter.Kinezet[i][j].ToString();
                    }
                }
            }
        }

        private void KarakterElhelyezes()
        {
            for (int i = 0; i < karakter.Kinezet.Length; i++)
            {
                for (int j = 0; j < karakter.Kinezet[i].Length; j++)
                {
                    if (karakter.Kinezet[i][j] != ' ')
                    {
                        palya.GetTerkep()[karakter.X + i, karakter.Y + j] = karakter.Kinezet[i][j].ToString();
                    }
                }
            }
        }

        private void Harc()
        {
            int sarkanyHp = 100;
            int sarkanySebzes = 30;
            display = 1;
            

            while (karakter.Hp > 0 && sarkanyHp > 0)
            {
                Console.Clear();
                string[] lines = File.ReadAllLines("harc1.txt");
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine($"Karakter HP: {new string('█', karakter.Hp / 10)}{new string('▒', 10 - karakter.Hp / 10)} {karakter.Hp}% ❤️ \t\t\t Sárkány HP: {sarkanyHp}% ❤️");
                Console.WriteLine($"Karakter Sebzés: {karakter.Sebzes}\t\t Sárkány Sebzés: {sarkanySebzes}");
                Console.WriteLine("Nyomj meg egy gombot a támadáshoz (T)");

                if (Console.ReadKey(true).Key == ConsoleKey.T)
                {
                    sarkanyHp -= karakter.Sebzes;
                    if (sarkanyHp <= 0)
                    {
                        Win();
                        return;
                    }

                    karakter.Hp -= Math.Max(5, sarkanySebzes - karakter.Armor);
                    if (karakter.Hp <= 0)
                    {
                        Lose();
                        return;
                    }
                }
            }
        }

        private void Win()
        {
            Console.Clear();
            string nyertel = File.ReadAllText("nyertel.txt");
            Console.WriteLine(nyertel);
            Console.WriteLine("\t\t");
            int teljesitesIdeje = (int)(DateTime.Now - startTime).TotalSeconds;
            int pontszam = 1000 - teljesitesIdeje;
            Console.WriteLine($"Pontszámod: {pontszam}");
            gamestate = 6;
        }

        private void Lose()
        {
            Console.Clear();
            string vesztettel = File.ReadAllText("vesztettel.txt");
            Console.WriteLine(vesztettel);
            Console.WriteLine("\t\t");
            int teljesitesIdeje = (int)(DateTime.Now - startTime).TotalSeconds;
            int pontszam = (1000 - teljesitesIdeje) / 2;
            Console.WriteLine($"Vesztettél! Pontszámod: {pontszam}");
            gamestate = 6;
        }

        
    }
}
