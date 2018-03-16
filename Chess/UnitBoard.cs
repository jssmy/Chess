using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class UnitBoard : Figure
    {

        public UnitBoard(int x, int y, Bitmap bmp) : base(x, y, bmp)
        {

        }

        public void img  (Bitmap img)
        {
            this.image = img;
        }



    }
}
