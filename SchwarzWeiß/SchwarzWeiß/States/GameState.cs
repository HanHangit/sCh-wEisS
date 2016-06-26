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
    enum EGameState
    {
        None = -1,

        TitleScreen,
        Map1,
        Credits,
        Count
    }

    interface GameState
    {
        void Initialize();

        void LoadContent();


        EGameState Update(RenderWindow win, GameTime t);
    }
}