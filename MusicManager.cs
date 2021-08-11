using SFML.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MusicManager
    {
        private readonly string LevelMusic = "Audio//Start.ogg";
        private readonly string WakaWaka = "Audio//WakaWaka.wav";
        private static MusicManager instance;
        public static MusicManager GetInstance()
        {
            if (instance == null)
            {
                instance = new MusicManager();
            }
            return instance;
        }
        private List<Music> music;
        private int currentSong;

        private MusicManager()
        {
            music = new List<Music>(); 
            currentSong = 0;
            Music m = new Music(LevelMusic);
            Music Waka = new Music(WakaWaka);
            m.Loop = false;
            Waka.Loop = false;
            music.Add(m);
            music.Add(Waka);
            SetVolume(30);
        }
        public void SetVolume(int newVolume)
        {
            for (int i = 0; i < music.Count; i++)
            {
                music[i].Volume = newVolume;
            }
        }

        public void Stop(int a)
        {
            music[a].Stop();
        }
        public void Play(int a)
        {
            music[a].Play();
        }
    }
}
