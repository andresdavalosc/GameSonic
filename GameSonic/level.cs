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
        private int width, height;
        //List<ICollide> coin = new List<ICollide>();

        //public List<ICollide> _Coins
        //{
        //    get { return coin; }
        //}

        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }
        
        public Texture2D texture;
        //public byte[,] tileArray = new Byte[,]
        //{
        //    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        //    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        //    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        //    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        //    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        //    {0,0,0,0,33,33,33,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        //    {0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        //    {0,0,0,0,0,0,0,0,0,33,33,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        //    {0,0,0,0,0,0,0,0,1,1,1,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0},
        //    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        //    {0,0,0,0,0,1,1,0,33,0,0,0,0,33,0,0,1,1,0,0,0,0,0,33,33,0,0,0},
        //    {0,33,0,0,0,0,0,1,1,0,0,0,1,1,0,0,0,0,0,0,0,0,0,1,1,1,0,0},
        //    {0,33,33,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,33,33,33,0,0,0,0,0,0,0},
        //    {1,1,1,1,0,0,0,0,0,0,1,1,0,0,0,0,0,0,1,1,1,1,1,1,0,0,1,1},
        //};
        //next level
        // public byte[,] tileArray1 = new Byte[,]
        //{
        //     {0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        //     {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        //     {0,0,0,0,0,0,0,1,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        //     {0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,1,1,1,0,0,1,0,0,1,0,0,0},
        //     {1,1,0,0,0,0,1,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,1},
        //};
        //laaste level
        //public byte[,] tileArray = new Byte[,]
        // {
        //    {0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        //    {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0},
        //    {0,0,0,0,0,1,0,0,0,0,0,0,1,1,0,0,0,1,0,0,1,0,0,0,0,0,0,1},
        //    {0,0,0,1,0,0,0,0,0,1,1,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0},
        //    {1,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0},
        // };

        //private Blok[,] blokArray;//= new Blok[14, 28];

        public void CreateWorld(byte[,] level)
        {
           // blokArray = new Blok[14, 28];
            for (int x = 0; x < level.GetLength(0); x++)
            {
                for (int y = 0; y < level.GetLength(1); y++)
                {
                    if (level[x, y] == 1)
                    {
                        //blokArray[x, y] = new Blok(texture, new Vector2(y * 60,  x*63));
                        Game1._Blok.Add(new Blok(new Rectangle(y * 62, x * 63, 65, 65)));
                        //b = blokArray[x, y];
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

        //public void CreateWorld2()
        //{
        //    for (int x = 0; x < 5; x++)
        //    {
        //        for (int y = 0; y < 28; y++)
        //        {
        //            if (tileArray1[x, y] == 1)
        //            {
        //                blokArray[x, y] = new Blok(texture, new Vector2(y * 60, x * 105));
        //                b = blokArray[x, y];
        //                height = (x + 1) * 60;
        //                width = (x + 1) * 105;
        //                Game1.collideObjecten.Add(b);
        //            }
        //        }
        //    }
        //}

        public void DrawWorld(SpriteBatch spritebatch)
        {
            //for (int x = 0; x < 14; x++)
            //{
            //    for (int y = 0; y < 28; y++)
            //    {
            //        if (blokArray[x, y] != null)
            //        {
            //            blokArray[x, y].draw(spritebatch);
                        foreach (Blok blokje in Game1._Blok)
                            blokje.draw(spritebatch);
                        foreach (Coins money in Game1._Coins)
                            money.draw(spritebatch);
            //        }
            //    }
            //}
            

        }

    }
}
