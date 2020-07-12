using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{
    class Blok : SonicHelper,ICollide
    {
        public Rectangle CollisionRectangle;
        public Rectangle R;

        public Texture2D _texture { get; set; }
        public Rectangle Positie { get; set; }

        public Blok()
        {

        }

        public Blok(/*Texture2D texture, Vector2 pos*/ Rectangle R)
        {
            Item1 = Content.Load<Texture2D>("blok");
            Positie = R;
            CollisionRectangle = new Rectangle(Positie.X, Positie.Y, 37, 29);
           
        }
        

        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Item1, Positie, Color.White);
        }

        public override void update()
        {
        }

        public Rectangle GetCollisionRectangle()
        {
            return CollisionRectangle;
        }
    }
}
