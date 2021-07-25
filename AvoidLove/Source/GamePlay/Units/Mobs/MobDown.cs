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
    public class MobDown : Mob
    {
        bool check = true;
        public MobDown(string PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {
            speed = 4.0f;
        }
        public override void Update()
        {
            if (!check) pos = new Vector2(pos.X - speed, pos.Y);
            else
                pos = new Vector2(pos.X + speed, pos.Y);
            if (pos.X >= 1600) check = false;
            if (pos.X <= 290) check = true;
            GameGlobals.ShootBulletDown(new Projectile2d("HeartDown", pos, new Vector2(60, 60), false, pos, GameGlobals.mainVector()));
            base.Update();
        }
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }

}
