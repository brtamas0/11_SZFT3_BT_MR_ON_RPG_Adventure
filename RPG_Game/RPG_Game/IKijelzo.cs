using System;

namespace RPG_Game
{
    public interface IKijelzo
    {
        void Megjelenit(int display, IKarakter karakter, IPalya palya, int renderx, int rendery);
    }
}
