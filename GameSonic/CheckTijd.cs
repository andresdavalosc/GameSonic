using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{
    class CheckTijd
    {
        static bool flag = false;
        static bool flag2 = false;

        public static void Updater()
        {
            if (CheckCollionFlag.level == 1)
            {
                if (Timer.T > 15 && CheckCollisionCoins.count < 10)
                {
                    VerwijderHart.Levensaftrekker();
                }
                else if (CheckCollisionCoins.count >= 10)
                {
                    Timer.Bericht = "Goed Bezig Je hebt meer dan 10 Coins !!";
                    flag = true;
                }
            }
            if (CheckCollionFlag.level == 2)
            {
                if (CheckCollisionCoins.count >= 10 && flag == true)
                {
                    CheckCollisionCoins.count = 0;
                    Timer.T = 0;
                    flag = false;
                }
                if (Timer.T >= 15 && CheckCollisionCoins.count < 15)
                {
                    VerwijderHart.Levensaftrekker();
                }
                else if (CheckCollisionCoins.count >= 15)
                {
                    Timer.Bericht = "Goed Bezig Je hebt meer dan 15 Coins !!";
                    flag2 = true;
                }
            }
            if (CheckCollionFlag.level == 3)
            {
                if (CheckCollisionCoins.count >= 10 && flag2 == true)
                {
                    CheckCollisionCoins.count = 0;
                    Timer.T = 0;
                    flag2 = false;
                }
                if (Timer.T >= 10 && CheckCollisionCoins.count < 1)
                {
                    VerwijderHart.Levensaftrekker();
                }
                else if (CheckCollisionCoins.count >= 1)
                {
                    Timer.Bericht = "Goed Bezig Je hebt de Enige coin !!";
                }

            }
        }
    }
}
