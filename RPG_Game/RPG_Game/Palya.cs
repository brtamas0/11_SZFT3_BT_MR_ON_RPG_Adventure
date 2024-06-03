using System;
using System.IO;

namespace RPG_Game
{
    public class Palya
    {
        private string[,] terkep;

        public Palya(int renderx, int rendery)
        {
            terkep = new string[1000 + renderx * 6, 1000 + rendery * 6];
        }

        public void Betolt(string fileName)
        {
            for (int i = 0; i < terkep.GetLength(0); i++)
            {
                for (int j = 0; j < terkep.GetLength(1); j++)
                {
                    terkep[i, j] = " ";
                }
            }
            string[] lines = File.ReadAllLines(fileName);
            int linesLength = Math.Min(lines.Length, 1000);
            for (int i = 0; i < linesLength; i++)
            {
                int stringLength = Math.Min(lines[i].Length, 1000);
                for (int j = 0; j < stringLength; j++)
                {
                    terkep[i + 20 * 3, j + 20 * 3] = lines[i][j].ToString();
                }
            }
        }

        public string[,] GetTerkep()
        {
            return terkep;
        }
    }
}