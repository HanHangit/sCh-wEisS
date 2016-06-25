using SFML.Window;
using SFML.Graphics;
using SFML.System;
using SFML.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SchwarzWeiß
{
    class ObjectHandler
    {
        public static Player player1 = new Player(EPlayer.Player1, "A", new Image("pictures/lolsmall.png"),new Vector2f(100,350));
        public static Player player2 = new Player(EPlayer.Player2, "B", new Image("pictures/MeGustaSmall.png"),new Vector2f(1180,350));
        public static Vector2u winSize;
        //public static Stern sterni = new Stern();
        public static List<Item> itemlist = new List<Item>();
        public static List<Traps> traplist = new List<Traps>();
        //Map
        public static Map map;

    }
}
