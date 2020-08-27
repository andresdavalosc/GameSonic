using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{
    public class Timer
    {
        public static float T;
        public static string Bericht = "";


        public void Update(GameTime gameTime)
        {
            T += (float)gameTime.ElapsedGameTime.TotalSeconds;
            Bericht = "tijd: " + T.ToString("0");
            CheckTijd.Updater();
        }

        public void Draw(SpriteBatch spriteBatch , SpriteFont _font)
        {
            spriteBatch.DrawString(Game1.font, Bericht ,new Vector2(Levens.Positie.X + 500,20) , Color.White);
        }

       
    }
}
