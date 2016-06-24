﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using SFML.Audio;

namespace SchwarzWeiß
{
    class Program
    {

        static void OnClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        static void Main()
        {
            // Create the main window
            RenderWindow app = new RenderWindow(new VideoMode(800, 600), "SFML Works!");
            app.Closed += new EventHandler(OnClose);

            Color windowColor = new Color(0, 192, 255);

            // Start the game loop
            while (app.IsOpen)
            {
                // Process events
                app.DispatchEvents();

                // Clear screen
                app.Clear(windowColor);

                // Update the window
                app.Display();
            } //End game loop
        } //End Main()
    }
}
