using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabioGame.Components
{
    class Ball : BaseObject
    {
        public ObjType whoCollidedLast;
        public Vector2 initialPos;
        public Ball() { Type = ObjType.Ball; whoCollidedLast = ObjType.Ball; }

        public void Update(ref Vector2 window, GameTime time)
        {
            //GameOver
            if ((Position.X < 0) || (Position.X > (window.X - Size.X)))
            {
                Reset();
            }

            Update(time);
            if (Position.Y > window.Y - Size.Y || Position.Y <= 0)
                Direction.Y *= -1;
        }
        public override void Update(GameTime timer)
        {
            Move(Direction.X, Direction.Y);
        }

        /// <summary>
        /// Who ball collided with 
        /// </summary>
        /// <param name="playerRef">Who with</param>
        public void CollidedWith(ref Player playerRef)
        {
            if (whoCollidedLast != playerRef.Type)
            {
                Speed += .5f;
                Color = playerRef.Color;
                whoCollidedLast = playerRef.Type;
                Direction = new Vector2(Direction.X * -1, Position.Y > (playerRef.Position.Y + (playerRef.Image.Height / 2)) ? 1 : -1);
            }
        }

        Random rand = new Random();
        public void Reset()
        {
            Position = initialPos;
            Speed = Speed > 1 ? Speed / 2 : 1;
            
            /*if (whoWon != ObjType.Ball)
                Direction = new Vector2(whoWon == ObjType.Player1 ? -1 : 1, Direction.Y);
            else
                Direction = new Vector2(-1, 1);

            //Any direction of ball is 0, or whenever dirY is 0
            if ((whoWon == ObjType.Ball && (Direction.X == 0 || Direction.Y == 0)) || (whoWon != ObjType.Ball && Direction.Y == 0))
                Reset(whoWon);*/
        }
    }
}
