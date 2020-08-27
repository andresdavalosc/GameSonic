using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{
    class ControleCoins
    {
        public static void Coinsmax(SpriteBatch spriteBatch)
        {


            if (CheckCollionFlag.level == 3 && CheckCollisionCoins.count >= 1)
            {
                NieuwLevel.Clear();
                Game1.Hart.Clear();
                Sonichero.Positie.X = -400;
                MenuManager.start = false;
                Environment.Exit(0);
            }
            else
            {
                NieuwLevel.Opschonen();
            }
        }
    }
}
