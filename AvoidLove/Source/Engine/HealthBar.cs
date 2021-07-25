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
    public class HealthBar
    {
        public Basic2d HealthMin, HealthMax, Healthnoblood;
        public HealthBar(string PATH, Vector2 POS, Vector2 DIMS) 
        {
            HealthMin = new Basic2d(PATH, POS, DIMS);
            HealthMax = new Basic2d(PATH + "full", POS, DIMS);
            Healthnoblood = new Basic2d(PATH + "noblood", POS, DIMS);
        }
        public virtual void Update(float Current, float Full)
        {
           
            HealthMax.dims.X = Current / Full * HealthMin.dims.X;
        }
        public virtual void Draw(Vector2 OFFSET)
        {
            HealthMin.Draw(OFFSET, new Vector2(0, 0));
            HealthMax.Draw(OFFSET, new Vector2(0, 0));
            Healthnoblood.Draw(OFFSET, new Vector2(0, 0));
        }
    }
}
