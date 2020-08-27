using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameSonic
{
    class CheckCollisionCoins
    {
        public static int count;
        public bool CheckCollisioncoin( )
        {


            for (int i = 0; i < Game1._Coins.Count; i++)
            {
                for (int j = i; j < Game1._Coins.Count; j++)
                {
                    if (Game1.collideObjecten[0].GetCollisionRectangle().Intersects(Game1._Coins[j].GetCollisionRectangle()))
                    {
                        VerwijderCoin.CoinsUpdate(j);
                        count++;

                    }
                }
                return true;
            }
            return false;
        }

        public  void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            
           spriteBatch.DrawString(Game1.font, "coins: " + count, new Vector2(Levens.Positie.X + 50, 0), Color.Yellow);
        }

        public  void Update(GameTime gametime)
        {        
            CheckCollisioncoin();
        }

        
    }
}
