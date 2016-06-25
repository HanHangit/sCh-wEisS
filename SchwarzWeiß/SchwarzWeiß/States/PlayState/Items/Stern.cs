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
            texture = new Texture("Stein.png");
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
        protected override void OnCollisionWithPlayer()
        {

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
