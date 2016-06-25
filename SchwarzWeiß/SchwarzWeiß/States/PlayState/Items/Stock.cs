using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace SchwarzWeiß
{
    class Stock : Weapon
    {
        public Stock(float x, float y)
        {
            isAlive = true;
            texture = new Texture("assets/Stock.png");
            sprite = new Sprite(texture);
            Console.WriteLine("HAlloSTOCK");
            sprite.Position = new Vector2f(x, y);
        }
        public override void Update()
        {
            //ToDo COllision - Jedes Item verwaltet sich selber

            // Collision -> 20 Punkte

            PlayerCollision();

        }
        protected override void OnCollisionWithPlayer(int id)
        {
            if (id == 1) //Player1
            {
                if(ObjectHandler.player1.weaponnr == 0)
                {
                    ObjectHandler.player1.weaponnr = 1;
                    ObjectHandler.itemlist.Remove(this);
                }
            }
            else //Player2
            {
                if (ObjectHandler.player2.weaponnr == 0)
                {
                    ObjectHandler.player2.weaponnr = 1;
                    ObjectHandler.itemlist.Remove(this);
                }

            }

        }
        public override void HandleEvents()
        {

        }
        public override void Render(RenderWindow window)
        {
            window.Draw(sprite);
        }
    }
}
