﻿namespace RPG_Game
{
    public class Karakter : IKarakter
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Nev { get; set; }
        public int Sebzes { get; set; }
        public int Armor { get; set; }
        public int Xp { get; set; }
        public int Level { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Gold { get; set; }
        public string[] Inventory { get; set; }

        public string[] Kinezet { get; private set; } = {
            "   .-.   ",
            " __|=|__ ",
            "(_/`-`\\_)",
            "//\\___/\\\\",
            "<>/   \\<>",
            " \\|_._|/ ",
            "  <_I_>  ",
            "   |||   ",
            "  /_|_\\  "
        };

        public Karakter(int x, int y, string nev, int sebzes, int armor, int xp, int level, int hp, int gold, string[] inventory)
        {
            this.X = x;
            this.Y = y;
            this.Nev = nev;
            this.Sebzes = sebzes;
            this.Armor = armor;
            this.Xp = xp;
            this.Level = level;
            this.Hp = hp;
            this.MaxHp = hp;
            this.Gold = gold;
            this.Inventory = inventory;
        }
    }
}
