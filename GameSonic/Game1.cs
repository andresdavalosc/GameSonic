﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace GameSonic
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        int wereld = 1;
        public Bediening _bediening { get; set; }
        Timer tijd = new Timer();
        public static SoundEffect _sound;
        GraphicsDeviceManager graphics;
        CheckCollisionCoins checkcoin;
        CheckCollisionBlock checkblock;
        CheckCollionFlag checkFlag = new CheckCollionFlag();
        public static SpriteFont font;
        SpriteBatch spriteBatch;
        public static Sonichero _sonic ;
        Vlag _flag;
        Levens Hart1, Hart2, Hart3;
        public static Texture2D hero1,flag;
        Texture2D sky;
        Texture2D hearth;
        Level level;
        public static SoundEffect effect;
        public static SoundEffect coinseffect;
        Song song;
        public Sonichero status;
        public static List<ICollide> CollideObjecten { get; set; } = new List<ICollide>();
        public static List<ICollide> _Coins { get; set; } = new List<ICollide>();
        public static List<ICollide> _Blok { get; set; } = new List<ICollide>();
        public static List<ICollide> _vlag { get; set; } = new List<ICollide>();
        public static List<Levens> Hart { get; set; } = new List<Levens>();
        Camera Camera;
        public int i,x;
        public int count = 0;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = (int)GameSonic.ScreenManager.Instance.Dimensions.X;
            graphics.PreferredBackBufferHeight = (int)GameSonic.ScreenManager.Instance.Dimensions.Y;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Camera = new Camera(GraphicsDevice.Viewport);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Collect.Content = Content;
            Helper.Content = Content;
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            hero1 = Content.Load<Texture2D>("sanic");
            flag = Content.Load<Texture2D>("flag");
            hearth = Content.Load<Texture2D>("hearth");
            effect = Content.Load<SoundEffect>("effect");
            _sound = Content.Load<SoundEffect>("4");
            coinseffect = Content.Load<SoundEffect>("coins-effect");
            song = Content.Load<Song>("background-effect");
            font = Content.Load<SpriteFont>("Font");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
            _sonic = new Sonichero(hero1, Spawn.spawning);
            _flag = new Vlag(flag, new Vector2(1650, 780));
            Hart1 = new Levens(hearth, new Vector2(5, 0));
            Hart2 = new Levens(hearth, new Vector2(37, 0));
            Hart3 = new Levens(hearth, new Vector2(74, 0));
            _sonic._bediening = new BedieningPijltjes();
            
            //blokText = Content.Load<Texture2D>("blok");
            sky = Content.Load<Texture2D>("space");
            CollideObjecten = new List<ICollide>();
            Hart.Add(Hart1);
            Hart.Add(Hart2);
            Hart.Add(Hart3);
            CollideObjecten.Add(_sonic);
            _vlag.Add(_flag);
            level = new Level();
            checkcoin = new CheckCollisionCoins();
            checkblock = new CheckCollisionBlock();
            World.Worlds(wereld);
            ScreenManager.Instance.GraphicsDevice = GraphicsDevice;
            ScreenManager.Instance.SpriteBatch = spriteBatch;
            ScreenManager.Instance.LoadContent(Content);
            //// TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            ScreenManager.Instance.UnloadContent();
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // _sonic.Update(effect);
            ScreenManager.Instance.Update(gameTime);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (!Gepauzeerd.gepauzeerd)
            {
                    foreach (Coins C in _Coins)
                {
                    C.Update(gameTime);

                }
                foreach (Blok B in _Blok)
                {
                    B.Update();
                }
                foreach (Levens H in Hart)
                {
                    if (H != null)
                    {
                        H.Update();
                    }
                }
                checkFlag.Update(_sonic,spriteBatch);
                checkblock.Update(gameTime);
                checkcoin.Update(gameTime);
                if (level != null)
                {
                    Camera.Update(Sonichero.Positie);
                }               
                if (MenuManager.start)
                {
                    tijd.Update(gameTime);
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, Camera.transform);
            spriteBatch.Draw(sky, new Vector2(0, 0), Color.White);
            ScreenManager.Instance.Draw(spriteBatch);
            if(MenuManager.start)
            {
                
                _sonic.Draw(spriteBatch);
                _flag.Draw(spriteBatch);
                checkcoin.Draw(spriteBatch, font);
                foreach (Levens H in Hart)
                {
                    if (H != null)
                    {
                        H.Draw(spriteBatch);
                    }
                }
                level.DrawWorld(spriteBatch);
                tijd.Draw(spriteBatch, font);

                
            }
            if (Gepauzeerd.gepauzeerd)
            {
                Gepauzeerd.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
