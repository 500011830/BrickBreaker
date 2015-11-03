using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Brick_Breaker
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D Paddle;
        Vector2 PosPaddle;

        Texture2D Ball;
        Vector2 PosBall;
        Vector2 Ballspeed = new Vector2(200, 200);

        Texture2D Brick;
        List<Vector2> Brickpos = new List<Vector2>();
        List<Color> BrickCol = new List<Color>();

        Random rng = new Random();
        int startDelay = 3000;
        SpriteFont gameFont;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 1200;
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
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Ball = Content.Load<Texture2D>("Ball");
            PosBall = new Vector2(565f, 375f);

            Paddle = Content.Load<Texture2D>("Paddle");
            PosPaddle = new Vector2(565f, 400f);

            Brick = Content.Load<Texture2D>("Brick");


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            PosBall += Ballspeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            int maxX = GraphicsDevice.Viewport.Width - Ball.Width;
            int maxY = GraphicsDevice.Viewport.Height - Ball.Height;

            if (PosBall.X > maxX || PosBall.X < 0)
                Ballspeed.X *= -1;

            if (PosBall.Y > maxY || PosBall.Y < 0)

                Ballspeed.Y *= -1;

            // TODO: Add your update logic here
            {
                KeyboardState keyState = Keyboard.GetState();

                if (keyState.IsKeyDown(Keys.Left))

                    PosPaddle.X -= 5;

                else if (keyState.IsKeyDown(Keys.Right))

                    PosPaddle.X += 5;

            }
            {
                
                if (PosBall.Y > maxX || PosBall.X < 0)

                    Ballspeed.Y *= -1;


                if (PosBall.X < 0)

                    Ballspeed.X *= -1;
                else if (PosBall.X > maxX)
                {

                    // Ball hit the bottom of the screen, so reset ball

                    PosBall.X = 0;

                    Ballspeed.X = 150;

                    Ballspeed.Y = 150;
                }
                {
                    Rectangle BallR = new Rectangle((int)PosBall.X,
                    (int)PosBall.Y, Ball.Width, Ball.Height);

                    Rectangle PaddleR = new Rectangle((int)PosPaddle.X, (int)PosPaddle.Y,
                        Paddle.Width, Paddle.Height);
                    
                    if (BallR.Intersects(PaddleR))
     
            
            base.Update(gameTime);    
                }
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            spriteBatch.Draw(Ball, PosBall, Color.White);
            spriteBatch.Draw(Paddle, PosPaddle, Color.White);

            
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
