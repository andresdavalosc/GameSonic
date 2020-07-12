﻿using Microsoft.Xna.Framework;
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
    abstract class SonicHelper
    {
        public static ContentManager Content;
        public Texture2D Item1;
        public Vector2 Position;
        public Rectangle ShowSprite;


        public abstract void update();

        public abstract void draw(SpriteBatch spriteBatch);
    }
}
