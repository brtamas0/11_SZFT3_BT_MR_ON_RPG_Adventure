using System;
using System.Threading;
using System.Text;

namespace RPG_Game
{
    public class Jatek
    {
        private int renderx = 60;
        private int rendery = 30;
        private int display = 0; // 0 = game 1 = menü 2 = map, 3 = inventory, 4 = shop, 5 = harc, 6 = beállítások
        private Karakter karakter;
        private Palya palya;
        private Kijelzo kijelzo;

        public Jatek()
        {
            int x = 10 + renderx * 3;
            int y = 10 + rendery * 3;
            karakter = new Karakter(x, y, "Játékos", 10, 5, 0, 1, 70, 0, new string[10]);
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
            KarakterElhelyezes();

            while (true)
            {
                kijelzo.Megjelenit(display, karakter, palya, renderx, rendery);
                Kezeles();
                Thread.Sleep(1);
            }
        }

        private void Kezeles()
        {
            if (display == 0)
            {
                Mozgas();
            }
            Kijelzo.MenuGombok(ref display);
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
            }
        }

        private bool EllenorizMozgas(int ujX, int ujY, ConsoleKey key)
        {
            int characterHeight = karakter.AsciiArt.Length;
            int characterWidth = karakter.AsciiArt[0].Length;
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
            for (int i = 0; i < karakter.AsciiArt.Length; i++)
            {
                for (int j = 0; j < karakter.AsciiArt[i].Length; j++)
                {
                    if (karakter.AsciiArt[i][j] != ' ')
                    {
                        palya.GetTerkep()[karakter.x + i, karakter.y + j] = " ";
                    }
                }
            }

            karakter.x = ujX;
            karakter.y = ujY;

            // Beállítja a karakter új helyét
            for (int i = 0; i < karakter.AsciiArt.Length; i++)
            {
                for (int j = 0; j < karakter.AsciiArt[i].Length; j++)
                {
                    if (karakter.AsciiArt[i][j] != ' ')
                    {
                        palya.GetTerkep()[karakter.x + i, karakter.y + j] = karakter.AsciiArt[i][j].ToString();
                    }
                }
            }
        }

        private void KarakterElhelyezes()
        {
            for (int i = 0; i < karakter.AsciiArt.Length; i++)
            {
                for (int j = 0; j < karakter.AsciiArt[i].Length; j++)
                {
                    if (karakter.AsciiArt[i][j] != ' ')
                    {
                        palya.GetTerkep()[karakter.x + i, karakter.y + j] = karakter.AsciiArt[i][j].ToString();
                    }
                }
            }
        }
    }
}