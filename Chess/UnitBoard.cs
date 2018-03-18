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
        private SolidBrush brush;
        private Rectangle rec;
        public Boolean Shadow { get; set; }
        public UnitBoard(int x, int y, Bitmap bmp) : base(x, y, bmp)
        {
            Shadow = false;
            brush = new SolidBrush(Color.Yellow);
            rec = new Rectangle(this.posX+5, this.posY+5, this.Width-10,this.Height-10);

        
        }
        

     
        public void Move(Graphics gr)
        {
            
            
            Draw(gr);
            if (Shadow)
            {
                gr.FillRectangle(brush, rec);
            }
        }

    }
}
