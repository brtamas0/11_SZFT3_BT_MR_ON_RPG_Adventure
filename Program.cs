using System.Text;

int renderx = 75; 
int rendery = 25;

int x = 250;
int y = 100;

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
    Console.WriteLine("X: " + (y-rendery*3-1) + " Y: " + (x-renderx*3+2));
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

mapload();
while (true)
{
    Console.Clear();
    renderMap();
    mozgas();
    Thread.Sleep(1);
}