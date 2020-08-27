using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{
    class VerwijderHart
    {
        static int count = 0;
        public static int i__;

        public static void UpdateHart(int _i)
        {
            i__ = _i;
            if (Sonichero.Positie.Y > 950)
            {

                Game1._sound.Play();
                Sonichero.Positie = Spawn.spawning;

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

        public static void Levensaftrekker()
        {
            count = Game1.Hart.Count;
            if (count > 1)
            {
                Game1.Hart.RemoveAt(count - 1);
                Timer.T = 0;
                Game1._sound.Play();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
