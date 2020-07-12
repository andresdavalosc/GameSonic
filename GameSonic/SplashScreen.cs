using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GameSonic
{
    public class SplashScreen : GameScreen
    {
        public Image Image;
        public String Path;
        Vector2 pos;
        public override void LoadContent()
        {
            base.LoadContent();
            Image.LoadContent();
            //pos = new Vector2(550, 200);
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
            Image.UnloadContent();
            //Image.FadeEffect.FadeSpeed = 0.5f;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Image.Update(gameTime);

            if (InputManager.Instance.KeyPressed(Keys.Enter))
            {
                ScreenManager.Instance.ChangeScreens("TitleScreen");
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }
    }
}
