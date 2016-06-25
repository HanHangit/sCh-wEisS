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
    class Stern :  Item
    {
        
        public Stern(float x, float y) { 
            isAlive = true;
            texture = new Texture("assets/Stein.png");
            sprite = new Sprite(texture);
            Console.WriteLine("HALLOWELT");
            sprite.Position = new Vector2f(x,y);
        }
        public override void Update()
        {
            //ToDo COllision - Jedes Item verwaltet sich selber

            // Collision -> 20 Punkte

            PlayerCollision();

        }
        protected override void OnCollisionWithPlayer(int id)
        {
            if(id == 1)
            {

                Console.WriteLine("Capacity " + ObjectHandler.player1.capacity);
                Console.WriteLine("Carry " + ObjectHandler.player1.carry);

                if (!(ObjectHandler.player1.carry == ObjectHandler.player1.capacity)) {
                    ObjectHandler.player1.carry++;
                    //ToDO Check obs Funktioniert
                    ObjectHandler.itemlist.Remove(this);
                }
                
            }
            else if (!(ObjectHandler.player2.carry == ObjectHandler.player2.capacity))
            {
                ObjectHandler.player2.carry++;
                //ToDO Check obs Funktioniert
                ObjectHandler.itemlist.Remove(this);
            }
        }
        public  override void HandleEvents()
        {

        }
        public  override void Render(RenderWindow window)
        {
            window.Draw(sprite);
        }
    }
}
