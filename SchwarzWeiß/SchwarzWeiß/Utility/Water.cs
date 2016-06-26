using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchwarzWeiß
{
    class Water
    {

        Vector2f moveDir;
        Vector2f pos;
        float speed;
        RectangleShape shape;
        public bool isAlive = true;

        public Water(Vector2f position)
        {
            Console.WriteLine("Push");
            shape = new RectangleShape(new Vector2f(3,3));
            shape.FillColor = new Color(220, 20, 210);
            shape.Position = position;
            Random rnd = new Random();
            moveDir = new Vector2f(rnd.Next(-100, 100), rnd.Next(-100, 100));
            moveDir = MVec.normalize(moveDir);
            speed = 1;
        }

        public void Draw(RenderWindow win)
        {
            win.Draw(shape);
        }


        public void Update(GameTime gTime)
        {
            shape.Position += moveDir * gTime.Ellapsed.Milliseconds * speed;

            if (shape.Position.X < 0 || shape.Position.Y < 0 || shape.Position.X > ObjectHandler.winSize.X || shape.Position.Y > ObjectHandler.winSize.Y)
                isAlive = false;

        }
    }
}
