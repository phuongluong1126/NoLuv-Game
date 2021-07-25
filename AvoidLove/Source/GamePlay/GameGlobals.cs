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
    public class GameGlobals
    {
        public static PassObject ShootBulletTop, ShootBulletDown, ShootBulletLeft, ShootBulletRight, ShootBulletMainChar;
        public static Vector mainVector;
        public static float gameTimePassed = 0;
        public static int score = 0;
    } 
}
