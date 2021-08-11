using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Game{
        private RenderWindow window;
        private Menu menu;
        private GamePlay gamePlay;
        private static Vector2f windowSize;
        public Game()
        {
            VideoMode videoMode = new VideoMode();
            videoMode.Height = 372;
            videoMode.Width = 600;

            window = new RenderWindow(videoMode, "Pac-Man NES");
            window.Closed += CloseWindow;
            window.SetFramerateLimit(FrameRate.FRAMERATE_LIMIT);
            menu = new Menu();
            gamePlay = new GamePlay();
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            window.Close();
        }
        public bool UpdateWindow()
        {
            window.DispatchEvents();//Actualiza todo lo que pase con la ventana.(Moverla, minimizarla, maximizarla.)
            window.Clear(Color.Black);
            return window.IsOpen;
        }
        public void UpdateGame()
        {
            if (menu.GetCoin() == true)
            {
                gamePlay.Update();
            }
            else {
                menu.Update();
                menu.Start();
            }
            windowSize = window.GetView().Size;
        }

        public void DrawGame()
        {
            if (menu.GetCoin() == true)
            {
                gamePlay.Draw(window);
            }
            else
            {
                menu.Draw(window);
            }
            window.Display();//Indicar el momento en que se debe actualizar la pantalla.
        }
        public void CheckGarbash()
        {
            if (menu.GetCoin() == true)
            {
             gamePlay.CheckGarbash();
            }
        }
        public static Vector2f GetWindowSize()
        {
            return windowSize;
        }
    }
   
}
