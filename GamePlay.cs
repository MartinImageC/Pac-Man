using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum Stats { Normal, PowerUp }
    class GamePlay
    {
        private Player player;
        private Level level;
        private Enemy Red;
        private Enemy Pink;
        private Enemy Blue;
        private Enemy Orange;
        public GamePlay() {
            player = new Player();
            Red = new Enemy("Sprites//Red.png", new Vector2f(275f, 165f));
            Pink = new Enemy("Sprites//Pink.png", new Vector2f(280f, 165f));
            Blue = new Enemy("Sprites//Blue.png", new Vector2f(290f, 165f));
            Orange = new Enemy("Sprites//Orange.png", new Vector2f(300f, 165f));
            level = new Level();
        }
        public void Update()
        {
            if (player != null)
            {
                player.Update();
            }
            if (Red != null) {
                Red.Update();
            }
            if (Pink != null)
            {
                Pink.Update();
            }
            if (Blue != null)
            {
                Blue.Update();
            }
            if (Blue != null)
            {
                Blue.Update();
            }
        }
        public void Draw(RenderWindow window)
        {
            level.Draw(window);
            if (player != null)
            {
                player.Draw(window);
            }
            if (Red != null)
            {
                Red.Draw(window);
            }
            if (Pink != null)
            {
                Pink.Draw(window);
            }
            if (Blue != null)
            {
                Blue.Draw(window);
            }
            if (Orange != null)
            {
                Orange.Draw(window);
            }
        }
       // private void DeletePhantom()
       // {
       //     Stats state = new Stats();
       //     switch (state)
       //     {
       //         case Stats.Normal:
       //             player.vidas--;
       //             break;
       //         case Stats.PowerUp:
       //             CollisionManager.GetInstance().CheckCollisions();
       //             break;
       //     }
       // }
        public void CheckGarbash()
        {
            if (player != null)
            {
                player.CheckGarbash();
                level.CheckGarbash();
                if (player.toDelete)
                {
                    player = null;
                }
            }
            if (Red != null)
            {
                Red.CheckGarbash();
                if (Red.toDelete)
                {
                    Red = null;
                }
            }
            if (Pink != null)
            {
                Pink.CheckGarbash();
                if (Pink.toDelete)
                {
                    Pink = null;
                }
            }
            if (Blue != null)
            {
                Blue.CheckGarbash();
                if (Blue.toDelete)
                {
                    Blue = null;
                }
            }
            if (Orange != null)
            {
                Orange.CheckGarbash();
                if (Orange.toDelete)
                {
                    Orange = null;
                }
            }
        }
    }
}
