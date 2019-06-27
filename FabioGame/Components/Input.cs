using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabioGame.Components
{
    class Input
    {
        public Keys Up { get; set; } = Keys.Up;
        public Keys Down { get; set; } = Keys.Down;
        public Keys Left { get; set; } = Keys.Left;
        public Keys Right { get; set; } = Keys.Right;

        public Keys Focus { get; set; } = Keys.LeftShift;
        public Keys Shoot { get; set; } = Keys.Z;
    }
}
