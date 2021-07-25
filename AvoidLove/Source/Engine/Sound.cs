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
    public class Sound
    {
        public string nameSound;
        public float volumn;
        public SoundEffect sound;
        public SoundEffectInstance instance;

        public Sound (string PATH, string NAMESOUND, float VOLUMN)
        {
            nameSound = NAMESOUND;
            volumn = VOLUMN;
            sound = Globals.content.Load<SoundEffect>(PATH);
            instance = sound.CreateInstance();
            instance.Volume = volumn;
        }
       
    }
}
