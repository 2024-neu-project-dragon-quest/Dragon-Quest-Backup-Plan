using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonQuest.Misc;

namespace DragonQuest.Entities {

    public class Entity : ConfigMarkup {
        
        public int ID;
        public string name;

        public char c;
        public ConsoleColor bgc, fgc;

        public Entity(string path) : base(path) {

            /*
            
                initialize those variables up there

            
            */

        }

        public Entity(char c, ConsoleColor bgc, ConsoleColor fgc) : base(null) {

            this.ID = -1;
            this.name = "none";

            this.c = c;
            this.bgc = bgc;
            this.fgc = fgc;

        }

    }

}