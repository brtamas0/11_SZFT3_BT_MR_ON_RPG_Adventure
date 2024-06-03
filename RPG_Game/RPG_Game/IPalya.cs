using System;

namespace RPG_Game
{
    public interface IPalya
    {
        void Betolt(string fileName);
        string[,] GetTerkep();
    }
}
