using System.Text;

int renderx = 60; 
int rendery = 30;
int x = 10+renderx*3;
int y = 10+rendery*3;
int display = 0; // 0 = game 1 = menü 2 = map, 3 = inventory, 4 = shop, 5 = harc, 6 = beállítások
Player karakter = new Player(x, y, "Játékos", 10, 5, 0, 1, 100, 0, new string[10]);
//                           x  y   nev     sebzes armor xp level hp maxhp gold inventory

string[,] map1 = new string[1000+renderx*6, 1000+rendery*6];
Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
Console.CursorVisible = false;
Console.Title = "RPG Game";
Console.OutputEncoding = Encoding.UTF8;
Console.ReadKey();



void mapload()
{
    for (int i = 0; i < 1000+renderx*4; i++)
    {
        for (int j = 0; j < 1000+rendery*4; j++)
        {
            map1[i, j] = " ";
        }
    }
    string[] lines = System.IO.File.ReadAllLines(@"map.txt");
    for (int i = 0; i < 1000; i++)
    {
        for (int j = 0; j < 1000; j++)
        {
            map1[i+renderx*3, j+rendery*3] = lines[i][j].ToString();

        }
    }
}

map1[x, y] = "X";

void renderMap()
{
    string map = "";
    for (int i = x - rendery; i < x + rendery; i++)
    {
        for (int j = y - renderx; j < y + renderx; j++)
        {
            map += map1[i, j];
        }
        map += "\n";
    }
    
    Console.WriteLine(map);
    Console.WriteLine($"{$"{new String('█', karakter.hp/10)}{new String('▒', 10-karakter.hp/10)}"} {karakter.hp}% ❤️ \n{karakter.sebzes} 🗡️ \n{karakter.armor} 🛡️\nX: {karakter.y - rendery * 3 - 1} Y: {karakter.x-renderx*3-1}");
}


void mozgas()
{
    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.W)
    {
        if (map1[x-1, y] == " ")
        {
            map1[x, y] = " ";
            x--;
            map1[x, y] = "X";
        }
    }
    if (key.Key == ConsoleKey.S)
    {
        if (map1[x+1, y] == " ")
        {
            map1[x, y] = " ";
            x++;
            map1[x, y] = "X";
        }
    }
    if (key.Key == ConsoleKey.A)
    {
        if (map1[x, y-1] == " ")
        {
            map1[x, y] = " ";
            y--;
            map1[x, y] = "X";
        }
    }
    if (key.Key == ConsoleKey.D)
    {
        if (map1[x, y+1] == " ")
        {
            map1[x, y] = " ";
            y++;
            map1[x, y] = "X";
        }
    }
    
}

void menugombok()
{

    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.M)
    {
        if (display == 0)
        {
            display = 2;
        }
        else if (display == 2)
        {
            display = 0;
        }
    }
    if (key.Key == ConsoleKey.E)
    {
        if (display == 0)
        {
            display = 3;
        }
        else if (display == 3)
        {
            display = 0;
        }
    }
    if (key.Key == ConsoleKey.G)
    {
        if (display == 0)
        {
            display = 4;
        }
        else if (display == 4)
        {
            display = 0;
        }
    }
    
    if (key.Key == ConsoleKey.Escape)
    {
        if (display == 0)
        {
            display = 6;
        }
        else if (display == 6)
        {
            display = 0;
        }
    }
}
void menu()
{
    Console.Clear();
    Console.WriteLine("Menü");
}
void map()
{
    Console.Clear();
    Console.WriteLine("Map");
}
void inventory()
{
    Console.Clear();
    Console.WriteLine("Inventory");
}
void shop()
{
    Console.Clear();
    Console.WriteLine("Shop");
}
void harc()
{
    Console.Clear();
    Console.WriteLine("Harc");
}
void beallitasok()
{
    Console.Clear();
    Console.WriteLine("Beállítások");
}

void displayed()
{
    if (display == 0)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        renderMap();
        Console.ForegroundColor = ConsoleColor.Black;
        mozgas();
        Console.ForegroundColor = ConsoleColor.White;
    }
    if (display == 1)
    {
        Console.Clear();
        Console.WriteLine("Menü");
    }
    if (display == 2)
    {
        Console.Clear();
        Console.WriteLine("Map");
    }
    if (display == 3)
    {
        Console.Clear();
        Console.WriteLine("Inventory");
    }
    if (display == 4)
    {
        Console.Clear();
        Console.WriteLine("Shop");
    }
    if (display == 5)
    {
        Console.Clear();
        Console.WriteLine("Harc");
    }
    if (display == 6)
    {
        Console.Clear();
        Console.WriteLine("Beállítások");
    }


}

mapload();
while (true)
{
    displayed();
    menugombok();
    Thread.Sleep(1);
}




record Player(int x, int y, string nev, int sebzes, int armor, int xp, int level, int hp, int gold, string[] inventory);