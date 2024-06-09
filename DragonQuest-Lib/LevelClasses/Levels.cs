namespace DragonQuest_Lib.LevelClasses
{
    public class Levels
    {
        public List<Level> levels = [];
        public Levels(StreamReader f) {
            Level level = new();
            
            //This just parses the Levels.txt file into actually usable stuff
            while (!f.EndOfStream)
            {
                string l = f.ReadLine()!;
                if (l != "End")
                {
                    switch (l!.Split("=")[0])
                    {
                        case "levelID":
                            level.id = int.Parse(l.Split("=")[1]);
                        break;
                        case "levelTitle":
                            level.title = string.Join(" ", l.Split("=")[1].Split(";"));
                        break;
                        case "levelWidth":
                            level.width = int.Parse(l.Split("=")[1]);
                        break;
                        case "levelHeight":
                            level.height = int.Parse(l.Split("=")[1]);
                        break;
                        case "items":
                            level.items = new(l.Split("=")[1]);
                        break;
                    }
                } else
                {
                    levels.Add(level);
                    level = new();
                }
            }
        }

        public Level Data(int levelId) => levels.Where(x => x.id == levelId).First(); //Helps retrieve level data
    }
}
