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

   enum EPlayer
    {
        Player1,
        Player2
    }

    class Player
    {


        Vector2f moveDirection;
        //RectangleShape playerShape = new RectangleShape(new Vector2f(11, 11));
        Image image;
        Texture texture;
        Sprite sprite;

        Text txt;
        Font font;

        EPlayer mType;

        public static float sweatlevel { get; set; }
        public static int capacity { get; set; }
        public static float speed { get; set; }

        public static Vector2f position { get; private set; }
        public static Vector2f size { get; private set; }
        
        public Player(EPlayer playernum, string str, Image img)
        {
            sweatlevel = 0;
            image = new Image(img);
            texture = new Texture(image);
            sprite = new Sprite(texture);
            sprite.Position = new Vector2f((ObjectHandler.winSize.X)/2, (ObjectHandler.winSize.Y)/2);
            mType = playernum;
            font = new Font("arialbd.ttf");
            txt = new Text(str, font);
            //playerShape.Position = new Vector2f(50, 50);
            //playerShape.FillColor = new Color(255, 255, 255);
            speed = 1;
        }

        public EPlayer getType()
        {
            return mType;
        }

        void Move(GameTime gTime)
        {
            if ((sprite.Position + moveDirection * speed * gTime.Ellapsed.Milliseconds).X > 0 
                && (sprite.Position + moveDirection * speed * gTime.Ellapsed.Milliseconds).Y > 0
                    && (sprite.Position + moveDirection * speed * gTime.Ellapsed.Milliseconds).X < ObjectHandler.winSize.X - 33
                        && (sprite.Position + moveDirection * speed * gTime.Ellapsed.Milliseconds).Y < ObjectHandler.winSize.Y - 33)
            {
                //playerShape.Position += moveDirection * speed * gTime.Ellapsed.Milliseconds;
                sprite.Position += moveDirection * speed * gTime.Ellapsed.Milliseconds;
            }
        }

        void KeyboardInput()
        {
            moveDirection = new Vector2f(0, 0);
            if (mType == EPlayer.Player1)
            {

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
            if (mType == EPlayer.Player2)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                    moveDirection += new Vector2f(-1, 0);
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                    moveDirection += new Vector2f(0, -1);
                if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                    moveDirection += new Vector2f(1, 0);
                if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                    moveDirection += new Vector2f(0, 1);

                moveDirection = MVec.normalize(moveDirection);
            }

        }

        public void Update(RenderWindow win, GameTime gTime)
        {

            win.Draw(sprite);

            KeyboardInput();
            Move(gTime);

            DrawHud(win);
            //win.Draw(playerShape);

            //position = playerShape.Position;
            //size = playerShape.Size;

        }

        void DrawHud(RenderWindow window)
        {
        }


    }
}
