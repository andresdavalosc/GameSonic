using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{
    class CheckCollionFlag
    {
        Level level2;
        World world2 = new World();
        Sonichero _sonic2,hero;
        public static int level=1;
        CheckCollisionCoins coins = new CheckCollisionCoins();
        public bool CheckCollisionflag(Sonichero sonic)
        {
            _sonic2 = sonic;
            level2 = new Level();
            Spawn S = new Spawn();
            CheckCollisionBlock dood = new CheckCollisionBlock();
            for (int i = 0; i < Game1._vlag.Count; i++)
            {
                for (int j = i; j < Game1._vlag.Count; j++)
                {
                    if (Game1.collideObjecten[0].GetCollisionRectangle().Intersects(Game1._vlag[j].GetCollisionRectangle()))
                    {
                        
                        if (CheckCollisionCoins.count >= 10)
                        {
                            Game1._Blok.Clear();
                            Game1._Coins.Clear();
                            level2.CreateWorld(world2.Level2);
                            _sonic2.Positie = S.spawning;
                            level = 2;
                        }

                    }
                }
                return true;
            }
            return false;
        }

        public void update(Sonichero _hero)
        {
            hero = _hero;
            CheckCollisionflag(hero);
        }

    }
}
