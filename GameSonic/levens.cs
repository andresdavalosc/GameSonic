using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{
    public class Levens 
    {

        private Texture2D _hart;
        public static Vector2 Positie;
        private Rectangle _ShowRect;
        SpriteFont _font;
        public int count;
        public Bediening _bediening { get; set; }


        public Levens(Texture2D _texture, Vector2 _positie)
        {
            _hart = _texture;
            Positie = _positie;
            _ShowRect = new Rectangle(0, 0, 37, 35);

        }


        public void Update()
        {
            count = Game1.Hart.Count;
            Positie.X = Camera.centre.X-700;
            
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            _font = font;
            spriteBatch.Draw(_hart, Positie, _ShowRect, Color.AliceBlue);
            spriteBatch.DrawString(_font,count + "X:", new Vector2(Positie.X-35, 0), Color.Red);

        }

    }
}
