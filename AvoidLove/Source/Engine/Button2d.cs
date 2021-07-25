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
    public class Button2d:  Basic2d
    {
        public bool isPressed, isHovered;
        public object info;
        PassObject ButtonClicked;
        public Vector2 offset;
        public MouseState mouseReset;
        public Button2d(string PATH, Vector2 POS, Vector2 DIMS, PassObject BUTTONCLICKED, object INFO) : base (PATH, POS, DIMS)
        {
            ButtonClicked = BUTTONCLICKED;
            isPressed = false;
            
        }
        public virtual bool Update(Vector2 OFFSET)
        {
       
            if (Hover(OFFSET))
            {
                mouseReset = Mouse.GetState();
                if (mouseReset.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && mouseReset.Position.X >= 0 && mouseReset.Position.X <= Globals.screenWidth && mouseReset.Position.Y >= 0 && mouseReset.Position.Y <= Globals.screenHeight)
                return true;
            }
            base.Update();
            return false;           
        }

        public virtual void Reset()
        {
            isHovered = false;
            isPressed = false;
        }
         public virtual void RunBtnClick()
        {
            if (ButtonClicked != null)
            {
                ButtonClicked(info);
            }
            Reset();

        }
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
