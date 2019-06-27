using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace FabioGame.Components
{
    class BaseObject
    {
        public ObjType Type;

        public float Life;
        public float Speed;
        public bool canMove = true;

        public Input Input;
        public Texture2D Image;
        public Color Color = Color.White;
        public Vector2 Size = new Vector2();
        public Vector2 Position = new Vector2();
        public Vector2 Direction = new Vector2();
        public Rectangle Transform = new Rectangle();
        public GraphicsDeviceManager Graphics;

        int run = 0;
        float thisDeltaTime;
        

        public virtual void Update(GameTime time)
        {
            thisDeltaTime = (float)time.ElapsedGameTime.TotalSeconds;

            if (Input == null)
                return;

            if (canMove)
            {
                //speed up
                run = Keyboard.GetState().IsKeyDown(Input.Focus) ? 5 : 2;

                //Movement
                if (Keyboard.GetState().IsKeyDown(Input.Up) && Transform.Y > 0)
                    Move(posY: -run);
                if (Keyboard.GetState().IsKeyDown(Input.Down) && Transform.Y < (Graphics.PreferredBackBufferHeight - Transform.Height))
                    Move(posY: run);

                //Debug.WriteLine(Type + " " + Transform);
            }
        }

        public void Move(float posX = 0, float posY = 0)
        {
            Position.X += posX * Speed;
            Position.Y += posY * Speed;

            //Transform.X = (int)Position.X;
           // Transform.Y = (int)Position.Y;
        }

        public void Draw(SpriteBatch batch)
        {
            //batch.Draw(Image, new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y), Color);

            Transform = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
            batch.Draw(Image, Transform , Color);
        }
    }
}
