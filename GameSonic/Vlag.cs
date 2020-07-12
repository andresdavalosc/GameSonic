using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{
    class Vlag : ICollide
    {
        private Texture2D _flag;
        public Vector2 Positie;
        private Rectangle _ShowRect;
        public Rectangle CollisionRectangle;

        public Bediening _bediening { get; set; }


        public Vlag(Texture2D _texture, Vector2 _positie)
        {
            _flag = _texture;
            Positie = _positie;
            _ShowRect = new Rectangle(0, 0, 37, 35);
            CollisionRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, 37, 29);

        }


        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_flag, Positie, _ShowRect, Color.Red);
        }

        public Rectangle GetCollisionRectangle()
        {
            return CollisionRectangle;
        }
    }
}
