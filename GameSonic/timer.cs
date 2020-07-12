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
        float T;
        SpriteFont font;
        SoundEffect _Sound;
        public Levens L;
        private Rectangle _ShowRect;
        SpriteFont _font;
        int count = 0;
        CheckCollisionBlock aantalleven = new CheckCollisionBlock();
        CheckCollisionCoins check = new CheckCollisionCoins();
        String Bericht ="";
        Level level1 = new Level();
        //Game1 g = new Game1();
        World w = new World();


        public void Update(GameTime gameTime ,SoundEffect sound)
        {
            T += (float)gameTime.ElapsedGameTime.TotalSeconds;
            Bericht = "tijd: " + T.ToString("0");
            Console.WriteLine(check.Coinscount);
            if( CheckCollionFlag.level == 1)
            {
                if (T >= 10 && CheckCollisionCoins.count < 10)
                {
                    count = aantalleven.i__;
                    if (count < 3 || Game1.Hart != null)
                    {
                        Game1.Hart.RemoveAt(count + 1);
                        T = 0;
                        _Sound = sound;
                        _Sound.Play();
                    }
                    else if (count >= 2)
                    {
                        Environment.Exit(0);
                    }
                }
                else if (CheckCollisionCoins.count >= 10)
                {
                    Bericht = "Goed Bezig Je hebt meer dan 10 Coins !!";
                }
            }
            if (CheckCollionFlag.level == 2)
            {
                CheckCollisionCoins.count = 0;
                if (T >= 10 && CheckCollisionCoins.count < 20)
                {
                    count = aantalleven.i__;
                    if (count < 3 || Game1.Hart != null)
                    {
                        Game1.Hart.RemoveAt(count + 1);
                        T = 0;
                        _Sound = sound;
                        _Sound.Play();
                    }
                    else if (count >= 2)
                    {
                        Environment.Exit(0);
                    }
                }
                else if (CheckCollisionCoins.count >= 20)
                {
                    Bericht = "Goed Bezig Je hebt meer dan 20 Coins !!";
                }
            }


        }

        public void Draw(SpriteBatch spriteBatch , SpriteFont _font, Levens hart)
        {
            font = _font;
            L = hart;

            spriteBatch.DrawString(font, Bericht ,new Vector2(L.Positie.X + 500,20) , Color.White);
        }
    }
}
