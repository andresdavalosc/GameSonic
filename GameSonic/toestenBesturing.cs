using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{
    class ToestenBesturing
    {
        static bool flag = false;

        public static void ToetsenBediening(Bediening _bediening)
        {
            if (_bediening != null)
            {
                _bediening.Update();

                if (_bediening.Pauze)
                {
                   Gepauzeerd.gepauzeerd = !Gepauzeerd.gepauzeerd;
                   flag = true;
                }

                if (_bediening.Hervat)
                {
                    Gepauzeerd.gepauzeerd = false;
                    flag = false;
                }

                if (!flag)
                {
                    if (_bediening.Left)
                    {
                        Sonichero._ShowRectangle.X -= 84;
                        Sonichero.Positie -= Sonichero.VelocityX;
                        if (Sonichero._ShowRectangle.X < 0)
                            Sonichero._ShowRectangle.X = 672;

                    }
                    if (_bediening.Right)
                    {
                        Sonichero._ShowRectangle.X += 84;
                        Sonichero.Positie += Sonichero.VelocityX;
                        if (Sonichero._ShowRectangle.X > 1668)
                            Sonichero._ShowRectangle.X = 840;
                    }

                    if (_bediening.Spatie && Sonichero.springen == false)
                    {
                        Sonichero.Positie.Y -= 80;
                        Sonichero.Velocity.Y = -9f;
                        Sonichero.springen = true;
                    }

                    if (Sonichero.springen == true)
                    {
                        float i = 2;
                        Sonichero.Velocity.Y += 0.15f * i;
                    }

                    if (Sonichero.springen == false)
                    {
                        Sonichero.Velocity.Y = 0f;
                    }

                    if (!_bediening.Right && !_bediening.Left && !_bediening.Spatie)
                    {
                        Sonichero._ShowRectangle.X = 840;

                    }
                    Sonichero.CollisionRectangle.X = (int)Sonichero.Positie.X;
                    Sonichero.CollisionRectangle.Y = (int)Sonichero.Positie.Y;
                }


                
            }

        }
    }
}
