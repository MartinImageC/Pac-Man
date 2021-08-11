using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class FrameRate
    {
        public static readonly uint FRAMERATE_LIMIT = 60;//uint == int pero no toma valores negativos.
        private static Clock clock;
        private static Time previousTime;
        private static Time currentTime;
        private static float fps;
        private static float deltaTime;
        private static float timeScale;
        public static void InitFrameRateLimit()
        {
            clock = new Clock();
            previousTime = clock.ElapsedTime;
            timeScale = 1.0f;
        }
        public static void SetTimeScale(float newTimeScale)
        {
            timeScale = newTimeScale;
        }
        public static void FrameEnd()
        {
            currentTime = clock.ElapsedTime;
            deltaTime = currentTime.AsSeconds() - previousTime.AsSeconds();
            fps = 1.0f / deltaTime;
            previousTime = currentTime;
        }
        public static float GetCurrentFps()
        {
            return fps;
        }

        public static float GetDeltaTime()
        {
            return deltaTime * timeScale;
        }
    }
}
