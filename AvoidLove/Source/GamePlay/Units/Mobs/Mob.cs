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
#endregion

namespace AvoidLove
{
    public class Mob: Unit
    {
        public float bulletDelay;
        public float Current, Full;
        public float hitdist;
        public Mob (string PATH, Vector2 POS, Vector2 DIMS): base(PATH, POS , DIMS)
        {
            speed = 10.0f;
            bulletDelay = 1f;
            Current = 0;
            Full = 100;
            hitdist = 90.0f;
        }
 
        public override void Update()
        {
            AI();            
            base.Update();       
        }

        public virtual void AI()
        {

        }   

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
