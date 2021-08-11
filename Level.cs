using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Level : GameObjectBase
    {
        private List<Vector2i> levelanimation;
        private int sheetColumns = 2;
        private int sheetRows = 1;
        private float animTime = 5;
        private Clock frameTimer;
        private int currentFrame = 0;
        private IntRect frameRect;
        private bool Complete = false;
        private int level = 0;
        protected Sprite CounterSprite;
        protected Texture Countertexture;
        private List<Vector2i> animationCounter;
        private int sheetColumnsC = 3;
        private int sheetRowsC = 4;
        private float animTimeC = 5;
        private int currentFrameC = 0;
        private IntRect frameRectC;
        private Clock frameTimerC;
        private List<Seeds> seeds;
        public Level() : base("Sprites//Level.png", new Vector2f(130f, 0f)) {
            seeds = new List<Seeds>();
            sprite.Scale = new Vector2f(2f,1.7f);
            frameRect = new IntRect();
            frameRect.Width = (int)texture.Size.X / sheetColumns;
            frameRect.Height = (int)texture.Size.Y / sheetRows;
            sprite.TextureRect = frameRect;
            frameTimer = new Clock();
            levelanimation = new List<Vector2i>();
            levelanimation.Add(new Vector2i(0,0));
            levelanimation.Add(new Vector2i(0, 1));

            Countertexture = new Texture("Sprites//LevelCounter.png");
            CounterSprite = new Sprite(Countertexture);
            CounterSprite.Scale = new Vector2f(2f, 1.7f);
            CounterSprite.Position = new Vector2f(480f, 100f);
            frameRectC = new IntRect();
            frameRectC.Width = (int)Countertexture.Size.X / sheetColumnsC;
            frameRectC.Height = (int)Countertexture.Size.Y / sheetRowsC;
            CounterSprite.TextureRect = frameRectC;
            frameTimerC = new Clock();
            animationCounter = new List<Vector2i>();
            animationCounter.Add(new Vector2i(0, 0));
            animationCounter.Add(new Vector2i(1, 0));
            animationCounter.Add(new Vector2i(2, 0));
            animationCounter.Add(new Vector2i(0, 1));
            animationCounter.Add(new Vector2i(1, 1));
            animationCounter.Add(new Vector2i(2, 1));
            animationCounter.Add(new Vector2i(0, 2));
            animationCounter.Add(new Vector2i(1, 2));
            animationCounter.Add(new Vector2i(2, 2));
            animationCounter.Add(new Vector2i(0, 3));
            animationCounter.Add(new Vector2i(1, 3));
            animationCounter.Add(new Vector2i(2, 3));
            WallCreator();
            SeedGenerator();
        }
        public override void Update() {
            if (Complete) {
                level++;
                UpdateAnimation(level);
            }
        }
        public override void CheckGarbash()
        {
            List<int> indexToDelete = new List<int>();
            for (int i = 0; i < seeds.Count; i++)
            {
                seeds[i].CheckGarbash();
                if (seeds[i].toDelete)
                {
                    indexToDelete.Add(i);
                }
            }
            for (int i = 0; i < indexToDelete.Count; i++)
            {
                seeds.RemoveAt(i);
            }
            base.CheckGarbash();
        }
        public void SeedGenerator()
        {
            seeds.Add(new Seeds(new Vector2f(215f, 17f)));
            seeds.Add(new Seeds(new Vector2f(215f, 30f)));
            seeds.Add(new Seeds(new Vector2f(215f, 50f)));
            seeds.Add(new Seeds(new Vector2f(215f, 70f)));
            seeds.Add(new Seeds(new Vector2f(215f, 90f)));
            seeds.Add(new Seeds(new Vector2f(215f, 110f)));
            seeds.Add(new Seeds(new Vector2f(215f, 130f)));
            seeds.Add(new Seeds(new Vector2f(215f, 150f)));
            seeds.Add(new Seeds(new Vector2f(215f, 170f)));
            seeds.Add(new Seeds(new Vector2f(215f, 190f)));
            seeds.Add(new Seeds(new Vector2f(215f, 210f)));
            seeds.Add(new Seeds(new Vector2f(215f, 230f)));
            seeds.Add(new Seeds(new Vector2f(215f, 250f)));
            seeds.Add(new Seeds(new Vector2f(215f, 270f)));
            seeds.Add(new Seeds(new Vector2f(215f, 290f)));
            seeds.Add(new Seeds(new Vector2f(215f, 310f)));

            seeds.Add(new Seeds(new Vector2f(375f, 17f)));
            seeds.Add(new Seeds(new Vector2f(375f, 30f)));
            seeds.Add(new Seeds(new Vector2f(375f, 50f)));
            seeds.Add(new Seeds(new Vector2f(375f, 70f)));
            seeds.Add(new Seeds(new Vector2f(375f, 90f)));
            seeds.Add(new Seeds(new Vector2f(375f, 110f)));
            seeds.Add(new Seeds(new Vector2f(375f, 130f)));
            seeds.Add(new Seeds(new Vector2f(375f, 150f)));
            seeds.Add(new Seeds(new Vector2f(375f, 170f)));
            seeds.Add(new Seeds(new Vector2f(375f, 190f)));
            seeds.Add(new Seeds(new Vector2f(375f, 210f)));
            seeds.Add(new Seeds(new Vector2f(375f, 230f)));
            seeds.Add(new Seeds(new Vector2f(375f, 250f)));
            seeds.Add(new Seeds(new Vector2f(375f, 270f)));
            seeds.Add(new Seeds(new Vector2f(375f, 290f)));
            seeds.Add(new Seeds(new Vector2f(375f, 310f)));

            seeds.Add(new Seeds(new Vector2f(150f, 345f)));
            seeds.Add(new Seeds(new Vector2f(170f, 345f)));
            seeds.Add(new Seeds(new Vector2f(190f, 345f)));
            seeds.Add(new Seeds(new Vector2f(210f, 345f)));
            seeds.Add(new Seeds(new Vector2f(230f, 345f)));
            seeds.Add(new Seeds(new Vector2f(250f, 345f)));
            seeds.Add(new Seeds(new Vector2f(270f, 345f)));
            seeds.Add(new Seeds(new Vector2f(290f, 345f)));
            seeds.Add(new Seeds(new Vector2f(310f, 345f)));
            seeds.Add(new Seeds(new Vector2f(330f, 345f)));
            seeds.Add(new Seeds(new Vector2f(350f, 345f)));
            seeds.Add(new Seeds(new Vector2f(370f, 345f)));
            seeds.Add(new Seeds(new Vector2f(390f, 345f)));
            seeds.Add(new Seeds(new Vector2f(410f, 345f)));
            seeds.Add(new Seeds(new Vector2f(430f, 345f)));
            seeds.Add(new Seeds(new Vector2f(446f, 345f)));

            seeds.Add(new Seeds(new Vector2f(150f, 17f)));
            seeds.Add(new Seeds(new Vector2f(170f, 17f)));
            seeds.Add(new Seeds(new Vector2f(190f, 17f)));
            seeds.Add(new Seeds(new Vector2f(230f, 17f)));
            seeds.Add(new Seeds(new Vector2f(250f, 17f)));
            seeds.Add(new Seeds(new Vector2f(270f, 17f)));
            seeds.Add(new Seeds(new Vector2f(285f, 17f)));
            seeds.Add(new Seeds(new Vector2f(310f, 17f)));
            seeds.Add(new Seeds(new Vector2f(330f, 17f)));
            seeds.Add(new Seeds(new Vector2f(350f, 17f)));
            seeds.Add(new Seeds(new Vector2f(390f, 17f)));
            seeds.Add(new Seeds(new Vector2f(410f, 17f)));
            seeds.Add(new Seeds(new Vector2f(430f, 17f)));
            seeds.Add(new Seeds(new Vector2f(446f, 17f)));

            seeds.Add(new Seeds(new Vector2f(150f, 30f)));
            seeds.Add(new Seeds(new Vector2f(150f, 50f)));
            seeds.Add(new Seeds(new Vector2f(150f, 70f)));
            seeds.Add(new Seeds(new Vector2f(150f, 90f)));
            seeds.Add(new Seeds(new Vector2f(150f, 110f)));
            seeds.Add(new Seeds(new Vector2f(150f, 250f)));
            seeds.Add(new Seeds(new Vector2f(150f, 270f)));
            seeds.Add(new Seeds(new Vector2f(150f, 320f)));

            seeds.Add(new Seeds(new Vector2f(443f, 30f)));
            seeds.Add(new Seeds(new Vector2f(443f, 50f)));
            seeds.Add(new Seeds(new Vector2f(443f, 70f)));
            seeds.Add(new Seeds(new Vector2f(443f, 90f)));
            seeds.Add(new Seeds(new Vector2f(443f, 110f)));
            seeds.Add(new Seeds(new Vector2f(443f, 250f)));
            seeds.Add(new Seeds(new Vector2f(443f, 270f)));
            seeds.Add(new Seeds(new Vector2f(443f, 320f)));

            seeds.Add(new Seeds(new Vector2f(185f, 70f)));
            seeds.Add(new Seeds(new Vector2f(185f, 110f)));
            seeds.Add(new Seeds(new Vector2f(185f, 250f)));
            seeds.Add(new Seeds(new Vector2f(185f, 280f)));
            seeds.Add(new Seeds(new Vector2f(185f, 296f)));
            seeds.Add(new Seeds(new Vector2f(185f, 315f)));

            seeds.Add(new Seeds(new Vector2f(410f, 70f)));
            seeds.Add(new Seeds(new Vector2f(410f, 110f)));
            seeds.Add(new Seeds(new Vector2f(410f, 250f)));
            seeds.Add(new Seeds(new Vector2f(410f, 280f)));
            seeds.Add(new Seeds(new Vector2f(410f, 296f)));
            seeds.Add(new Seeds(new Vector2f(410f, 315f)));
        }
        public void UpdateAnimation(int a) {
            if (frameTimer.ElapsedTime.AsSeconds() > animTime / levelanimation.Count)
            {
                currentFrame++;
                if (currentFrame == levelanimation.Count - 1)
                {
                    currentFrame = 0;
                }
                frameTimer.Restart();
            }
            frameRect.Left = levelanimation[currentFrame].X * frameRect.Width;
            frameRect.Top = levelanimation[currentFrame].Y * frameRect.Height;
            sprite.TextureRect = frameRect;

            if (frameTimerC.ElapsedTime.AsSeconds() > animTimeC / animationCounter.Count)
            {
                currentFrameC++;
                if (currentFrameC == animationCounter.Count - 1)
                {
                    currentFrameC = 0;
                }
                frameTimerC.Restart();
            }
            frameRectC.Left = animationCounter[currentFrameC].X * frameRectC.Width;
            frameRectC.Top = animationCounter[currentFrameC].Y * frameRectC.Height;
            CounterSprite.TextureRect = frameRectC;
        }
        public void WallCreator() {
           new Wall(new Vector2f(275.0f, 296.0f), new Vector2f(50.0f, 13.0f));
           new Wall(new Vector2f(298.0f, 298.0f), new Vector2f(5.0f, 35.0f));

            new Wall(new Vector2f(160.0f, 365.0f), new Vector2f(400.0f, 200.0f));
            new Wall(new Vector2f(160.0f, 5.0f), new Vector2f(400.0f, 5.0f));
            new Wall(new Vector2f(301.0f, 5.0f), new Vector2f(2.0f, 55.0f));
            
            new Wall(new Vector2f(145.0f, 205.0f), new Vector2f(-100.0f, 180.0f));
            new Wall(new Vector2f(145.0f, 170.0f), new Vector2f(-100.0f, -180.0f));
            new Wall(new Vector2f(465.0f, 205.0f), new Vector2f(100.0f, 180.0f));
            new Wall(new Vector2f(465.0f, 170.0f), new Vector2f(100.0f, -180.0f));
            
            new Wall(new Vector2f(280.0f, 230.0f), new Vector2f(50.0f, 10.0f));
            new Wall(new Vector2f(298.0f, 230.0f), new Vector2f(5.0f, 34.0f));
            
            new Wall(new Vector2f(280.0f, 95.0f), new Vector2f(50.0f, 10.0f));
            new Wall(new Vector2f(298.0f, 95.0f), new Vector2f(5.0f, 34.0f));
            
            new Wall(new Vector2f(240.0f, 268.0f), new Vector2f(25.0f, 0.5f));
            new Wall(new Vector2f(340.0f, 268.0f), new Vector2f(25.0f, 0.5f));
            
            new Wall(new Vector2f(280.0f, 200.0f), new Vector2f(50.0f, 2.0f));
            new Wall(new Vector2f(275.0f, 160.0f), new Vector2f(5.0f, 2.0f));
            new Wall(new Vector2f(275.0f, 160.0f), new Vector2f(-5.0f, 30.0f));
            new Wall(new Vector2f(330.0f, 160.0f), new Vector2f(5.0f, 2.0f));
            new Wall(new Vector2f(335.0f, 160.0f), new Vector2f(2.0f, 30.0f));
            
            new Wall(new Vector2f(240.0f, 40.0f), new Vector2f(30.0f, 25.0f));
            new Wall(new Vector2f(175.0f, 40.0f), new Vector2f(30.0f, 25.0f));
            new Wall(new Vector2f(336.0f, 40.0f), new Vector2f(30.0f, 25.0f));
            new Wall(new Vector2f(400.0f, 40.0f), new Vector2f(30.0f, 25.0f));
            
            new Wall(new Vector2f(145.0f, 205.0f), new Vector2f(60.0f, 35.0f));
            new Wall(new Vector2f(145.0f, 170.0f), new Vector2f(60.0f, -35.0f));
            new Wall(new Vector2f(460.0f, 205.0f), new Vector2f(-60.0f, 35.0f));
            new Wall(new Vector2f(460.0f, 170.0f), new Vector2f(-60.0f, -35.0f));
            
            new Wall(new Vector2f(180.0f, 336.0f), new Vector2f(80.0f, 0.5f));
            new Wall(new Vector2f(239.0f, 336.0f), new Vector2f(1.0f, -40.0f));
            new Wall(new Vector2f(340.0f, 336.0f), new Vector2f(80.0f, 0.5f));
            new Wall(new Vector2f(365.0f, 336.0f), new Vector2f(1.0f, -40.0f));
            
            new Wall(new Vector2f(239.0f, 205.0f), new Vector2f(1.0f, 35.0f));
            new Wall(new Vector2f(367.0f, 205.0f), new Vector2f(1.0f, 35.0f));
            
            new Wall(new Vector2f(239.0f, 170.0f), new Vector2f(1.0f, -75.0f));
            new Wall(new Vector2f(239.0f, 132.0f), new Vector2f(25.0f, 1.0f));
            new Wall(new Vector2f(367.0f, 170.0f), new Vector2f(1.0f, -75.0f));
            new Wall(new Vector2f(367.0f, 132.0f), new Vector2f(-25.0f, 1.0f));
        }
        public override void Draw(RenderWindow window) {
            base.Draw(window);
            window.Draw(CounterSprite);
            for (int i = 0; i < seeds.Count; i++)
            {
                    seeds[i].Draw(window);
            }
        }
        public bool ConfirmWinner() {
            return Complete;
        }
    }
}
