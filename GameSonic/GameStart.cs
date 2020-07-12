using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameSonic
{
    public class GameStart : GameScreen
    {

        Sonichero Sonic ;
        Texture2D Content;
        //Game1 g = new Game1();
        Spawn s = new Spawn();
        public override void LoadContent()
        {
            base.LoadContent();            
            Game1._sonic.LoadContent();
            
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            Game1._sonic.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Game1._sonic.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            Game1._sonic.Draw(spriteBatch);
        }

        
    }
}
