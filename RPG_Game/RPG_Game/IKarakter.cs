namespace RPG_Game
{
    public interface IKarakter
    {
        int X { get; set; }
        int Y { get; set; }
        string Nev { get; set; }
        int Sebzes { get; set; }
        int Armor { get; set; }
        int Xp { get; set; }
        int Level { get; set; }
        int Hp { get; set; }
        int MaxHp { get; set; }
        int Gold { get; set; }
        string[] Inventory { get; set; }
        string[] Kinezet { get; }
    }
}
