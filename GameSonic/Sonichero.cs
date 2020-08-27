using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{

    public class Sonichero : ICollide
    {

        private Texture2D _hero1;
        public static bool springen;
        public static Vector2 Positie;
        public Rectangle _ShowRect;
        public static Rectangle CollisionRectangle;
        public static Vector2 VelocityX = new Vector2(5, 0);
        public static Vector2 Velocity;
        public Bediening _bediening { get; set; }


        public Sonichero(Texture2D _texture, Vector2 _positie)
        {
            _hero1 = _texture;
            Positie = _positie;
            _ShowRect = new Rectangle(0, 0, 86, 100);
            CollisionRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, 86, 100);
            springen = true;
        }

        public void LoadContent()
        {
        }

        public void UnloadContent()
        {
        }

        public void Update(GameTime gametime)
        {
            Positie += Velocity;
            ToestenBesturing.ToetsenBediening(_bediening);
        }
        public static Rectangle _ShowRectangle = new Rectangle(840, 0, 84, 93);

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_hero1, Positie, _ShowRectangle, Color.AliceBlue);
        }

        public Rectangle GetCollisionRectangle()
        {
            return CollisionRectangle;
        }
        
    }
}
   
