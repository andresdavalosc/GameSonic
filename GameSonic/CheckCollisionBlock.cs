using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{
    
    class CheckCollisionBlock
    {

        public bool CheckCollision()
        {

            for (int i = 0; i < Game1._Blok.Count; i++)
            {
                for (int j = i + 1; j < Game1._Blok.Count; j++)
                {

                    if (Game1.collideObjecten[0].GetCollisionRectangle().Intersects(Game1._Blok[i].GetCollisionRectangle()))
                    {
                        if (Game1._Blok[j].GetCollisionRectangle().Top > Game1._Blok[j].GetCollisionRectangle().Bottom && Game1._Blok[j].GetCollisionRectangle().Left < Game1._Blok[j].GetCollisionRectangle().Right)
                        {
                            Sonichero.Positie.X = 0;
                        }
                            Sonichero.springen = false;
                        return true;
                    }
                }

                VerwijderHart.UpdateHart(i);
            }
            Sonichero.springen = true;
            return false;
        }

        public void Update(GameTime gameTime)
        {
            CheckCollision();
        }

        
    }

}
