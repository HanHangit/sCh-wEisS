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
    abstract class Item
    {
        public Item() { }
        public abstract void Update();
        public abstract void HandleEvents();
        public abstract void Render(RenderWindow window);
        public void PlayerCollision()
        {
            
            //ToDo Collision
            if (true) //Player1Collision
            {
             
                OnCollisionWithPlayer(1);
              
            }
            else if(false)//Payer2Collision)
            {
              
                OnCollisionWithPlayer(2);
              
            }
        }
        protected abstract void OnCollisionWithPlayer(int id);
      
        public bool isAlive {get; set;}
        protected Sprite sprite;
        protected Texture texture;
    }
}
