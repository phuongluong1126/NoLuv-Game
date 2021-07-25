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
    public class MobRight : Mob
    {
        bool check = true;
        public MobRight(string PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {
            speed = 4.0f;
        }
        public override void Update()
        {
            if (!check) pos = new Vector2(pos.X , pos.Y - speed);
            else
                pos = new Vector2(pos.X , pos.Y + speed);
            if (pos.Y >= 850) check = false;
            if (pos.Y <= 230) check = true;
            GameGlobals.ShootBulletRight(new Projectile2d("HeartRight", pos, new Vector2(60, 60), false, pos, GameGlobals.mainVector()));
            base.Update();
        }
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }

}
