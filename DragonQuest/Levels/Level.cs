using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using DragonQuest.Game;
using DragonQuest.Misc;
using DragonQuest.Items;
using System.Runtime.CompilerServices;
using DragonQuest.Entities;

namespace DragonQuest.Levels {

    public class Level : ConfigMarkup {
        
        public int ID;
        public string name;
        public LevelStructure structure;

        public List<Item> items = new List<Item>();
        public List<EntityInstance> entities = new List<EntityInstance>();

        public bool freeze = false;

        public Level(string path) : base(path) {

            this.ID = int.Parse(this.values["ID"]);
            this.name = this.values["LevelName"];
            
            this.structure = new LevelStructure("./Assets/Levels/" + this.values["LevelStructure"]);

            // initialize canvasBuffer here...

        }

        /*
        
            This class acts as the MapInstance.cs one simultaneously.
        
        */

        public void DrawLevel() {

            for (int x = 0; x < structure.width; x++)
                for (int y = 0; y < structure.height; y++)
                    Canvas.WriteAt(x, y, ' ', structure.colMap[x, y] ? ConsoleColor.White : ConsoleColor.Black, null);

        }

        public void Tick() {

            if (freeze) return;

            DrawLevel();
            foreach (EntityInstance e in entities) e.Draw();

        }

    }

}