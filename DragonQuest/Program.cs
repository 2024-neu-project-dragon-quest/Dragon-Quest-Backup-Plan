using DragonQuest_Lib.LevelClasses;
Levels levels = new(new StreamReader("Levels.txt"));

foreach (var level in levels.levels)
{
    Console.WriteLine(level.title);
    foreach (var item in level.items.items)
    {
        Console.WriteLine(item.name);
    }
    Console.WriteLine();
}