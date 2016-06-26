using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace SchwarzWeiß
{
    class Level1 : GameState
    {

        RectangleShape background;
        ItemHandler itemhandler;
        public static int highscore;

        public void Initialize()
        {
            highscore = 10;
            background = new RectangleShape((Vector2f)ObjectHandler.winSize);
            background.FillColor = Color.Green;
            itemhandler = new ItemHandler();

            ObjectHandler.map = new Map();

        }

        public void LoadContent()
        {
            
        }

        public EGameState Update(RenderWindow win, GameTime t)
        {
            itemhandler.Update();
            ObjectHandler.map.Update(win, t);
            ObjectHandler.player1.Update(win, t);
            itemhandler.Render(win);
            ObjectHandler.player2.Update(win, t);
            if (Keyboard.IsKeyPressed(Keyboard.Key.B))
                return EGameState.TitleScreen;
            else
                return EGameState.Map1;
        }

    }
    
}
