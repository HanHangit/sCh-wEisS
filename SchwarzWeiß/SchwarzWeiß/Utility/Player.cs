﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using SFML.Audio;

namespace SchwarzWeiß
{

    enum EPlayer
    {
        Player1,
        Player2
    }

    class Player : Collider
    {
        Vector2f moveDirection;
        Image image;
        public Texture texture;
        Sprite sprite;

        Text txt;
        Font font;

        EPlayer mType;

        public float sweatlevel { get; set; }
        public int capacity { get; set; }
        public int carry { get; set; }
        public int score { get; private set; }
        public float speed { get; set; }
        public int weaponnr { get; set; }
        public int weapontime { get; set; }
        //0 - keine; 1 - stock; 2 - other

        public Vector2f home;
        public Vector2f position { get; private set; }
        public Vector2u size { get; private set; }


        public Player(EPlayer playernum, string str, Image img, Vector2f pos)
        {

            weapontime = 0;
            weaponnr = 0;
            score = 0;
            carry = 0;
            capacity = 6;
            sweatlevel = 0;
            image = new Image(img);
            texture = new Texture(image);
            sprite = new Sprite(texture);
            sprite.Position = new Vector2f(pos.X, pos.Y);
            size = sprite.Texture.Size;
            home = sprite.Position;
            mType = playernum;
            font = new Font("arialbd.ttf");
            txt = new Text(str, font);
            speed = 0.5f;
        }

        public Boolean PlayerToPlayerCollision()
        {
            Player p1 = ObjectHandler.player1;
            Player p2 = ObjectHandler.player2;
            if (Collision<Player, Player>.CheckColission(p1, p2))
            {
                if (p1.weaponnr == 1 && p2.weaponnr == 1)
                {

                    p1.weaponnr = 0;
                    p2.weaponnr = 0;

                }
                else if (ObjectHandler.player1.weaponnr == 1)
                {

                    p2.carry = 0;
                    p2.sprite.Position = p2.home;

                }
                else if (ObjectHandler.player2.weaponnr == 1)
                {

                    p1.carry = 0;
                    p1.sprite.Position = p1.home;

                }
                return true;
            }
            return false;
        }

        public void PlayerToHomeCollision()
        {
            if (Collision<Player, Player>.CheckCollision(sprite.Position, size, home, new Vector2u(15, 15)))
            {
                if (mType == EPlayer.Player1)
                    if (mType == EPlayer.Player2)
                        score += carry;
                carry = 0;
            }
        }

        public EPlayer getType()
        {
            return mType;
        }

        void Move(GameTime gTime)
        {

            Vector2f nextMove = moveDirection * speed * gTime.Ellapsed.Milliseconds;
            Vector2f leftTop = sprite.Position + nextMove;
            Vector2f rightTop = sprite.Position + new Vector2f(sprite.Texture.Size.X, 0) + nextMove;
            Vector2f leftBottom = sprite.Position + new Vector2f(0, sprite.Texture.Size.Y) + nextMove;
            Vector2f RightBottom = sprite.Position + (Vector2f)sprite.Texture.Size + nextMove;

            /*
            if(!ObjectHandler.map.walkable(leftTop) && !ObjectHandler.map.walkable(rightTop))
            {
                moveDirection.Y = 0;
            }

            if (!ObjectHandler.map.walkable(leftTop) && !ObjectHandler.map.walkable(leftBottom))
            {
                moveDirection.X = 0;
            }

            if (!ObjectHandler.map.walkable(leftBottom) && !ObjectHandler.map.walkable(RightBottom))
            {
                moveDirection.Y = 0;
            }

            if (!ObjectHandler.map.walkable(RightBottom) && !ObjectHandler.map.walkable(rightTop))
            {
                moveDirection.X = 0;
            }
            */


            if(ObjectHandler.map.walkable(leftTop)
                && ObjectHandler.map.walkable(leftBottom)
                && ObjectHandler.map.walkable(rightTop)
                && ObjectHandler.map.walkable(RightBottom))
            {
                sprite.Position += moveDirection * speed * gTime.Ellapsed.Milliseconds;
            }
        }

        void KeyboardInput()
        {
            //TEST
            if (Keyboard.IsKeyPressed(Keyboard.Key.M))
            {
                sweatlevel++;
            }
            moveDirection = new Vector2f(0, 0);
            if (mType == EPlayer.Player1)
            {

                if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                    moveDirection += new Vector2f(-1, 0);
                if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                    moveDirection += new Vector2f(0, -1);
                if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                    moveDirection += new Vector2f(1, 0);
                if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                    moveDirection += new Vector2f(0, 1);

                moveDirection = MVec.normalize(moveDirection);
            }
            if (mType == EPlayer.Player2)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                    moveDirection += new Vector2f(-1, 0);
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                    moveDirection += new Vector2f(0, -1);
                if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                    moveDirection += new Vector2f(1, 0);
                if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                    moveDirection += new Vector2f(0, 1);

                moveDirection = MVec.normalize(moveDirection);
            }

        }

        public void CheckWeaponForImage()
        {
            if (ObjectHandler.player1.weaponnr != 0)
            {
                if (ObjectHandler.player1.weaponnr == 1)
                {
                    ObjectHandler.player1.sprite.Texture = new Texture(new Image("pictures/lolsmallstick.png"));
                }
            }
            else ObjectHandler.player1.sprite.Texture = new Texture(new Image("pictures/lolsmall.png"));

            if (ObjectHandler.player2.weaponnr != 0)
            {
                if (ObjectHandler.player2.weaponnr == 1)
                {
                    ObjectHandler.player2.sprite.Texture = new Texture(new Image("pictures/megustasmallstick.png"));
                }
            }
            else ObjectHandler.player2.sprite.Texture = new Texture(new Image("pictures/megustasmall.png"));
        }

        public void CheckScore()
        {
            //if (Level1.highscore == ObjectHandler.player1.score)
            // 
            //if (Level1.highscore == ObjectHandler.player2.score)

        }

        public void Update(RenderWindow win, GameTime gTime)
        {
            CheckScore();
            CheckWeaponForImage();

            Move(gTime);
            PlayerToHomeCollision();
            KeyboardInput();
            PlayerToPlayerCollision();
            bombHasBeenPlanted(win);
            win.Draw(sprite);
            DrawHud(win);

        }

        void bombHasBeenPlanted(RenderWindow win)
        {

            if (Keyboard.IsKeyPressed(Keyboard.Key.LControl) && weaponnr == 2)
            {
                Traps p = new Traps(sprite.Position);
                ObjectHandler.traplist.Add(p);
                weaponnr = 0;
            }
            for (int it = 0; it < ObjectHandler.traplist.Count; it++)
            {
                ObjectHandler.traplist[it].Update();
                ObjectHandler.traplist[it].Render(win);
                if (!(ObjectHandler.traplist[it].isAlive))
                {
                    ObjectHandler.traplist.RemoveAt(it);
                }
            }

        }

        void DrawHud(RenderWindow window)
        {
        }

        public Vector2f getPosition()
        {
            return sprite.Position;
        }

        public Vector2u getSize()
        {
            return sprite.Texture.Size;
        }
    }
}
