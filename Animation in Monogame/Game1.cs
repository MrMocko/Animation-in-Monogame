﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Animation_in_Monogame
{

    
    public class Game1 : Game
    {
        enum Screen
        {
            Intro, 
            Outro,
            TribbleYard
        }
        Screen screen;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Rectangle window;

        SoundEffect explode;

        Texture2D backroundTexture;

        Texture2D brownTribbleTexture;
        Rectangle brownTribbleRect;
        Vector2 brownTribbleSpeed;

        Texture2D creamTribbleTexture;
        Rectangle creamTribbleRect;
        Vector2 creamTribbleSpeed;
        
        Texture2D greyTribbleTexture;
        Rectangle greyTribbleRect;
        Vector2 greyTribbleSpeed;

        Texture2D orangeTribbleTexture;
        Rectangle orangeTribbleRect;
        Vector2 orangeTribbleSpeed;

        Texture2D introBackround;

        Texture2D outroBackround;

        SpriteFont starTrekFont;
       
        

        MouseState mouseState;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 800, 600);

            brownTribbleSpeed = new Vector2(0, 8);
            brownTribbleRect = new Rectangle(400, 0, 200, 200);

            creamTribbleSpeed = new Vector2(8, 0);
            creamTribbleRect = new Rectangle(200, 330, 100, 100);


            greyTribbleSpeed = new Vector2 (4, 4);
            greyTribbleRect = new Rectangle(300, 10, 100, 100);

            orangeTribbleSpeed = new Vector2 (50, -60);
            orangeTribbleRect = new Rectangle(500, 80, 150, 150);


            screen = Screen.Intro;



            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            starTrekFont = Content.Load<SpriteFont>("starTrekFont");
            introBackround = Content.Load<Texture2D>("introBackround");
            outroBackround = Content.Load<Texture2D>("outroBackround");
            backroundTexture = Content.Load<Texture2D>("Star Trek backround");
            brownTribbleTexture = Content.Load<Texture2D>("tribbleBrown");
            creamTribbleTexture = Content.Load<Texture2D>("tribbleCream");
            greyTribbleTexture = Content.Load<Texture2D>("tribbleGrey");
            orangeTribbleTexture = Content.Load<Texture2D>("tribbleOrange");
            explode = Content.Load<SoundEffect>("explosion");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {

            mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Backround
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed) 
                    screen = Screen.TribbleYard;



            }
            else if (screen == Screen.TribbleYard)
            {

                //Brown Tribble
                brownTribbleRect.X += (int)brownTribbleSpeed.X;
                brownTribbleRect.Y += (int)brownTribbleSpeed.Y;
                if (brownTribbleRect.Right > window.Width || brownTribbleRect.Left < 0)
                    brownTribbleSpeed.X *= -1;
                if (brownTribbleRect.Bottom > window.Height || brownTribbleRect.Top < 0)
                    brownTribbleSpeed.Y *= -1;

                //Cream Tribble
                creamTribbleRect.X += (int)creamTribbleSpeed.X;
                creamTribbleRect.Y += (int)creamTribbleSpeed.Y;
                if (creamTribbleRect.Right > window.Width || creamTribbleRect.Left < 0)
                    creamTribbleSpeed.X *= -1;
                if (creamTribbleRect.Bottom > window.Height || creamTribbleRect.Top < 0)
                    creamTribbleSpeed.Y *= -1;


                // Grey Tribble
                greyTribbleRect.X += (int)greyTribbleSpeed.X;
                greyTribbleRect.Y += (int)greyTribbleSpeed.Y;

                if (greyTribbleRect.Right > window.Width || greyTribbleRect.Left < 1)
                    greyTribbleSpeed.X *= -1;
                if (greyTribbleRect.Bottom > window.Height || greyTribbleRect.Top < 0)
                    greyTribbleSpeed.Y *= -1;

                // Orange Tribble
                orangeTribbleRect.X += (int)orangeTribbleSpeed.X;
                orangeTribbleRect.Y += (int)orangeTribbleSpeed.Y;

                if (orangeTribbleRect.Right > window.Width || orangeTribbleRect.Left < 0)
                    orangeTribbleSpeed.X *= -1;
                if (orangeTribbleRect.Bottom > window.Height || orangeTribbleRect.Top < 0)
                    orangeTribbleSpeed.Y *= -1;
                
                // Outro Backround
                if (mouseState.RightButton == ButtonState.Pressed)
                {
                    screen = Screen.Outro;
                }
                if (mouseState.RightButton == ButtonState.Pressed)
                {
                    explode.Play();
                }
            }
            





            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introBackround, window, Color.White);
                _spriteBatch.DrawString(starTrekFont, "Fonts Rule", new Vector2(400, 300), Color.White);
            }
            else if (screen == Screen.TribbleYard)
            {
                _spriteBatch.Draw(backroundTexture, new Vector2(0, 0), Color.White);

                _spriteBatch.Draw(brownTribbleTexture, brownTribbleRect, Color.White);

                _spriteBatch.Draw(creamTribbleTexture, creamTribbleRect, Color.White);

                _spriteBatch.Draw(greyTribbleTexture, greyTribbleRect, Color.White);

                _spriteBatch.Draw(orangeTribbleTexture, orangeTribbleRect, Color.White);
            }
            if (screen == Screen.Outro)
            {
                _spriteBatch.Draw(outroBackround, window, Color.White);
                
            }
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
