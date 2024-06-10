using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonQuest.Levels;

namespace DragonQuest.Entities {

    public class Player : EntityInstance {
        
        public Player(int posX, int posY, Level level) : base(posX, posY, level, new Entity('X', ConsoleColor.Green, ConsoleColor.Black)) {



        }

        /*
        
            some functions are missing from here, think this through zraphy
        
        */

    }

}