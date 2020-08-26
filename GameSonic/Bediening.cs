using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{
    public abstract class Bediening
    {
        public bool left { get; set; }
        public bool right { get; set; }
        public bool spatie { get; set; }
        public bool pauze { get; set; }
        public bool hervat { get; set; }
        public abstract void Update();
    }

    public class BedieningPijltjes : Bediening
    {
        public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();

            if (stateKey.IsKeyDown(Keys.Left))
            {
                left = true;
            }
            if (stateKey.IsKeyUp(Keys.Left))
            {
                left = false;
            }

            if (stateKey.IsKeyDown(Keys.Right))
            {
                right = true;
            }
            if (stateKey.IsKeyUp(Keys.Right))
            {
                right = false;
            }

            if (stateKey.IsKeyDown(Keys.Space))
            {
                spatie = true;
            }
            if (stateKey.IsKeyUp(Keys.Space))
            {
                spatie = false;
            }
            if (stateKey.IsKeyUp(Keys.A))
            {
                pauze = false;
            }
            if (stateKey.IsKeyDown(Keys.A))
            {
                pauze = true;
            }
            if (stateKey.IsKeyUp(Keys.B))
            {
                hervat = false;
            }
            if (stateKey.IsKeyDown(Keys.B))
            {
                hervat = true;
            }
        }

    }
}
