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
    class Blok : Helper,ICollide
    {
        public Rectangle CollisionRectangle;
        public Rectangle Positie { get; set; }

        public Blok( Rectangle R)
        {
            Item1 = Content.Load<Texture2D>("blok");
            Positie = R;
            CollisionRectangle = new Rectangle(Positie.X, Positie.Y, 37, 29);
           
        }
        

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Item1, Positie, Color.White);
        }

        public override void Update()
        {
        }

        public Rectangle GetCollisionRectangle()
        {
            return CollisionRectangle;
        }
    }
}
