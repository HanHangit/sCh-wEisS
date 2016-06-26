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
        Text player1Carry;

        Text player2Score;
        Text player2SchweißText;
        Text player2Carry;
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
           player1SchweißText.DisplayedString = (" \t\tSchweiS: " + ObjectHandler.player1.sweatlevel.ToString());
            player1Score.DisplayedString = "Player1 - Score: " + ObjectHandler.player1.score.ToString();
            player1Carry.DisplayedString = " \t\t\tCarry: " + ObjectHandler.player1.carry.ToString() + " / " + 6;

            player2SchweißText.DisplayedString = (" \t\tSchweiS: " + ObjectHandler.player2.sweatlevel.ToString());
            player2Score.DisplayedString = "Player2 - Score: " + ObjectHandler.player2.score.ToString();
            player2Carry.DisplayedString = " \t\t\tCarry: " + ObjectHandler.player2.carry.ToString() + " / " + 6;
        }
        void Player1Init()
        {
            font = new Font("Thunder Strike.ttf");
     
            player1SchweißText = new Text(" \t\tSchweiS: " + ObjectHandler.player1.sweatlevel.ToString(), font);
            player1Score = new Text("Player1 - Score: " + ObjectHandler.player1.score.ToString(), font);
            player2SchweißText = new Text(" \t\tSchweiS: " + ObjectHandler.player2.sweatlevel.ToString(), font);
            player2Score = new Text("Player2 - Score: " + ObjectHandler.player2.score.ToString(), font);

            player1Carry = new Text(" \t\t\tCarry: " + ObjectHandler.player1.carry.ToString() + " / " + 6, font);
            player2Carry = new Text(" \t\t\tCarry: " + ObjectHandler.player2.carry.ToString() + " / " + 6, font);

            player1Score.Position = new Vector2f(10, 10);
            player1Carry.Position = new Vector2f(10, 40);
            player1SchweißText.Position = new Vector2f(10, 70);

            player2Score.Position = new Vector2f(1000, 10);
            player2Carry.Position = new Vector2f(10, 40);
            player2SchweißText.Position = new Vector2f(1000, 70);

        }
        void Player2Init()
        {

        }
        public void Render(RenderWindow win)
        {
            win.Draw(player1Score);
            win.Draw(player1SchweißText);
            win.Draw(player1Carry);

            win.Draw(player2Score);
            win.Draw(player2SchweißText);
            win.Draw(player2Carry);
        }
    }
}
