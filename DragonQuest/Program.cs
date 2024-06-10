using DragonQuest_Lib.LevelClasses;
Levels levels = new(new StreamReader("Levels.txt")); //Reads the levels file thingie
/* This was a test
foreach (var level in levels.levels)
{
    Console.WriteLine(level.title);
    foreach (var item in level.items.items)
    {
        Console.WriteLine(item.name);
    }
    Console.WriteLine();
}*/

int playerPosX = 1; //I'll make a Player class later
int playerPosY = 1;
int levelID = 3;

initConsole();
printMap(levels.Data(levelID), ConsoleColor.White, ConsoleColor.Black, playerPosX, playerPosY); //This prints the outline and the items of a map

void initConsole() {

    Console.Clear();
    Console.CursorVisible = false;

    for (int x = 0; x < Console.WindowWidth; x++)
        for (int y = 0; y < Console.WindowHeight; y++) RealWriteAt(x, y, ' ', ConsoleColor.Black, null);

}

void RealWriteAt(int x, int y, char c, ConsoleColor? bgc, ConsoleColor? fgc) {

    (int left, int top) = Console.GetCursorPosition();
    ConsoleColor originalBGC = Console.BackgroundColor,
                 originalFGC = Console.ForegroundColor;

    Console.SetCursorPosition(x, y);
    Console.BackgroundColor = bgc == null ? originalBGC : (ConsoleColor) bgc;
    Console.ForegroundColor = fgc == null ? originalFGC : (ConsoleColor) fgc;
    Console.Write(c);
    Console.BackgroundColor = originalBGC;
    Console.ForegroundColor = originalFGC;
    Console.SetCursorPosition(left, top);

}

void WriteAt(int x, int y, ConsoleColor inner, int direction)
{
    //Don't ask, it works
    try
    {
        Console.SetCursorPosition(x, y);
        Console.BackgroundColor = ConsoleColor.Green;
        if(new[] { 1, 3 }.Contains(direction))
        {
            Console.BackgroundColor = ConsoleColor.Black;
            if(direction == 1) Console.SetCursorPosition(x, y + 1);
            if(direction == 3) Console.SetCursorPosition(x, y - 1);
        }
        Console.Write(" ");
        switch (direction)
        {
            case 1:
            case 3:
                Console.SetCursorPosition(x, y);
                Console.BackgroundColor = ConsoleColor.Green;
            break;
            case 2:
                Console.SetCursorPosition(x + 1, y);
                Console.BackgroundColor = ConsoleColor.Black;
            break;
            case 4:
                Console.SetCursorPosition(x - 1, y);
                Console.BackgroundColor = ConsoleColor.Black;
            break;
        }
        Console.Write(" ");
    }
    catch (ArgumentOutOfRangeException e)
    {
        Console.Clear();
        Console.WriteLine(e.Message);
    }
}

//I'll find a smoother solution to this later
while (true)
{

    //pain, so much pain
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.W:
            if (!CollisionCheckFor(levels.Data(3), playerPosX, playerPosY, 1))
            {
                playerPosY--;
                WriteAt(playerPosX, playerPosY, ConsoleColor.Black, 1);
            }
        break;
        case ConsoleKey.A:
            if (!CollisionCheckFor(levels.Data(3), playerPosX, playerPosY, 2))
            {
                playerPosX--;
                WriteAt(playerPosX, playerPosY, ConsoleColor.Black, 2);
            }
        break;
        case ConsoleKey.S:
            if (!CollisionCheckFor(levels.Data(3), playerPosX, playerPosY, 3))
            {
                playerPosY++;
                WriteAt(playerPosX, playerPosY, ConsoleColor.Black, 3);
            }
        break;
        case ConsoleKey.D:
            if (!CollisionCheckFor(levels.Data(3), playerPosX, playerPosY, 4))
            {
                playerPosX++;
                WriteAt(playerPosX, playerPosY, ConsoleColor.Black, 4);
            }
        break;
    }
}

//This does what the name says smh
void printMap(Level l, ConsoleColor border, ConsoleColor inner, int X, int Y)
{
    for (int j = 0; j < l.height; j++)
    {
        for (int i = 0; i < l.width; i++)
        {
            Console.BackgroundColor = new[] { 0, l.width - 1 }.Contains(i) || new[] { 0, l.height - 1 }.Contains(j) ? border : inner;
            if (X == i && Y == j) Console.BackgroundColor = ConsoleColor.Green;
            if (l.items.items.Count(x=> x.x == i+1 && x.y == j+1) == 1) Console.BackgroundColor = ConsoleColor.Red;
            if (l.items.items.Count(x=> x.x == i+1 && x.y == j+1 && x.id == 1) == 1) Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
        }
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine();
    }
}

//Way too overcomplicated
bool CollisionCheckFor(Level l, int X, int Y, int direction)
{

    //1 - Up
    //2 - Left
    //3 - Down
    //4 - Right
    switch (direction)
    {

        case 1:
            if(Y == 1 || l.items.items.Count(x=> x.y == Y && x.x == X + 1) == 1) return true;
        break;
        case 2:
            if(X == 1 || l.items.items.Count(x=> x.y == Y + 1 && x.x == X) == 1) return true;
        break;
        case 3:
            if (Y == l.height - 2 || l.items.items.Count(x => x.y == Y + 2 && x.x == X + 1) == 1) return true;
        break;
        case 4:
            if (X == l.width - 2 || l.items.items.Count(x => x.y == Y + 1 && x.x == X + 2) == 1) return true;
        break;
    }
    return false;
}

//I'm so tired :3