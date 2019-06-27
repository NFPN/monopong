using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabioGame.Components
{
    class Enemy : BaseObject
    {
        public Enemy() { }
        public Enemy
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
        }
    }
}
