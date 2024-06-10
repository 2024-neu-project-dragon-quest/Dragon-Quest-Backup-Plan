using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuest.Levels {

    public class LevelManager {
        
        static public List<Level> levels = new List<Level>();

        public static void Init() {

            /*
            
                it should read in all of the levels with ".lvl" ("extention") in their name in ./Assets/Levels

                it should create a new instance of a Level where we parse the full path (could also be relative) into the constructor of Level.cs

                it will make sense, just look at it

            */

            string[] ls = Directory.GetFiles("./Assets/Levels", "*.lvl");
            foreach (string l in ls) levels.Add(new Level(l));

        }

        public static Level? GetLevel(int id) {

            foreach (Level l in levels) if (l.ID == id) return l;
            return null; // make it so that it gets the level by its ID and returns it 

        }

    }

}