using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;

namespace SchwarzWeiß
{
    class Game
    {
        RenderWindow window;
        EGameState prev = EGameState.None, curr = EGameState.TitleScreen;
        GameState state;
        GameTime gTime;

        public Game()
        {
            window = new RenderWindow(new VideoMode(1280, 720), "Schweisausbruch");
            Console.WriteLine(window.Size.ToString());
            ObjectHandler.winSize = window.Size;
            window.Closed += (object sender, EventArgs e) => { (sender as Window).Close(); };
            window.SetFramerateLimit(120);
            gTime = new GameTime();
        }

        public void Run()
        {
            while (window.IsOpen)
            {
                Update();
                window.DispatchEvents();
            }
        }

        void HandleGameState()
        {
            switch (curr)
            {

                case EGameState.None:
                    window.Close();
                    break;
                case EGameState.TitleScreen:
                    state = new TitleScreen();
                    state.LoadContent();
                    state.Initialize();
                    break;
                case EGameState.Map1:
                    state = new Level1();
                    state.LoadContent();
                    state.Initialize();
                    break;
                case EGameState.Credits:
                    state = new Credits();
                    state.LoadContent();
                    state.Initialize();
                    break;
                default:
                    break;
            }
        }

        void Update()
        {
            gTime.Update();

            if (prev != curr)
            {
                HandleGameState();
                prev = curr;
            }

            window.Clear();
            curr = state.Update(window, gTime);
            window.Display();

        }
    }
}
