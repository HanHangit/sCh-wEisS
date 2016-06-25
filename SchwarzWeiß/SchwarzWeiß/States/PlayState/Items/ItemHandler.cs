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
        int sterndu;
        public ItemHandler()
        {
            int sterndu = 0;
            clock = new Clock();
            clock.Restart();
        }
        void Insert(Item item)
        {
           
            ObjectHandler.itemlist.Add(item);
        }
        public void Update()
        {
            Spawn();
            foreach (Item it in ObjectHandler.itemlist)
            {
               
                it.Update();
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
                Stern p = new Stern(posX, posY);
                ObjectHandler.itemlist.Add(p);
                clock.Restart();
                sterndu++;
            }
        }
    }
}
