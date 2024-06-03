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
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    terkep[i + 30 * 3, j + 30 * 3] = lines[i][j].ToString();
                }
            }
        }

        public string[,] GetTerkep()
        {
            return terkep;
        }
    }
}