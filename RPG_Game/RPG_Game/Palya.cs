using System;
using System.IO;

namespace RPG_Game
{
    public class Palya : Jatek
    {
        private string[,] terkep; //egész pálya

        public Palya(int renderx, int rendery) //renderelt terület
        {
            terkep = new string[1000 + renderx * 6, 1000 + rendery * 6]; // 1000x1000 pálya+extra üres helyek, hogy ne tudjon kisétálni a pályáról (nem lenne mit printelni/hozzáadni a streambuilderhez később)
        }

        public void Betolt(string beolvasott) //minden mező feltöltése üres karakterrel
        {
            for (int i = 0; i < terkep.GetLength(0); i++)
            {
                for (int j = 0; j < terkep.GetLength(1); j++)
                {
                    terkep[i, j] = " ";
                }
            }
            string[] lines = File.ReadAllLines(beolvasott);
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    terkep[i + renderx * 3, j + rendery * 3] = lines[i][j].ToString();
                }
            }
        }

        public string[,] GetTerkep()
        {
            return terkep;
        }
    }
}
