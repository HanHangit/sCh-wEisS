using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using SFML.Audio;

namespace SchwarzWeiß
{
    class MVec
    {

        public static float length(Vector2f vec)
        {
            return (float)Math.Sqrt(vec.X * vec.X + vec.Y * vec.Y);
        }

        public static Vector2f normalize(Vector2f vec)
        {
            if (vec.X != 0 || vec.Y != 0)
                return new Vector2f(vec.X / length(vec), vec.Y / length(vec));
            else
                return new Vector2f(0, 0);
        }
    }
}
