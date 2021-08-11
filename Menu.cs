using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace ConsoleApp1
{
    class Menu
    {
        protected Vector2f position;
        Texture texture;
        Sprite sprite;
        private int credits = 0;
        private bool CanPlay = false;
        private IntRect frameRect;
        private int sheetColumns = 1;
        private int sheetRows = 2;
        private float animTime = 2;
        private Clock frameTimer;
        private int currentFrame;
        public Menu() {
            position = new Vector2f(50f,400f);
            texture = new Texture("Sprites//Title.png");
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f(1.7f, 1.8f);
            frameRect = new IntRect();
            frameRect.Width = (int)texture.Size.X / sheetColumns;
            frameRect.Height = (int)texture.Size.Y / sheetRows;
            sprite.TextureRect = frameRect;
            frameTimer = new Clock();
        }
        public void Update() {
            if (position.X >= 20f && position.Y >= 20f)
            {
                position.Y -= 150 * FrameRate.GetDeltaTime();
                sprite.Position = position;
            }
            else
            {
                sprite.Position = position;
                UpdateAnimation();
            }
        }
        public void UpdateAnimation()
        {
            animTime = 0.5f;
            if (frameTimer.ElapsedTime.AsSeconds() > animTime / sheetRows)
            {
                currentFrame++;
                if (currentFrame == sheetRows)
                {
                    currentFrame = 0;
                }
                frameTimer.Restart();
            }
            frameRect.Top = currentFrame * frameRect.Height;
            sprite.TextureRect = frameRect;
        }

        public void Draw(RenderWindow window) {
            window.Draw(sprite);
        }
        public void Start()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Num1))
            {
                credits += 1;
            }
            if (credits >= 1 && Keyboard.IsKeyPressed(Keyboard.Key.Enter))
            {
                MusicManager.GetInstance().Play(0);
                CanPlay = true;
            }
        }
        public bool GetCoin()
        {
            return CanPlay;
        }
    }
}
