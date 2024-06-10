using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace DragonQuest.Levels {

    public class LevelStructure {
        
        private Image image;
        private Bitmap bitmap;

        public int width, height;

        public bool[,] colMap;
        //public List<MapEntity> entityMap = new List<MapEntity>();

        public LevelStructure(string Image) {

            this.image = System.Drawing.Image.FromFile(Image);
            this.width = this.image.Width;
            this.height = this.image.Height;

            colMap = new bool[this.width, this.height];

            Init();

        }

        private void Init() {

            this.bitmap = new Bitmap(this.image);
            for (int y = 0; y < this.height; y++)
                for (int x = 0; x < this.width; x++) {

                    Color pixel = bitmap.GetPixel(x, y);
                    if (pixel.R == 0 && pixel.G == 0 && pixel.B == 0) {

                        colMap[x, y] = true;
                        continue;

                    }

                    colMap[x, y] = false;

                    /*if ((pixel.R != 0 && pixel.R != 255) ||
                        (pixel.G != 0 && pixel.G != 255) ||
                        (pixel.B != 0 && pixel.B != 255)) entityMap.Add(new MapEntity(MapManager.GetEntityByRGB(pixel.R, pixel.G, pixel.B), x, y));*/

                }

        }

    }

}
