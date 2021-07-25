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
    public class backGround : Basic2d
    {
        


        public backGround(string PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {
            Globals.passObject = passObject;
        }

        public override void Update()
        {
           
            base.Update();
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

        public void passObject (Object i)
        {
            mainChar mainChar = (mainChar)i;
            //so lieu tinh toan dua tren frame 1920*1080
            if (mainChar.pos.X >= 300) mainChar.pos.X = mainChar.pos.X - mainChar.speed; 
            if (mainChar.pos.X <= 1620) mainChar.pos.X = mainChar.pos.X + mainChar.speed;
            if (mainChar.pos.Y >= 200) mainChar.pos.Y = mainChar.pos.Y - mainChar.speed;
            if (mainChar.pos.Y <= 850) mainChar.pos.Y = mainChar.pos.Y + mainChar.speed; 
           
        }
    }
}
