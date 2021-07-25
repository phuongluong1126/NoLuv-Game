#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#if WINDOW_PHONE
using Microsoft.Xna.Framework.Input.Touch;
#endif
#endregion


namespace AvoidLove
{
    public class SoundControl
    {
      
        public List<Sound> soundEffect = new List<Sound>();

        public SoundControl ()
        {
            //BackGroundMusic = new Sound(PATH, "BackGroundMusic", 0.5f);
            //BackGroundMusic.instance.IsLooped = true;
            //BackGroundMusic.instance.Play();
            //BackGroundMusic = new Sound(PATH, "GameOver", 0f);
            //BackGroundMusic.instance.IsLooped = true;
            //BackGroundMusic.instance.Play();

        }
        public void AddSong(string PATH, string NAMESOUND, float VOLUMN)
        {
            soundEffect.Add(new Sound(PATH, NAMESOUND, VOLUMN));
        }

        public void RunSong(SoundEffect SOUND, SoundEffectInstance INSTANCE, float VOLUMN)
        {
            INSTANCE.Volume = VOLUMN;
            INSTANCE.Play();
        }

        public void PlaySong(string NAMESOUND)
        {
            for (int i=0; i < soundEffect.Count; i++)
            {
                if (soundEffect[i].nameSound == NAMESOUND)
                    RunSong(soundEffect[i].sound, soundEffect[i].instance, soundEffect[i].volumn);
            }
        }

        public void StopSong(string NAMESOUND)
        {
            for (int i = 0; i < soundEffect.Count; i++)
            {
                if (soundEffect[i].nameSound == NAMESOUND)
                    RunSong(soundEffect[i].sound, soundEffect[i].instance, 0f);
            }
        }
    }

}
