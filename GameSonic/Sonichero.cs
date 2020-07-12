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

        ContentManager Content;
        private Texture2D _hero1;
        public  bool springen;
        public Vector2 Positie;
        public Rectangle _ShowRect;
        public Rectangle CollisionRectangle;
        public Game1 g = new Game1();
        public Vector2 VelocityX = new Vector2(5, 0);
        public Vector2 Velocity;
        public SoundEffect effect;
        public Bediening _bediening { get; set; }
        Spawn S = new Spawn();
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
            if (_bediening != null)
            {
                _bediening.Update();


                if (_bediening.left)
                // _animation.Update(gameTime);
                {
                    _ShowRectangle.X -= 84;
                    Positie -= VelocityX;
                    if (_ShowRectangle.X < 0)
                        _ShowRectangle.X = 672;

                }
                if (_bediening.right)
                // _animation.Update(gameTime);
                {
                    _ShowRectangle.X += 84;
                    Positie += VelocityX;
                    if (_ShowRectangle.X > 1668)
                        _ShowRectangle.X = 840;

                }

                if (_bediening.spatie && springen == false)
                {
                    Positie.Y -= 80;
                    Velocity.Y = -9f;
                    springen = true;
                    //effect.Play();
                    System.Console.WriteLine("lucht collison");
                }

                if (springen == true)
                {
                    float i = 2;
                    Velocity.Y += 0.15f * i;
                }

                if (springen == false)
                {
                    Velocity.Y = 0f;
                }

                if (!_bediening.right && !_bediening.left && !_bediening.spatie)
                {
                    _ShowRectangle.X = 840;

                }
                CollisionRectangle.X = (int)Positie.X;
                CollisionRectangle.Y = (int)Positie.Y;
            }
            

        }
        Rectangle _ShowRectangle = new Rectangle(840, 0, 84, 93);

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
   
