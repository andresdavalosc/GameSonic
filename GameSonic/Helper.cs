using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{
    abstract class Helper
    {
        public static ContentManager Content;
        public Texture2D Item1;


        public abstract void Update();

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
