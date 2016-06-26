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
        Text winner;
        Font winnerfont;
        GUI gui;
        RectangleShape background;
        ItemHandler itemhandler;
        public static int highscore;

        public void Initialize()
        {
            winnerfont = new Font("CANDLE LIGHT.ttf");
            highscore = 50;
            background = new RectangleShape((Vector2f)ObjectHandler.winSize);
            background.FillColor = Color.Green;
            itemhandler = new ItemHandler();
            gui = new GUI();
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
            gui.Update();
            gui.Render(win);

            if (Level1.highscore <= ObjectHandler.player1.score && ObjectHandler.player1.score > ObjectHandler.player2.score)
            {
                //show "Player 1 wins"
                winner = new Text("player one\n\t wins", winnerfont);
                winner.Color = Color.Blue;
                winner.CharacterSize = 200;
                winner.Position = new Vector2f(100, 120);
                win.Draw(winner);
            }
            if (Level1.highscore <= ObjectHandler.player2.score && ObjectHandler.player2.score > ObjectHandler.player1.score)
            {
                //show "Player 2 wins"
                winner = new Text("player two\n\t wins", winnerfont);
                winner.Color = Color.Red;
                winner.CharacterSize = 200;
                winner.Position = new Vector2f(100, 120);
                win.Draw(winner);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.B))
                return EGameState.TitleScreen;
            else
                return EGameState.Map1;
            

        }


    }
    
}
