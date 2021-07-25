﻿#region Includes
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
    public class Basic2d
    {
        public float rot;
        public Vector2 pos, dims;
        public Texture2D myModel;
        public string savedPath;
        public Basic2d(string PATH, Vector2 POS, Vector2 DIMS)
        {
            pos = POS;
            dims = DIMS;
            savedPath = PATH;
            myModel = Globals.content.Load<Texture2D>(PATH);
        }

        public virtual void Update()
        {

        }
        public virtual bool Hover(Vector2 OFFSET)
        {
            return HoverImg(OFFSET);
        }
        public virtual bool HoverImg(Vector2 OFFSET)
        {
            Vector2 mousePos = new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y);
            if (mousePos.X>=(pos.X + OFFSET.X)-dims.X/2 && mousePos.X <= (pos.X + OFFSET.X)+dims.X/2 && mousePos.Y >= (pos.Y + OFFSET.Y) - dims.Y / 2 && mousePos.Y <= (pos.Y + OFFSET.Y) + dims.Y / 2)
            //if (mousePos.X>=(pos.X -dims.X) && mousePos.X <= (pos.X + dims.X) && mousePos.Y >= (pos.Y - dims.Y) && mousePos.Y <= (pos.Y + dims.Y))

            {
                return true;
            }
            return false;
        }
        public virtual void Draw(Vector2 OFFSET)
        {
            if (myModel!=null)
            {
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X + OFFSET.X ),(int)(pos.Y + OFFSET.Y), (int)dims.X, (int)dims.Y), null, Color.White, rot, new Vector2(myModel.Bounds.Width / 2, myModel.Bounds.Height / 2), new SpriteEffects(), 0);
            }
        }

        public virtual void Draw(Vector2 OFFSET, Vector2 ORIGIN)
        {
            if (myModel != null)
            {
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X + OFFSET.X), (int)(pos.Y + OFFSET.Y), (int)dims.X, (int)dims.Y), null, Color.White, rot, new Vector2(ORIGIN.X, ORIGIN.Y), new SpriteEffects(), 0);
            }
        }
    }
}
