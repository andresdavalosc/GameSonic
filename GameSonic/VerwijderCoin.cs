using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{
    class VerwijderCoin
    {
        public static void CoinsUpdate(int j)
        {
            Game1.coinseffect.Play();
            Game1._Coins.RemoveAt(j);
        }
    }
}
