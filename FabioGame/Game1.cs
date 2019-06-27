using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using FabioGame.Components;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace FabioGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        Random rand = new Random();
        SpriteBatch spriteBatch;
        KeyboardState kBoard;
        

        Player player1, player2;
        bool canMove = true, isMoving = false;

        Ball ball;

        Vector2 windowSize;



        //Ball ball = new Ball();


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            windowSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var img = Content.Load<Texture2D>("Images\\esfera3d");

            //Ball Setup
            ball = new Ball()
            {
                Speed = 2,
                Image = img,
                Color = Color.Blue,
                Graphics = graphics,
                Direction = new Vector2(rand.Next(-1, 2), rand.Next(-1, 2)),
                Size = new Vector2(35, 35),
                Position = new Vector2(windowSize.X - img.Width, windowSize.Y - img.Height) / 2,
            };
            ball.initialPos = ball.Position;
            while (ball.Direction.X == 0 || ball.Direction.Y == 0)
            {
                ball.Direction = new Vector2(rand.Next(-1,2), rand.Next(-1, 2));
            }


            img = Content.Load<Texture2D>("Images\\jogador");

            //Player1 setup
            player1 = new Player
            (
                Color.Blue,
                new Vector2(img.Width, img.Height),
                img,
                new Input() { Up = Keys.W, Down = Keys.S},
                graphics,
                position: new Vector2(0, (windowSize.Y - img.Height) / 2),
                type: ObjType.Player1
            );
            player1.Move(0, 0);

            //Player2 setup
            player2 = new Player
            (
                Color.Red,
                new Vector2(img.Width, img.Height),
                img,
                new Input() { Focus = Keys.NumPad0 },
                graphics,
                position: new Vector2(windowSize.X - img.Width, (windowSize.Y - img.Height) / 2),
                type: ObjType.Player2
            );
            player2.Move(0, 0);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            kBoard = Keyboard.GetState();

            //Player & Ball Movement
            if (canMove)
            {
                player1.Update(gameTime);
                player2.Update(gameTime);
                ball.Update(ref windowSize,gameTime);

                if (ball.Transform.Intersects(player1.Transform))
                    ball.CollidedWith(ref player1);
                if (ball.Transform.Intersects(player2.Transform))
                    ball.CollidedWith(ref player2);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            ball.Draw(spriteBatch);
            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
