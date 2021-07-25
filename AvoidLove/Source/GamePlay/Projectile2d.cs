﻿#region Includes
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
    public class Projectile2d : Basic2d
    {
        public bool done;
        public float speed;
        public float damage;
        public bool iscritdmg;

        public Vector2 vectordirections;

        public Vector2 realtarget;

        public McTimer timer;

        public Projectile2d(string PATH, Vector2 POS, Vector2 DIMS, bool ISCRITDMG, Vector2 OWNERPOS, Vector2 TARGET) : base(PATH, POS, DIMS)
        {
            speed = 10;
            damage = 7;
            done = false;
            iscritdmg = ISCRITDMG;
            vectordirections = TARGET - OWNERPOS;
            realtarget.X = TARGET.X + vectordirections.X * 1000;
            realtarget.Y = TARGET.Y + vectordirections.Y * 1000;
            realtarget.Normalize();
            vectordirections.Normalize();

            rot = Globals.RotateTowards(POS, new Vector2(TARGET.X, TARGET.Y));

            timer = new McTimer(5000);
        }

        public virtual void Update(Vector2 OFFSET, mainChar UNITS, MobTop MobTop, MobDown MobDown, MobLeft MobLeft, MobRight MobRight)
        {
            pos += realtarget * speed;
            timer.UpdateTimer();
            if (timer.Test())
            {
                done = true;
            }
            if (HitmainChar(UNITS, iscritdmg,MobTop, MobDown, MobLeft, MobRight))
            {
                done = true;
            }
        }

        public virtual bool HitmainChar(mainChar UNITS, bool ISCRIT, MobTop MobTop, MobDown MobDown, MobLeft MobLeft, MobRight MobRight)
        {          
                if (Globals.GetDistance(pos, UNITS.pos) < UNITS.hitdist)
                {
                    Globals.SoundControl.PlaySong("eatHeart");

                if (!ISCRIT)
                {
                    if (savedPath == "HeartTop")
                    {
                        MobTop.Current += damage;
                    }
                    else
                    if (savedPath == "HeartDown")
                    {
                        MobDown.Current += damage;
                    }
                    else
                         if (savedPath == "HeartLeft")
                    {
                        MobLeft.Current += damage;
                    }
                    else
                         if (savedPath == "HeartRight")
                    {
                        MobRight.Current += damage;
                    }
                }                     
                    else
                        UNITS.GetHit(damage * 10);
                    
                    return true;
                }           
            return false;
        }

        public override void Draw(Vector2 OFFSET)
        {

            base.Draw(OFFSET);
        }
    }
}
