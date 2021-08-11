using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Points
    {
        Text text;
        Font font;
        public Points(int Puntaje) { 
            font = new Font("Font//emulogic.ttf");
            text = new Text("Score\n" + Convert.ToString(Puntaje), font);
            text.Position = (new Vector2f(480f, 170f));
            text.Scale = new Vector2f(0.5f, 0.5f);
        }
        public void Draw(RenderWindow window) {
            window.Draw(text);
        }
    }
}
