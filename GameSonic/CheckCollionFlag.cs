using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{
    class CheckCollionFlag
    {
        public static int level=1;
        CheckCollisionCoins coins = new CheckCollisionCoins();

        public void Update(Sonichero _hero, SpriteBatch spriteBatch)
        {
            CheckCollisionflag(spriteBatch);
        }

        public bool CheckCollisionflag(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Game1._vlag.Count; i++)
            {
                for (int j = i; j < Game1._vlag.Count; j++)
                {
                    if (Game1.CollideObjecten[0].GetCollisionRectangle().Intersects(Game1._vlag[j].GetCollisionRectangle()))
                    {

                        ControleCoins.Coinsmax(spriteBatch);

                    }
                }
                return true;
            }
            return false;
        }

    }
}
