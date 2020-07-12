using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace GameSonic
{
    public class ScreenManager
    {
        private static ScreenManager instance;
        [XmlIgnore]

        public Vector2 Dimensions { private set; get; }
        [XmlIgnore]

        public ContentManager Content { private set; get; }
        XmlManager<GameScreen> xmlGameScreenManager;
        GameScreen currenScreen, newScreen;
        [XmlIgnore]
        public GraphicsDevice GraphicsDevice;
        [XmlIgnore]
        public SpriteBatch SpriteBatch;
        public Image Image;
        [XmlIgnore]
        public bool IsTransitioning { get; private set; }
        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                {
                    XmlManager<ScreenManager> xml = new XmlManager<ScreenManager>();
                    instance = xml.Load("Content/Load/ScreenManager.xml");
                }
                return instance;
            }
        }

        public void ChangeScreens(string screenname)
        {
            newScreen = (GameScreen)Activator.CreateInstance(Type.GetType("GameSonic." + screenname));
            Image.IsActive = true;
            Image.FadeEffect.Increase = true;
            Image.Alpha = 0.0f;
            IsTransitioning = true;
        }

        void Transition(GameTime gameTime)
        {
            if (IsTransitioning)
            {
                Image.Update(gameTime);
                if (Image.Alpha == 1.0f)
                {
                    currenScreen.UnloadContent();
                    currenScreen = newScreen;
                    xmlGameScreenManager.Type = currenScreen.Type;
                    if (File.Exists(currenScreen.XmlPath))
                        currenScreen = xmlGameScreenManager.Load(currenScreen.XmlPath);
                    currenScreen.LoadContent();
                }
                else if (Image.Alpha == 0.0f)
                {
                    Image.IsActive = false;
                    IsTransitioning = false;
                }
            }
        }
        public ScreenManager()
        {
            Dimensions = new Vector2(1500, 900);
            currenScreen = new SplashScreen();
            xmlGameScreenManager = new XmlManager<GameScreen>();
            xmlGameScreenManager.Type = currenScreen.Type;
            currenScreen = xmlGameScreenManager.Load("Content/Load/SplashScreen.xml");
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            currenScreen.LoadContent();
            Image.LoadContent();

        }

        public void UnloadContent()
        {
            currenScreen.UnloadContent();
            Image.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            currenScreen.Update(gameTime);
            Transition(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currenScreen.Draw(spriteBatch);
            if (IsTransitioning)
                Image.Draw(spriteBatch);
        }

    }
}
