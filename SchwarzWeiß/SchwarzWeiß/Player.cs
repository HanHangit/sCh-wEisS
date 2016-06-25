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

    class Player : Collider
    {
        
        Vector2f moveDirection;
        //RectangleShape playerShape = new RectangleShape(new Vector2f(11, 11));
        Image image;
        Texture texture;
        Sprite sprite;

        Text txt;
        Font font;

        EPlayer mType;

        public float sweatlevel { get; set; }
        public int capacity { get; set; }
        public int carry { get; set; }
        public float speed { get; set; }

        public Vector2f home;
        public Vector2f position { get; private set; }
        public Vector2f size { get; private set; }
        
        public Player(EPlayer playernum, string str, Image img, Vector2f pos)
        {
            carry = 0;
            capacity = 6;
            sweatlevel = 0;
            image = new Image(img);
            texture = new Texture(image);
            sprite = new Sprite(texture);
            sprite.Position = new Vector2f(pos.X,pos.Y);
            home = sprite.Position;
            mType = playernum;
            font = new Font("arialbd.ttf");
            txt = new Text(str, font);
            //playerShape.Position = new Vector2f(50, 50);
            //playerShape.FillColor = new Color(255, 255, 255);
            speed = 0.5f;
        }

        public Boolean compare(Vector2f p1pos, Vector2f p2pos)
        {
            Vector2f vec = p1pos - p2pos;
            double vecLength = Math.Sqrt(vec.X * vec.X + vec.Y * vec.Y);
            if ( vecLength < 15)
                return true;
            else return false;
        }

        public Boolean PlayerToPlayerCollision()
        {
            if(compare(ObjectHandler.player1.position, ObjectHandler.player2.position))
            {
                Console.WriteLine("chrisistcool");
                return true;
            }
            return false;
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
            PlayerToPlayerCollision();

            DrawHud(win);
            //win.Draw(playerShape);

            //position = playerShape.Position;
            //size = playerShape.Size;

        }

        void DrawHud(RenderWindow window)
        {
        }

        public Vector2f getPosition()
        {
            return sprite.Position;
        }

        public Vector2u getSize()
        {
            return sprite.Texture.Size;
        }
    }
}
