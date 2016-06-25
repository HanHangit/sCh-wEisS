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
    public class Traps :Collider
    {
        Texture texture;
        Sprite sprite;
        bool isAlive;
        Clock clock;
        Clock stunclockPlayer1;
        float player1speed;
       public Traps(Vector2f pos)
        {
            clock = new Clock();
            stunclockPlayer1 = new Clock();
            stunclockPlayer1.Restart();
            float player1speed = 0;
            clock.Restart();
            isAlive = true;
            texture = new Texture("assets/Falle.png");
            sprite = new Sprite(texture);
            sprite.Position = new Vector2f(pos.X, pos.Y);
        }
        public void Update()
        {
            if(ObjectHandler.player1.speed == 0)
            {
                //STUNLOCK TIME EINSTELLEN
                if(ObjectHandler.player1.speed == 0 && stunclockPlayer1.ElapsedTime.AsSeconds() > 2)
                {
                    ObjectHandler.player1.speed = player1speed;
                    player1speed = 0;
                }
            }
            if(clock.ElapsedTime.AsSeconds() > 2)
            {
                if (Collision<Traps,Player>.CheckColission(this, ObjectHandler.player1))
                {
                    player1speed = ObjectHandler.player1.speed;
                    ObjectHandler.player1.speed = 0;
                    stunclockPlayer1.Restart();
                }
            }
            
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
