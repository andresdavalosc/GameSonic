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
        public static ContentManager Content;
        public SoundEffect _coinseffect,_effect;
        SpriteFont _font;
        Levens L;
        int x;
        public static int count;
        public int Coinscount;

        public bool CheckCollisioncoin(SoundEffect coinseffect)
        {

            _coinseffect = coinseffect;

            for (int i = 0; i < Game1._Coins.Count; i++)
            {
                for (int j = i; j < Game1._Coins.Count; j++)
                {
                    if (Game1.collideObjecten[0].GetCollisionRectangle().Intersects(Game1._Coins[j].GetCollisionRectangle()))
                    {
                        _coinseffect.Play();
                        Game1._Coins.RemoveAt(j);
                        System.Console.WriteLine("Collision coin");
                        count++;
                    }
                    x = 1 + Game1._Coins.Count;
                }
                return true;
            }
            return false;
        }

        public  void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            _font = font;
            //L = hart;
            
           spriteBatch.DrawString(_font, "coins: " + count, new Vector2(Levens.Positie.X + 50, 0), Color.Yellow);
        }

        public  void update(GameTime gametime, SoundEffect effect)
        {
            _effect = effect;
            CheckCollisioncoin(_effect);
        }
    }
}
