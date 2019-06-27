using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabioGame.Components
{
    class Player : BaseObject
    {
        public int Score { get; set; }

        public Player() { Score = 0; Type = ObjType.Player1; Color = Color.White; }
        public Player
       (
           Color color,
           Vector2 size,
           Texture2D image,
           Input playerInput,

           GraphicsDeviceManager graphics,

           float speed = 1,
           float life = 100,
           ObjType type = ObjType.Player1,
           Vector2 position = new Vector2(),
           Vector2 direction = new Vector2(),
           Rectangle transform = new Rectangle()
       )
        {

            //SetDirection(direction.X,Direction.Y);

            Type = type;
            Life = life;
            Size = size;
            Speed = speed;
            Color = color;
            Image = image;
            Input = playerInput;
            Graphics = graphics;
            Position = position;
            Transform = transform;
            //SetSize((int)size.X, (int)size.Y);
            //SetPosition((int)position.X,(int)position.Y);

        }
        public void AddScore (int score)
        {
            Score += score;
        }
    }
}
