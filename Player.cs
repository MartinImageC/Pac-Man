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

    class Player : GameObjectBase, IColisionable
    {
        enum Status { Idle, MovingRight, MovingLeft, MovingUp, MovingDown, Die }
        enum LifeCounter {TresVidas, DosVidas, UnaVida}

        public List<Seeds> indexToRemove = new List<Seeds>();
        private List<List<Vector2i>> animations;
        private float speed;
        protected Sprite spriteV;
        protected Texture textureV;
        public int vidas;
        private IntRect frameRect;
        private IntRect frameRect2;
        private int sheetColumns = 4;
        private int sheetRows = 5;
        private int sheetColumnsV = 1;
        private int sheetRowsV = 3;
        private float animTime = 5;
        private Clock frameTimer;
        private int currentFrame = 0;
        private Status status;
        private LifeCounter lifeCounter;
        private Points puntaje;
        int currentPuntaje = 0;
        public Player() : base("Sprites//PacMan.png", new Vector2f(290f, 270f)) {
            toDelete = false;
            puntaje = new Points(currentPuntaje);
            textureV = new Texture("Sprites//Vidas.png");
            spriteV = new Sprite(textureV);
            speed = 100.0f;
            vidas = 3;
            lifeCounter = LifeCounter.TresVidas;
            spriteV.Position = new Vector2f(480f,300f);
            sprite.Scale = new Vector2f(1.4f,1.4f);
            spriteV.Scale = new Vector2f(1.5f,1.5f);
            CollisionManager.GetInstance().AddToCollisionManager(this);
            frameRect = new IntRect();
            frameRect.Width = (int)texture.Size.X / sheetColumns;
            frameRect.Height = (int)texture.Size.Y / sheetRows;
            sprite.TextureRect = frameRect;
            frameRect2 = new IntRect();
            frameRect2.Width = (int)textureV.Size.X / sheetColumnsV;
            frameRect2.Height = (int)textureV.Size.Y / sheetRowsV;
            spriteV.TextureRect = frameRect2;
            frameTimer = new Clock();
            animations = new List<List<Vector2i>>();
            animations.Add(new List<Vector2i>());
            animations.Add(new List<Vector2i>());
            animations.Add(new List<Vector2i>());
            animations.Add(new List<Vector2i>());
            animations.Add(new List<Vector2i>());
            animations.Add(new List<Vector2i>());
            animations.Add(new List<Vector2i>());

            animations[(int)Status.Idle].Add(new Vector2i(0,0));
            
            animations[(int)Status.MovingRight].Add(new Vector2i(0, 0));
            animations[(int)Status.MovingRight].Add(new Vector2i(1, 0));
            animations[(int)Status.MovingRight].Add(new Vector2i(2, 0));
            animations[(int)Status.MovingRight].Add(new Vector2i(1, 0));

            animations[(int)Status.MovingLeft].Add(new Vector2i(0, 0));
            animations[(int)Status.MovingLeft].Add(new Vector2i(3, 0));
            animations[(int)Status.MovingLeft].Add(new Vector2i(0, 1));
            animations[(int)Status.MovingLeft].Add(new Vector2i(3, 0));
        
            animations[(int)Status.MovingUp].Add(new Vector2i(0, 0));
            animations[(int)Status.MovingUp].Add(new Vector2i(1, 1));
            animations[(int)Status.MovingUp].Add(new Vector2i(2, 1));
            animations[(int)Status.MovingUp].Add(new Vector2i(1, 1));

            animations[(int)Status.MovingDown].Add(new Vector2i(0, 0));
            animations[(int)Status.MovingDown].Add(new Vector2i(3, 1));
            animations[(int)Status.MovingDown].Add(new Vector2i(0, 2));
            animations[(int)Status.MovingDown].Add(new Vector2i(3, 1));

            animations[(int)Status.Die].Add(new Vector2i(1, 2));
            animations[(int)Status.Die].Add(new Vector2i(2, 2));
            animations[(int)Status.Die].Add(new Vector2i(3, 2));
            animations[(int)Status.Die].Add(new Vector2i(0, 3));
            animations[(int)Status.Die].Add(new Vector2i(1, 3));
            animations[(int)Status.Die].Add(new Vector2i(2, 3));
            animations[(int)Status.Die].Add(new Vector2i(3, 3));
            animations[(int)Status.Die].Add(new Vector2i(0, 4));
            animations[(int)Status.Die].Add(new Vector2i(1, 4));
            animations[(int)Status.Die].Add(new Vector2i(2, 4));

            animations[(int)LifeCounter.TresVidas].Add(new Vector2i(0, 0));
            animations[(int)LifeCounter.DosVidas].Add(new Vector2i(1, 0));
            animations[(int)LifeCounter.UnaVida].Add(new Vector2i(2, 0));
        }

        public void UpdateAnimation()
        {
            switch (status) {
                case Status.MovingRight:
                    animTime = 0.5f;
                    if (frameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.MovingRight].Count)
                    {
                        currentFrame++;
                        if (currentFrame >= animations[(int)Status.MovingRight].Count-1)
                        {
                            currentFrame = 0;
                        }
                        frameTimer.Restart();     
                    }
                    frameRect.Left = animations[(int)Status.MovingRight][currentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.MovingRight][currentFrame].Y * frameRect.Height;
                    break;
                case Status.MovingLeft:
                    animTime = 0.5f;
                    if (frameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.MovingLeft].Count)
                    {
                        currentFrame++;
                        if (currentFrame >= animations[(int)Status.MovingLeft].Count - 1)
                        {
                            currentFrame = 0;
                        }
                        frameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.MovingLeft][currentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.MovingLeft][currentFrame].Y * frameRect.Height;
                    break;
                case Status.MovingUp:
                    animTime = 0.5f;
                    if (frameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.MovingUp].Count)
                    {
                        currentFrame++;
                        if (currentFrame >= animations[(int)Status.MovingUp].Count - 1)
                        {
                            currentFrame = 0;
                        }
                        frameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.MovingUp][currentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.MovingUp][currentFrame].Y * frameRect.Height;
                    break;
                case Status.MovingDown:
                    animTime = 0.5f;
                    if (frameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.MovingDown].Count)
                    {
                        currentFrame++;
                        if (currentFrame >= animations[(int)Status.MovingDown].Count - 1)
                        {
                            currentFrame = 0;
                        }
                        frameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.MovingDown][currentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.MovingDown][currentFrame].Y * frameRect.Height;
                    break;
                case Status.Idle:
                    currentFrame = 0;
                    frameRect.Left = animations[(int)Status.Idle][currentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.Idle][currentFrame].Y * frameRect.Height;
                    break;
                case Status.Die:
                    animTime = 0.5f;
                    if (frameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.Die].Count)
                    {
                        currentFrame++;
                        if (currentFrame >= animations[(int)Status.Die].Count - 1)
                        {
                            currentFrame = 0;
                        }
                        frameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.Die][currentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.Die][currentFrame].Y * frameRect.Height;
                    vidas--;
                    lifeCounter = LifeCounter.DosVidas;
                    break;
            }
            switch (lifeCounter) {
                case LifeCounter.DosVidas:
                    animTime = 0.5f;
                    if (frameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)LifeCounter.DosVidas].Count)
                    {
                        currentFrame++;
                        if (currentFrame == animations[(int)LifeCounter.DosVidas].Count - 1)
                        {
                            currentFrame = 0;
                        }
                        frameTimer.Restart();
                    }
                    frameRect2.Left = animations[(int)LifeCounter.DosVidas][currentFrame].X * frameRect2.Width;
                    frameRect2.Top = animations[(int)LifeCounter.DosVidas][currentFrame].Y * frameRect2.Height;
                    break;
                case LifeCounter.UnaVida:
                    animTime = 0.5f;
                    if (frameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)LifeCounter.UnaVida].Count)
                    {
                        currentFrame++;
                        if (currentFrame == animations[(int)LifeCounter.UnaVida].Count - 1)
                        {
                            currentFrame = 0;
                        }
                        frameTimer.Restart();
                    }
                    frameRect2.Left = animations[(int)LifeCounter.UnaVida][currentFrame].X * frameRect2.Width;
                    frameRect2.Top = animations[(int)LifeCounter.UnaVida][currentFrame].Y * frameRect2.Height;
                    sprite.Position = currentPosition;
                    break;
            }
            spriteV.TextureRect = frameRect2;
            sprite.TextureRect = frameRect;
        }
        public override void Draw(RenderWindow window) {
            base.Draw(window);
            puntaje.Draw(window);
            window.Draw(spriteV);
        }
        public override void CheckGarbash() { }
        public override void Update() {
            Movement();
            UpdateAnimation();
            base.Update();
        }
        private void Movement()
        {
            if (!Keyboard.IsKeyPressed(Keyboard.Key.Right) && !Keyboard.IsKeyPressed(Keyboard.Key.Left) && !Keyboard.IsKeyPressed(Keyboard.Key.Up) && !Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                status = Status.Idle;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                currentPosition.X += speed * FrameRate.GetDeltaTime();
                status = Status.MovingRight;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                currentPosition.X -= speed * FrameRate.GetDeltaTime();
                status = Status.MovingLeft;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                currentPosition.Y -= speed * FrameRate.GetDeltaTime();
                status = Status.MovingUp;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                currentPosition.Y += speed * FrameRate.GetDeltaTime();
                status = Status.MovingDown;
            }
            bool isMovingH = !Keyboard.IsKeyPressed(Keyboard.Key.Right) && !Keyboard.IsKeyPressed(Keyboard.Key.Left);
            bool isMovingV = !Keyboard.IsKeyPressed(Keyboard.Key.Up) && !Keyboard.IsKeyPressed(Keyboard.Key.Down);
            if (isMovingH && isMovingV) {
                status = Status.Idle;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.P))
            {
                FrameRate.SetTimeScale(0.0f);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                FrameRate.SetTimeScale(1.0f);
            }
        }
        public override void DeleteNow()
        {
            CollisionManager.GetInstance().RemoveFromCollisionManager(this);
            base.DeleteNow();
        }
        public FloatRect GetBounds()
        {
            return sprite.GetGlobalBounds();
        }
        public void OnCollision(IColisionable other)
        {
            if (other is Wall) {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                {
                    currentPosition.X -= speed * FrameRate.GetDeltaTime();
                    status = Status.MovingRight;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                {
                    currentPosition.X += speed * FrameRate.GetDeltaTime();
                    status = Status.MovingLeft;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                    currentPosition.Y += speed * FrameRate.GetDeltaTime();
                    status = Status.MovingUp;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                {
                    currentPosition.Y -= speed * FrameRate.GetDeltaTime();
                    status = Status.MovingDown;
                }
            }
            if (other is Seeds)
            {
                currentPuntaje += 50;
            }
            if (other is Enemy) {
                status = Status.Die;
            }
        }
    }
}
