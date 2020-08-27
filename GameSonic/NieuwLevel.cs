using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{
    class NieuwLevel
    {
        public static void Opschonen()
        {
            if (CheckCollionFlag.level == 1 && CheckCollisionCoins.count >= 10)
            {
                Clear();
                World.Worlds(2);
                CheckCollionFlag.level = 2;
            }
            else if (CheckCollionFlag.level == 2 && CheckCollisionCoins.count >= 15)
            {
                Clear();
                World.Worlds(3);
                CheckCollionFlag.level = 3;
            }
        }

        public static void Clear()
        {
            Game1._Blok.Clear();
            Game1._Coins.Clear();
            Sonichero.Positie = Spawn.spawning;
        }
    }
}
