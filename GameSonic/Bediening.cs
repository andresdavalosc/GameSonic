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
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Spatie { get; set; }
        public bool Pauze { get; set; }
        public bool Hervat { get; set; }
        public abstract void Update();
    }

    public class BedieningPijltjes : Bediening
    {
        public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();

            if (stateKey.IsKeyDown(Keys.Left))
            {
                Left = true;
            }
            if (stateKey.IsKeyUp(Keys.Left))
            {
                Left = false;
            }

            if (stateKey.IsKeyDown(Keys.Right))
            {
                Right = true;
            }
            if (stateKey.IsKeyUp(Keys.Right))
            {
                Right = false;
            }

            if (stateKey.IsKeyDown(Keys.Space))
            {
                Spatie = true;
            }
            if (stateKey.IsKeyUp(Keys.Space))
            {
                Spatie = false;
            }
            if (stateKey.IsKeyUp(Keys.A))
            {
                Pauze = false;
            }
            if (stateKey.IsKeyDown(Keys.A))
            {
                Pauze = true;
            }
            if (stateKey.IsKeyUp(Keys.B))
            {
                Hervat = false;
            }
            if (stateKey.IsKeyDown(Keys.B))
            {
                Hervat = true;
            }
        }

    }
}
