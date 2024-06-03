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
                    HarcKijelzes();
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
            Console.WriteLine($"{$"{new string('█', karakter.Hp / 10)}{new string('▒', 10 - karakter.Hp / 10)}"} {karakter.Hp}% ❤️ \n{karakter.Sebzes} 🗡️ \n{karakter.Armor} 🛡️\nX: {karakter.y} \nY: {karakter.x}");
            Console.WriteLine($"Arany: {karakter.Gold} 💰");
            Console.WriteLine("[1] Kard (50 arany)   [2] Íj (25 arany)   [3] Pajzs (20 arany)");
            Console.WriteLine("Küldetés: ");
        }

        private void HarcKijelzes()
        {
            Console.Clear();
            Console.WriteLine("Harc");
        }
    }
}
