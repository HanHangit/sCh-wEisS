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

   

    class Player1
    {


        Vector2f moveDirection;
        RectangleShape playerShape = new RectangleShape(new Vector2f(11, 11));
        public static Vector2f position { get; private set; }
        public static Vector2f size { get; private set; }
        float speed;

        public Player1()
        {
            playerShape.Position = new Vector2f(50, 50);
            playerShape.FillColor = new Color(255, 255, 255);
            speed = 1;
        }

        void Move(GameTime gTime)
        {

            playerShape.Position += moveDirection * speed * gTime.Ellapsed.Milliseconds;
        }

        void KeyboardInput()
        {
            moveDirection = new Vector2f(0, 0);

            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                moveDirection += new Vector2f(-1, 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                moveDirection += new Vector2f(0, -1);
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                moveDirection += new Vector2f(1, 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                moveDirection += new Vector2f(0, 1);

            moveDirection = MVec.normalize(moveDirection);

        }

        public void Update(RenderWindow win, GameTime gTime)
        {

            KeyboardInput();
            Move(gTime);

            DrawHud(win);
            win.Draw(playerShape);

            position = playerShape.Position;
            size = playerShape.Size;

        }

        void DrawHud(RenderWindow window)
        {
        }


    }
}
