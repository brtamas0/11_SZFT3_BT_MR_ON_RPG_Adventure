using System.Text;

int renderx = 75; 
int rendery = 25;

int x = 250;
int y = 100;

string[,] map1 = new string[1000+renderx, 1000+rendery];
Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
Console.CursorVisible = false;
Console.Title = "RPG Game";
Console.OutputEncoding = Encoding.UTF8;
Console.ReadKey();
