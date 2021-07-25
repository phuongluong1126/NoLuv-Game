#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Design;
#endregion

namespace AvoidLove
{
    public class Projectile2dforMainChar: Projectile2d
    {
        public Projectile2dforMainChar(string PATH, Vector2 POS, Vector2 DIMS, Vector2 OWNERPOS, Vector2 TARGET): base(PATH, POS, DIMS, false, OWNERPOS, TARGET)
        {
            speed = 20;
        }
        public void Update(Vector2 OFFSET, MobTop MobTop, MobDown MobDown, MobLeft MobLeft, MobRight MobRight)
        {
            pos += realtarget * speed;
            timer.UpdateTimer();
            if (timer.Test())
            {
                done = true;
            }
            if(HitMob(MobTop, MobDown, MobLeft, MobRight))
            {
                done = true;
            }
        }
        public bool HitMob( MobTop MobTop, MobDown MobDown, MobLeft MobLeft, MobRight MobRight)
        {
            if (Globals.GetDistance(pos, MobTop.pos) < MobTop.hitdist)
            {
                MobTop.Current -= damage;
                return true;
            }
            if (Globals.GetDistance(pos, MobDown.pos) < MobDown.hitdist)
            {
                MobDown.Current -= damage;
                return true;
            }
            if (Globals.GetDistance(pos, MobLeft.pos) < MobLeft.hitdist)
            {
                MobLeft.Current -= damage;
                return true;
            }
            if (Globals.GetDistance(pos, MobRight.pos) < MobRight.hitdist)
            {
                MobRight.Current -= damage;
                return true;
            }
            return false;

        }
     
    }
}
