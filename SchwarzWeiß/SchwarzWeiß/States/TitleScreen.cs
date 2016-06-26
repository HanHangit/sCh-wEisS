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
        Font fontgamename, fontforall;
        Text gamename, exit, start, credits, levels, mainmenu, memeselection;
        Image ibackground;
        Texture tbackground;
        Sprite sbackground;
        Sprite stones;
        Sprite stones1;
        Sprite pftch;
        Sprite sweatman;

        List<RectangleShape> list;

        public void Initialize()
        {
            list = new List<RectangleShape>();
            //mainmenu, start
            list.Add(new RectangleShape(new Vector2f(420, 100)));
            list.Add(new RectangleShape(new Vector2f(120, 60)));
            //end, credits
            list.Add(new RectangleShape(new Vector2f(100, 60)));
            list.Add(new RectangleShape(new Vector2f(150, 60)));
            //levels, characters
            list.Add(new RectangleShape(new Vector2f(150, 60)));
            list.Add(new RectangleShape(new Vector2f(210, 60)));
            //stones, sweatman <- sounds !!!!!!!!
            list.Add(new RectangleShape(new Vector2f(160, 190)));
            list.Add(new RectangleShape(new Vector2f(345, 260)));

            //mainmmenu
            list[0].Position = new Vector2f(420, 280);
            list[0].FillColor = new Color(Color.Transparent);
            //start
            list[1].Position = new Vector2f(330, 400);
            list[1].FillColor = new Color(Color.Transparent);
            //end
            list[2].Position = new Vector2f(750, 600);
            list[2].FillColor = new Color(Color.Transparent);
            //credits
            list[3].Position = new Vector2f(750, 500);
            list[3].FillColor = new Color(Color.Transparent);
            //levels
            list[4].Position = new Vector2f(330, 500);
            list[4].FillColor = new Color(Color.Transparent);
            //characters
            list[5].Position = new Vector2f(330, 600);
            list[5].FillColor = new Color(Color.Transparent);
            //stones
            list[6].Position = new Vector2f(1000, 335);
            list[6].FillColor = new Color(Color.Transparent);
            //sweatman
            list[7].Position = new Vector2f(910, 525);
            list[7].FillColor = new Color(Color.Transparent);

            pftch = new Sprite(new Texture(new Image("pictures/pftch.png")));
            pftch.Position = new Vector2f(125,275);
            stones = new Sprite(new Texture(new Image("pictures/taller-stone-stack.png")));
            stones.Position = new Vector2f(-90, 277);
            stones1 = new Sprite(new Texture(new Image("pictures/tall-stone-stack.png")));
            stones1.Position = new Vector2f(957, 297);
            sweatman = new Sprite(new Texture(new Image("pictures/sweatman.png")));
            sweatman.Position = new Vector2f(900, 520);

            ibackground = new Image("pictures/grasstitlescreen.png");
            tbackground = new Texture(ibackground);
            sbackground = new Sprite(tbackground);

            fontgamename = new Font("Peccatum.ttf");
            gamename = new Text("Sch-Weiss", fontgamename);
            gamename.Position = new Vector2f(220, -5);
            gamename.CharacterSize = 240;

            

            fontforall = new Font("CANDLE LIGHT.ttf");
            mainmenu = new Text("mainmenu", fontforall);
            mainmenu.Position = new Vector2f(470, 275);
            mainmenu.CharacterSize = 70;

            credits = new Text("credits", fontforall);
            credits.Position = new Vector2f(750, 500);
            credits.CharacterSize = 40;

            start = new Text("start", fontforall);
            start.Position = new Vector2f(330, 400);
            start.CharacterSize = 40;

            exit = new Text("end", fontforall);
            exit.Position = new Vector2f(750, 600);
            exit.CharacterSize = 40;

            levels = new Text("levels", fontforall);
            levels.Position = new Vector2f(330, 500);
            levels.CharacterSize = 40;

            memeselection = new Text("character", fontforall);
            memeselection.Position = new Vector2f(330, 600);
            memeselection.CharacterSize = 40;


        }

        public void LoadContent()
        {

        }

        public EGameState Update(RenderWindow win, GameTime t)
        {
            
            win.Draw(sbackground);
            for(int e = 0; e < 8; e++)
            {
                win.Draw(list[e]);
            }
            win.Draw(sweatman);
            win.Draw(pftch);
            win.Draw(stones);
            win.Draw(stones1);
            win.Draw(gamename);
            win.Draw(mainmenu);
            win.Draw(credits);
            win.Draw(start);
            win.Draw(exit);
            win.Draw(levels);
            win.Draw(memeselection);

            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                return EGameState.Map1;
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                return EGameState.None;
            else
                return EGameState.TitleScreen;
        }
    }
}
