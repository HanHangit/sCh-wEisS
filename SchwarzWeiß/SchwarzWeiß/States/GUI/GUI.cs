using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;
using SFML.System;



namespace SchwarzWeiß
{
    class GUI
    {

        Text player1Score;
        Text player1SchweißText;

        Text player2Score;
        Text player2SchweißText;
        Font font;
        
        float mStep;

        public GUI()
        {
            mStep = ObjectHandler.player1.sweatlevel / 100;
            Player1Init();
            Player2Init();
        }
        public void Update()
        {
           player1SchweißText.DisplayedString = ("Player1 -  SchweiS: " + ObjectHandler.player1.sweatlevel.ToString());
            player1Score.DisplayedString = "Player1 - Score: " + ObjectHandler.player1.score.ToString();
        }
        void Player1Init()
        {
            font = new Font("Thunder Strike.ttf");
     
            player1SchweißText = new Text("Player1 -  SchweiS: " + ObjectHandler.player1.sweatlevel.ToString(), font);
            player1Score = new Text("Player1 - Score: " + ObjectHandler.player1.score.ToString(), font);
            player2SchweißText = new Text("Player2 -  SchweiS: " + ObjectHandler.player1.sweatlevel.ToString(), font);
            player2Score = new Text("Player2 - Score: " + ObjectHandler.player1.score.ToString(), font);

            player1Score.Position = new Vector2f(10, 10);
            player1SchweißText.Position = new Vector2f(10, 50);

            player2Score.Position = new Vector2f(1000, 10);
            player2SchweißText.Position = new Vector2f(1000, 50);

        }
        void Player2Init()
        {

        }
        public void Render(RenderWindow win)
        {
            win.Draw(player1Score);
            win.Draw(player1SchweißText);

            win.Draw(player2Score);
            win.Draw(player2SchweißText);
        }
    }
}
