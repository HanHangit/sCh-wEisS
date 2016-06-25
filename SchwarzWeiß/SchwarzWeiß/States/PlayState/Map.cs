using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchwarzWeiß
{

    enum EMapTile
    {
        None = -1,
        Wall,
        Floor
    }

    class Map
    {

        EMapTile[,] intMap;
        Vector2u size;
        uint tilesize;
        Color[,] spriteMap;
        Sprite sprite;

        public Map()
        {
            tilesize = 24;
            size = ObjectHandler.winSize / tilesize;
            intMap = new EMapTile[size.X, size.Y];
            spriteMap = new Color[size.X, size.Y];
            Console.WriteLine("Constructor");
            generateMap();
        }

        void generateMap()
        {
            float chance = 0.05f;
            Random rnd = new Random();

            for(int i = 0; i < size.X; ++i)
                for(int j = 0; j < size.Y; ++j)
            {
                    if (i == 0 || j == 0 || i == size.X - 1 || j == size.Y - 1)
                        intMap[i, j] = EMapTile.Wall;
                    else if (rnd.NextDouble() < chance)
                    {
                        intMap[i, j] = EMapTile.Wall;

                    }
                    else
                        intMap[i, j] = EMapTile.Floor;
            }

            

            buildMap();

        }

        void buildMap()
        {
            for(int i = 0; i < size.X; ++i)
                for(int j = 0; j < size.Y; ++j)
                {
                    
                   
                    
                    if (intMap[i, j] == EMapTile.Floor)
                        spriteMap[i, j] = Color.Blue;
                    else
                        spriteMap[i, j] = Color.Black;
                }

            sprite = new Sprite(new Texture(new Image(spriteMap)));
            sprite.Scale = new Vector2f(tilesize, tilesize);

        }

        public void Update(RenderWindow win, GameTime gTime)
        {
            win.Draw(sprite);
            if (Keyboard.IsKeyPressed(Keyboard.Key.F5))
                generateMap();
        }

    }
}
