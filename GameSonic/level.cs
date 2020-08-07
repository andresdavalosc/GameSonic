using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{
    class Level
    {
        public int width, height;

        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }
        


        public Texture2D texture;

        public void CreateWorld(byte[,] level)
        {
            for (int x = 0; x < level.GetLength(0); x++)
            {
                for (int y = 0; y < level.GetLength(1); y++)
                {
                    if (level[x, y] == 1)
                    {
                        Game1._Blok.Add(new Blok(new Rectangle(y * 62, x * 63, 65, 65)));
                        height = (x + 1) * 60;
                        width = -500;
                        
                    }
                    if (level[x,y] == 33)
                    {
                        Game1._Coins.Add(new Coins(new Rectangle(y*62 , x*65  ,35, 37)));
                    }
                    
                }
            }
        }


        public void DrawWorld(SpriteBatch spritebatch)
        {
            foreach (Blok blokje in Game1._Blok)
               blokje.draw(spritebatch);
            foreach (Coins money in Game1._Coins)
               money.draw(spritebatch);            
        }

    }
}
