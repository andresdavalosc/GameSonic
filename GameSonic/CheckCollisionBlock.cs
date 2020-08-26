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
        Sonichero _sonic2,H;
        Spawn S = new Spawn();
        SoundEffect _Sound;
        Levens L;
        public int i__;


        public bool CheckCollision(Sonichero hero)
        {
            _sonic2=hero;

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
                            _sonic2.springen = false;
                        return true;
                    }
                }

                berekening(i);
            }
            _sonic2.springen = true;
            return false;
        }

        public void update(GameTime gameTime , Sonichero _son, SoundEffect sound)
        {
            H = _son;
            CheckCollision(H);
            _Sound = sound;
        }

        public void berekening(int _i)
        {
            i__ = _i;
            if (Sonichero.Positie.Y > 950)
            {
                
                _Sound.Play();
                Sonichero.Positie = S.spawning;
                
                if (Game1.Hart != null)
                {
                    i__++;
                    if (i__ < Game1.Hart.Count)
                    {
                        Game1.Hart.RemoveAt(i__ - 1);
                    }
                    else
                        Environment.Exit(0);
                }
            }
        }
    }

}
