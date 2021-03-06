﻿using SFML.Graphics;
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
        Floor,
        Base1,
        Base2
    }

    enum EMapType
    {
        Standard,
        Rekursiv
    }

    class Map
    {

        Image img;
        Texture background;
        Sprite bgr;
        EMapTile[,] intMap;
        public EMapType typeMap;
        Vector2u size;
        uint tilesize;
        Color[,] spriteMap;
        Sprite sprite;
        Random rnd = new Random();

        public Map()
        {
            img = new Image("pictures/grasstitlescreen.png");
            background = new Texture(img);
            bgr = new Sprite(background);
            tilesize = 8;
            size = ObjectHandler.winSize / tilesize;
            spriteMap = new Color[size.X, size.Y];
            generateMap();
        }

        void generateStandard()
        {
            float chance = 0.003f;
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

                            if (i > 0 && j > 0 && i < size.X - 1 && j < size.Y - 1)
                            {
                                intMap[i - 1, j] = EMapTile.Wall;
                                intMap[i, j - 1] = EMapTile.Wall;
                                intMap[i - 1, j - 1] = EMapTile.Wall;
                                intMap[i + 1, j] = EMapTile.Wall;
                                intMap[i, j + 1] = EMapTile.Wall;
                                intMap[i + 1, j + 1] = EMapTile.Wall;
                                intMap[i + 1, j - 1] = EMapTile.Wall;
                                intMap[i - 1, j + 1] = EMapTile.Wall;
                            }


                        }
                        else
                            intMap[i, j] = EMapTile.Floor;


                    }
                }
        }

        void FloorPlayerHome()
        {
            Vector2u home1 = (Vector2u)ObjectHandler.player1.home / tilesize;
            Vector2u home2 = (Vector2u)ObjectHandler.player2.home / tilesize;
            Console.WriteLine(home1.ToString());
            int place = 4;

            for (int i = (int)home1.X - place + 1; i < home1.X + place; ++i)
                for (int j = (int)home1.Y - place + 1; j < home1.Y + place; ++j)
                {
                    if (i > 0 && j > 0 && i < size.X - 1 && j < size.Y)
                        intMap[i, j] = EMapTile.Base1;
                }

            for (int i = (int)home2.X - place + 1; i < home2.X + place; ++i)
                for (int j = (int)home2.Y - place + 1; j < home2.Y + place; ++j)
                {
                    if (i > 0 && j > 0 && i < size.X - 1 && j < size.Y)
                        intMap[i, j] = EMapTile.Base2;
                }

        }

        void generateRekursiv()
        {
            intMap = new EMapTile[size.X, size.Y];

            for (int i = 0; i < size.X; ++i)
                for (int j = 0; j < size.Y; ++j)
                    intMap[i, j] = EMapTile.Floor;

            slideMap((int)size.Y / 2, 1, (int)size.X - 1, (int)size.X / 2, 1, (int)size.Y - 1);



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
            slideMap(nextHorz2, noDoor[1], hEnd, nextVert2, noDoor[0], vEnd);
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

            FloorPlayerHome();

            for (int i = 0; i < size.X; ++i)
                for (int j = 0; j < size.Y; ++j)
                {



                    if (intMap[i, j] == EMapTile.Floor)
                    {
                        spriteMap[i, j] = Color.Blue;
                        spriteMap[i, j].A = 0;
                    }
                    else if (intMap[i, j] == EMapTile.Base1)
                        spriteMap[i, j] = new Color(0,0,128,200);
                    else if (intMap[i, j] == EMapTile.Base2)
                        spriteMap[i, j] = new Color(205,0,0,200);
                    else
                    {
                        spriteMap[i, j] = new Color(110, 123, 139,220);
                    }
                }



            sprite = new Sprite(new Texture(new Image(spriteMap)));
            sprite.Scale = new Vector2f(tilesize, tilesize);

        }

        public bool walkable(Vector2f position)
        {
            Vector2u pos = (Vector2u)position / tilesize;
            try
            {
                if (intMap[pos.X, pos.Y] == EMapTile.Wall)
                    return false;
                else
                    return true;
            }
            catch(IndexOutOfRangeException)
            {
                return false;
            }
        }

        public bool onBase(Vector2f position)
        {
            Vector2u pos = (Vector2u)position / tilesize;
            if (intMap[pos.X, pos.Y] == EMapTile.Base1 || intMap[pos.X,pos.Y] == EMapTile.Base2)
                return true;
            else
                return false;
        }

        public void Update(RenderWindow win, GameTime gTime)
        {
            win.Draw(bgr);
            win.Draw(sprite);
            if (Keyboard.IsKeyPressed(Keyboard.Key.F5))
                generateMap();
        }

    }
}
