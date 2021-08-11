using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Wall : IColisionable
    {
        private Vector2f position;
        private Vector2f size;
        public Wall(Vector2f position, Vector2f size)
        {
            this.position = position;
            this.size = size;
            CollisionManager.GetInstance().AddToCollisionManager(this);
        }

        public FloatRect GetBounds()
        {
            return new FloatRect(position, size);
        }

        public void OnCollision(IColisionable other)
        {
            
        }
    }
}
