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
    class TitleScreen : GameState
    {

        public void Initialize()
        {
            
        }

        public void LoadContent()
        {

        }

        public EGameState Update(RenderWindow win, GameTime t)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                return EGameState.Map1;
            else
                return EGameState.TitleScreen;
        }
    }
}
