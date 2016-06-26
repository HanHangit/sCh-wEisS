using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SchwarzWeiß
{
    enum EMapTile
    {
        None,
        Wall,
        Floor
    }

    enum EMapType
    {
        Standard,
        Rekursiv
    }

    class Map
    {

        EMapTile[,] intMap;
        EMapType typeMap;
        Vector2u size;
        uint tilesize;
        Color[,] spriteMap;
        Sprite sprite;

        public Map()
        {
            typeMap = EMapType.Rekursiv;
            tilesize = 24;
            size = ObjectHandler.winSize / tilesize;
            spriteMap = new Color[size.X, size.Y];
            Console.WriteLine("Constructor");
            generateMap();
        }

        void generateStandard()
        {
            float chance = 0.01f;
            Random rnd = new Random();
            intMap = new EMapTile[size.X, size.Y];

            for (int i = 0; i < size.X; ++i)
                for (int j = 0; j < size.Y; ++j)
                {
                    if (intMap[i, j] == EMapTile.None)
                    {
                        if (i == 0 || j == 0 || i == size.X - 1 || j == size.Y - 1)
                            intMap[i, j] = EMapTile.Wall;
                        else if (rnd.NextDouble() < chance)
                        {
                            intMap[i, j] = EMapTile.Wall;

                            if (i > 0)
                                intMap[i - 1, j] = EMapTile.Wall;

                            if (j > 0)
                                intMap[i, j - 1] = EMapTile.Wall;

                            if (i < size.X - 1)
                                intMap[i + 1, j] = EMapTile.Wall;

                            if (j < size.Y - 1)
                                intMap[i, j + 1] = EMapTile.Wall;


                        }
                        else
                            intMap[i, j] = EMapTile.Floor;


                    }
                }
        }

        void generateRekursiv()
        {
            intMap = new EMapTile[size.X, size.Y];

            for (int i = 0; i < size.X; ++i)
                for (int j = 0; j < size.Y; ++j)
                    intMap[i, j] = EMapTile.Floor;

            slideMap((int)size.Y / 2 , 1, (int)size.X - 1, (int)size.X / 2, 1, (int)size.Y - 1);



        }

        void slideMap(int horz, int hStart, int hEnd, int vert, int vStart, int vEnd)
        {
            Console.WriteLine(horz + "|" + hStart + "|" + hEnd + "|" + vert + "|" + vStart + "|" + vEnd);
            if (hEnd - hStart < 2 || vEnd - vStart < 2)
                return;
            if (vStart >= horz || vEnd <= horz || hStart >= vert || hEnd <= vert)
                return;

            Random rnd = new Random();
            int[] noDoor = new int[2];

            for (int i = hStart; i < hEnd; ++i)
                intMap[i, horz] = EMapTile.Wall;
            for (int j = vStart; j < vEnd; ++j)
            {
                if (intMap[vert, j] == EMapTile.Wall)
                {
                    noDoor[0] = vert;
                    noDoor[1] = j;
                }
                else
                    intMap[vert, j] = EMapTile.Wall;

            }

            int[] placeDoor = new int[4];
            placeDoor[0] = (vStart + noDoor[1]) / 2;
            placeDoor[1] = (noDoor[1] + 1 + vEnd) / 2;
            placeDoor[2] = (hStart + noDoor[0]) / 2;
            placeDoor[3] = (noDoor[0] + 1 + hEnd) / 2;

            intMap[vert, placeDoor[0]] = EMapTile.Floor;
            intMap[vert, placeDoor[1]] = EMapTile.Floor;
            intMap[placeDoor[2], horz] = EMapTile.Floor;
            intMap[placeDoor[3], horz] = EMapTile.Floor;

            /*
            int nextVert1 = rnd.Next(vStart + 1, vert);
            int nextVert2 = rnd.Next(vert + 1, vEnd);
            int nextVert3 = rnd.Next(vStart + 1, vert);
            int nextVert4 = rnd.Next(vert + 1, vEnd);
            int nextHorz1 = rnd.Next(vStart + 1, horz);
            int nextHorz2 = rnd.Next(horz + 1, vEnd);
            int nextHorz3 = rnd.Next(vStart + 1, horz);
            int nextHorz4 = rnd.Next(horz + 1, vEnd);
            */

            int nextVert1 = (vStart + noDoor[1]) / 2;
            int nextVert2 = (noDoor[1] + hEnd) / 2;
            int nextVert3 = (hStart + noDoor[1]) / 2;
            int nextVert4 = (noDoor[1] + hEnd) / 2;
            int nextHorz1 = (vStart + noDoor[0]) / 2;
            int nextHorz2 = (noDoor[0] + vEnd) / 2;
            int nextHorz3 = (vStart + noDoor[0]) / 2;
            int nextHorz4 = (noDoor[0] + vEnd) / 2;

            //slideMap(nextHorz1, hStart, noDoor[1], nextVert1, vStart, noDoor[0]);
            slideMap(nextHorz2, noDoor[1], hEnd, nextVert2,  noDoor[0], vEnd);
            //slideMap(nextHorz3, hStart, horz, nextVert3, vert, vEnd);
            //slideMap(nextHorz4, horz, hEnd, nextVert4, vert, vEnd);



        }

        void generateMap()
        {

            switch (typeMap)
            {
                case EMapType.Standard:
                    generateStandard();
                    break;
                case EMapType.Rekursiv:
                    generateRekursiv();
                    break;
            }


            buildMap();

        }

        void buildMap()
        {
            for (int i = 0; i < size.X; ++i)
                for (int j = 0; j < size.Y; ++j)
                {



                    if (intMap[i, j] == EMapTile.Floor)
                        spriteMap[i, j] = Color.Blue;
                    else
                        spriteMap[i, j] = Color.Black;
                }



            sprite = new Sprite(new Texture(new Image(spriteMap)));
            sprite.Scale = new Vector2f(tilesize, tilesize);

        }

        public bool walkable(Vector2f position)
        {
            Vector2u pos = (Vector2u)position / tilesize;
            if (intMap[pos.X, pos.Y] != EMapTile.Floor)
                return false;
            else
                return true;
        }

        public void Update(RenderWindow win, GameTime gTime)
        {
            win.Draw(sprite);
            if (Keyboard.IsKeyPressed(Keyboard.Key.F5))
                generateMap();
        }

    }
}
