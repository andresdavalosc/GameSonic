using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{
    abstract class Collect
    {
        public static ContentManager Content;
        public Texture2D Item;
        public Rectangle ShowSprite;

        public abstract void Update(GameTime gametime);

        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
