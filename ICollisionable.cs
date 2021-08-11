using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface IColisionable
    {
        public FloatRect GetBounds();
        public void OnCollision(IColisionable other);
    }
}
