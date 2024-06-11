using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using DragonQuest.Entities;
using DragonQuest.Levels;
using DragonQuest.Misc;

namespace DragonQuest.Entities {

    public class EntityInstance {

        private int posX, posY;
        private Entity entity;

        private Level level;

        public EntityInstance(int posX, int posY, Level level, Entity entity) {

            this.posX = posX;
            this.posY = posY;
            
            this.entity = entity;

            this.level = level;
            this.level.entities.Add(this);

        }

        private bool IsObstacle(int x, int y) => this.level.structure.colMap[x, y];

        public void AbsoluteMove(int x, int y) {

            if (IsObstacle(x, y)) return;
            this.posX = x;
            this.posY = y;

        }

        public void RelativeMove(int dX, int dY) {

            if (IsObstacle(this.posX + dX, this.posY + dY)) return;
            this.posX += dX;
            this.posY += dY;

        }

        public void Draw() => Canvas.WriteAt(this.posX, this.posY, this.entity.c, this.entity.bgc, this.entity.fgc);

        public void Kill() => this.level.entities.Remove(this);

    }

}