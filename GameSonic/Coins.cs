using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{
    class Coins : Collect, ICollide
    {

        private Texture2D _Coin;
        public Vector2 Positie { get; set; }
        public Rectangle _ShowRect { get; set; }
        public Rectangle CollisionRectangle;
        public Vector2 VelocityX = new Vector2(0, 0);

        public Coins(Rectangle newRectangle)
        {
            Item = Content.Load<Texture2D>("coin");
            _ShowRect = newRectangle;
            ShowSprite = new Rectangle(0, 0, 35,37);
            CollisionRectangle = new Rectangle(_ShowRect.X,_ShowRect.Y, ShowSprite.Width, ShowSprite.Height);

        }



        public override void update(GameTime gameTime)
        {
            ShowSprite.X += 37;
          
            if (ShowSprite.X >900)
                ShowSprite.X = 0;

        }

        public override void draw(SpriteBatch spriteBatch)
        {
                spriteBatch.Draw(Item, _ShowRect, ShowSprite, Color.AliceBlue);
        }
        public Rectangle GetCollisionRectangle()
        {
            return CollisionRectangle;
        }

    }
}
