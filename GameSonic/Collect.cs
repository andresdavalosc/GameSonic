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
        public Vector2 Position;
        public Rectangle ShowSprite;


        public abstract void update(GameTime gametime);

        public abstract void draw(SpriteBatch spriteBatch);

    }
}
