using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Enemy : IColisionable
    {
        enum Status { Idle, MovingRight, MovingLeft, MovingUp, MovingDown, Vulnerable }
        private float speed;
        protected Sprite sprite;
        protected Texture texture;
        private List<List<Vector2i>> animations;
        public bool toDelete = false;
        protected Vector2f position;
        
        private IntRect frameRect;
        private int sheetColumns = 3;
        private int sheetRows = 4;
        private float animTime = 5;
        private Clock frameTimer;
        private int currentFrame = 0;
        private Status status;
        public Enemy(string TexturePath, Vector2f startPosition) {
            status = Status.Idle;
            texture = new Texture(TexturePath);
            sprite = new Sprite(texture);
            speed = 110.0f;
            position = startPosition;
            sprite.Position = startPosition;
            sprite.Scale = new Vector2f(1.8f, 1.8f);
            CollisionManager.GetInstance().AddToCollisionManager(this);
            
            frameRect = new IntRect();
            frameRect.Width = (int)texture.Size.X / sheetColumns;
            frameRect.Height = (int)texture.Size.Y / sheetRows;
            sprite.TextureRect = frameRect;
            frameTimer = new Clock();
            animations = new List<List<Vector2i>>();
            animations.Add(new List<Vector2i>());
            animations.Add(new List<Vector2i>());
            animations.Add(new List<Vector2i>());
            animations.Add(new List<Vector2i>());
            animations.Add(new List<Vector2i>());
            animations.Add(new List<Vector2i>());

            animations[(int)Status.Idle].Add(new Vector2i(0, 0));

            animations[(int)Status.MovingRight].Add(new Vector2i(0, 0));
            animations[(int)Status.MovingRight].Add(new Vector2i(1, 0));

            animations[(int)Status.MovingLeft].Add(new Vector2i(2, 0));
            animations[(int)Status.MovingLeft].Add(new Vector2i(1, 0));

            animations[(int)Status.MovingUp].Add(new Vector2i(1, 1));
            animations[(int)Status.MovingUp].Add(new Vector2i(1, 2));

            animations[(int)Status.MovingDown].Add(new Vector2i(2, 0));
            animations[(int)Status.MovingDown].Add(new Vector2i(2, 1));

            animations[(int)Status.Vulnerable].Add(new Vector2i(2, 2));
            animations[(int)Status.Vulnerable].Add(new Vector2i(3, 1));
            animations[(int)Status.Vulnerable].Add(new Vector2i(3, 0));
            animations[(int)Status.Vulnerable].Add(new Vector2i(3, 2));
        }
        public void Update()
        {
            UpdateAnimation();
        }
        public void UpdateAnimation()
        {
            switch (status)
            {
                case Status.Idle:
                    currentFrame = 0;
                    frameRect.Left = animations[(int)Status.Idle][currentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.Idle][currentFrame].Y * frameRect.Height;
                    break;
                case Status.MovingRight:
                    position.X += speed * FrameRate.GetDeltaTime();
                    animTime = 0.5f;
                    if (frameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.MovingRight].Count)
                    {
                        currentFrame++;
                        if (currentFrame == animations[(int)Status.MovingRight].Count - 1)
                        {
                            currentFrame = 0;
                        }
                        frameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.MovingRight][currentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.MovingRight][currentFrame].Y * frameRect.Height;
                    break;
                case Status.MovingLeft:
                    position.X -= speed * FrameRate.GetDeltaTime();
                    animTime = 0.5f;
                    if (frameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.MovingLeft].Count)
                    {
                        currentFrame++;
                        if (currentFrame == animations[(int)Status.MovingLeft].Count - 1)
                        {
                            currentFrame = 0;
                        }
                        frameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.MovingLeft][currentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.MovingLeft][currentFrame].Y * frameRect.Height;
                    break;
                case Status.MovingUp:
                    position.Y -= speed * FrameRate.GetDeltaTime();
                    animTime = 0.5f;
                    if (frameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.MovingUp].Count)
                    {
                        currentFrame++;
                        if (currentFrame == animations[(int)Status.MovingUp].Count - 1)
                        {
                            currentFrame = 0;
                        }
                        frameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.MovingUp][currentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.MovingUp][currentFrame].Y * frameRect.Height;
                    break;
                case Status.MovingDown:
                    position.Y += speed * FrameRate.GetDeltaTime();
                    animTime = 0.5f;
                    if (frameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.MovingDown].Count)
                    {
                        currentFrame++;
                        if (currentFrame == animations[(int)Status.MovingDown].Count - 1)
                        {
                            currentFrame = 0;
                        }
                        frameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.MovingDown][currentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.MovingDown][currentFrame].Y * frameRect.Height;
                    break;
                case Status.Vulnerable:
                    animTime = 0.5f;
                    if (frameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.Vulnerable].Count)
                    {
                        currentFrame++;
                        if (currentFrame == animations[(int)Status.Vulnerable].Count - 1)
                        {
                            currentFrame = 0;
                        }
                        frameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.Vulnerable][currentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.Vulnerable][currentFrame].Y * frameRect.Height;
                    break;
            }
            sprite.TextureRect = frameRect;
            sprite.Position = position;
        }
        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
        }
        public FloatRect GetBounds()
        {
            return sprite.GetGlobalBounds();
        }
        public void DeleteNow()
        {
            CollisionManager.GetInstance().RemoveFromCollisionManager(this);
            sprite.Dispose();
            texture.Dispose();

        }
        public Vector2f GetPosition() {
            return position;
        }
        public void CheckGarbash()
        {

        }
        public void OnCollision(IColisionable other)
        {
            if (other is Player)
            {
                Console.WriteLine("Colisiono");
            }
            if (other is Wall) {
                if (status == Status.MovingRight)
                {
                    position.X -= speed * FrameRate.GetDeltaTime() + 1;
                    status = Status.MovingRight;
                }
                if (status == Status.MovingLeft)
                {
                    position.X += speed * FrameRate.GetDeltaTime() + 1;
                }
                if (status == Status.MovingUp)
                {
                    position.Y += speed * FrameRate.GetDeltaTime() + 1;
                }
                if (status == Status.MovingDown)
                {
                    position.Y -= speed * FrameRate.GetDeltaTime() + 1;
                }
            }
        }
    }
}
