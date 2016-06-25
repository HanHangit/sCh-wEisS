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

        public void Initialize()
        {
            
            background = new RectangleShape((Vector2f)ObjectHandler.winSize);
            background.FillColor = Color.Green;
            itemhandler = new ItemHandler();

        }

        public void LoadContent()
        {
            
        }

        public EGameState Update(RenderWindow win, GameTime t)
        {
            win.Draw(background);
            itemhandler.Update();
            ObjectHandler.player1.Update(win, t);
            itemhandler.Render(win);
            ObjectHandler.player2.Update(win, t);
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                return EGameState.None;
            else
                return EGameState.Map1;
        }

    }
    
}
