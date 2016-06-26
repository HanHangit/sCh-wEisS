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
    internal class Credits : GameState
    {
        Image ibackground;
        Texture tbackground;
        Sprite sbackground;
        Sprite blackback;
        //RectangleShape blackbox;
        Text ben, chris, joh, co, co2, gamename;
        Font fontforall, fontgamename;
        List<Text> namel;

        public void Initialize()
        {
            ibackground = new Image("pictures/grasstitlescreen.png");
            tbackground = new Texture(ibackground);
            sbackground = new Sprite(tbackground);
            blackback = new Sprite(new Texture(new Image(1280, 720, new Color(0, 0, 0, 200))));

            fontgamename = new Font("Peccatum.ttf");
            gamename = new Text("Sch-Weiss", fontgamename);
            gamename.Position = new Vector2f(220, -5);
            gamename.CharacterSize = 240;
            gamename.Color = new Color(255, 255, 255, 64);

            int sz = 720;

            fontforall = new Font("CANDLE LIGHT.ttf");
            ben = new Text(" ben \t\t\t big bot\n\t\t\t\t\t lazy lama\n\t\t\t\t\t funky freak", fontforall);
            ben.Position = new Vector2f(450, sz*1);
            ben.Color = Color.Blue;
            chris = new Text("chris\t\t\tcrazy camper\n\t\t\t\t\t unable to walk-er\n\t\t\t\t\t insane idiot\n\t\t\t\t\t creepy contributer", fontforall);
            chris.Position = new Vector2f(450, sz*2);
            chris.Color = Color.Yellow;
            joh = new Text(" joh  \t\t\tbig brain\n\t\t\t\t\t fucking faggot\n\t\t\t\t\t mazing man\n\t\t\t\t\t hungry human", fontforall);
            joh.Position = new Vector2f(450, sz*3);
            joh.Color = Color.Red;
            co = new Text("matthis   \tnerdy nigga\n\t\t\t\t\t first creative co-author\n\t\t\t\t\t graphic geek\n\t\t\t\t\t wired workaholic", fontforall);
            co.Position = new Vector2f(450, sz * 4);
            co.Color = Color.Green;
            co2 = new Text(" lea \t\t\tgerman girlfriend\n\t\t\t\t\t second creative co-author\n\t\t\t\t\t woozy woman\n ", fontforall);
            co2.Position = new Vector2f(450, sz * 5);
            co2.Color = Color.Magenta;

            Text[] namelist = { ben, chris, joh, co, co2 };
            namel = namelist.ToList();
        }

        public void LoadContent()
        {

        }

        public EGameState Update(RenderWindow win, GameTime t)
        {
            win.Clear();
            win.Draw(sbackground);
            win.Draw(blackback);
            win.Draw(gamename);
            foreach(Text names in namel)
            {
                win.Draw(names);
                names.Position = new Vector2f(names.Position.X, names.Position.Y-(t.Ellapsed.Milliseconds/5f));
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                return EGameState.TitleScreen;
            else
                return EGameState.Credits;
        }
    }
}