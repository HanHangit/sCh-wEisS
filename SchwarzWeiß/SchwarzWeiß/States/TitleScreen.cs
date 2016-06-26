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

        List<Text> textlist;
        List<IntRect> list;

        public void Initialize()
        {
            list = new List<IntRect>();
            //mainmenu, start
            list.Add(new IntRect(420, 280, 420, 100));
            list.Add(new IntRect(330, 400, 120, 60));
            //end, credits
            list.Add(new IntRect(750, 600, 100, 60));
            list.Add(new IntRect(750, 500, 150, 60));
            //levels, characters
            list.Add(new IntRect(330,500, 150, 60));
            list.Add(new IntRect(330, 600, 210, 60));
            //stones, sweatman <- sounds !!!!!!!!
            list.Add(new IntRect(1000, 335, 160, 190));
            list.Add(new IntRect(910, 525, 345, 260));

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

            Text[] array = { mainmenu, start, exit, credits, levels, memeselection, gamename};
            textlist = array.ToList();

        }

        public bool IsMouseInRectangle(IntRect rect, RenderWindow win)
        {
            Vector2i mouse = Mouse.GetPosition()-win.Position;
            return (rect.Left<mouse.X && rect.Left+rect.Width>mouse.X 
                        && rect.Top<mouse.Y && rect.Top+rect.Height>mouse.Y);
        }

        public void LoadContent()
        {

        }

        public EGameState Update(RenderWindow win, GameTime t)
        {
            
            win.Draw(sbackground);
            win.Draw(sweatman);
            win.Draw(pftch);
            win.Draw(stones);
            win.Draw(stones1);
            foreach(Text txt in textlist)
            {
                win.Draw(txt);
                txt.Color = Color.White;
            }
            textlist[0].Color = Color.Black;
            textlist[6].Color = Color.Red;

            int index = -1;
            
                for (int e = 0; e < 7; e++)
                {
                    if (IsMouseInRectangle(list[e], win))
                    {
                        index = e;
                        break;
                    }
                }
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    switch (index)
                    {
                        //start
                        case 1: return EGameState.Map1;
                        //end
                        case 2: return EGameState.None;
                        //credits
                        case 3: return EGameState.Credits;
                        //level
                        case 4: break;
                        case 5: break;
                        case 6: break;
                        case 7: break;
                        default: break;
                    }
                }
            else
            {
                if (index != -1 && index != 0)
                {
                    textlist[index].Color = Color.Blue;
                }
            }
            

            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                return EGameState.Map1;
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                return EGameState.None;
            else
                return EGameState.TitleScreen;
        }
    }
}
