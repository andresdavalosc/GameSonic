using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{
    class Gepauzeerd
    {
        public static bool gepauzeerd = false;
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Game1.font, "Pauze", new Vector2(Levens.Positie.X + 700, 20), Color.Yellow);
        }
    }
}
