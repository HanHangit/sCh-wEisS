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
    public class ItemHandler
    {
        Clock clock;
        Clock clockWeapon;
    
        public ItemHandler()
        {
        
            clock = new Clock();
            clockWeapon = new Clock();
            clock.Restart();
        }
        void Insert(Item item)
        {
           
            ObjectHandler.itemlist.Add(item);
        }
        public void Update()
        {
            Spawn();
            for(int it = 0; it < ObjectHandler.itemlist.Count; it++)
            {
                ObjectHandler.itemlist[it].Update();
               
            }
        }
        public void Render(RenderWindow win)
        {
            foreach (Item it in ObjectHandler.itemlist)
            {
                it.Render(win);
            }
        }
        void Spawn()
        {
            //ToDo Time einstellen
            if(clock.ElapsedTime.AsSeconds() > 2)
            {
                Random rnd = new Random();

                int posX = rnd.Next(100, 1100);
                int posY = rnd.Next(100, 600);

                Vector2f size = new Vector2f(20, 20);

                while(!ObjectHandler.map.walkable(new Vector2f(posX,posY))
                    || !ObjectHandler.map.walkable(new Vector2f(posX,posY) + size))
                {
                    posX = rnd.Next(100, 1100);
                    posY = rnd.Next(100, 600);
                }

                Stern p = new Stern(posX, posY);
                ObjectHandler.itemlist.Add(p);
                clock.Restart();

              
            }
            if(clockWeapon.ElapsedTime.AsSeconds() > 4)
            {
                Random rnd = new Random();

                int weaponchoose = rnd.Next(0, 2);

                int posX = rnd.Next(100, 1100);
                int posY = rnd.Next(100, 600);

                while (!ObjectHandler.map.walkable(new Vector2f(posX, posY)))
                {
                    posX = rnd.Next(100, 1100);
                    posY = rnd.Next(100, 600);
                }

                if (weaponchoose == 1)
                {
                    Stock q = new Stock(posX, posY);
                    ObjectHandler.itemlist.Add(q);
                }
                else
                {
                    Obst pq = new Obst(posX, posX);
                    ObjectHandler.itemlist.Add(pq);

                }
               
                clockWeapon.Restart();
            }
        }
    }
}
