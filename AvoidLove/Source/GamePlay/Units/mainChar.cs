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
    public class mainChar: Mob
    {

        public float hitdist;   
        public mainChar (string PATH, Vector2 POS, Vector2 DIMS): base(PATH, POS, DIMS)
        {
            speed = 10.0f;
            hitdist = 90.0f;
            GameGlobals.mainVector = mainVector;
        }
        // phím điều khiển
        public override void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();
            if (keyboardState.IsKeyDown(Keys.A))
            {
                Globals.passObject(this);
                pos = new Vector2(pos.X - speed, pos.Y);
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                Globals.passObject(this);
                pos = new Vector2( pos.X + speed, pos.Y);
            }
            if (keyboardState.IsKeyDown(Keys.W))
            {
                Globals.passObject(this);
                pos = new Vector2(pos.X, pos.Y - speed);
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                Globals.passObject(this);
                pos = new Vector2(pos.X, pos.Y + speed);
            }

            rot = Globals.RotateTowards(pos, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y));
            if (World.isPower) if (mouseState.LeftButton == ButtonState.Pressed)
                GameGlobals.ShootBulletMainChar(new Projectile2dforMainChar("powerBullet", pos, new Vector2(100, 100), pos, new Vector2(mouseState.X, mouseState.Y)));
            base.Update();
        }
        public void GetHit(float abc)
        {
            Globals.SoundControl.PlaySong("eatHeart");

        }

        public Vector2 mainVector()
        {
            return this.pos;
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
