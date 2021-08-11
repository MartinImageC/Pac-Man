using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Seeds : GameObjectBase, IColisionable
    {
        public Seeds(Vector2f position) : base("Sprites//NormalSeed.png", position)
        {
            sprite.Position = position;
            sprite.Scale = new Vector2f(3f,3f);
            CollisionManager.GetInstance().AddToCollisionManager(this);
        }

        public override void Draw(RenderWindow window) {
            base.Draw(window);
        }
        public override void CheckGarbash()
        {
        }

        public FloatRect GetBounds()
        {
            return sprite.GetGlobalBounds();
        }

        public void OnCollision(IColisionable other)
        {
            if (other is Player)
            {
                DeleteNow();
                MusicManager.GetInstance().Play(1);
            }
            else {
                MusicManager.GetInstance().Stop(1);
            }
        }
        public override void DeleteNow()
        {
            CollisionManager.GetInstance().RemoveFromCollisionManager(this);
            base.DeleteNow();
        }
    }
}
