using System;
using System.Drawing;

namespace Chess
{
    public class Piece : Figure
    {
        protected int varX { get; set; }
        protected int varY { get; set;}
        public String [,]Arr { get; set; }
        public bool selected { get; set; }
        private Pen pen;
        private Rectangle rec;
        public Piece(int x, int y, Bitmap img) :base(x,y,img)
        {
            selected = false;
            pen =  new Pen(Color.Black, 3);
            rec   = new Rectangle(this.posX, this.posY, this.Width, this.Height);
        }

       

        public void Move(Graphics gr) {
            Draw(gr);
            if (selected)
            {
                print_Selected(gr);
            }
        }

        private void print_Selected(Graphics gr)
        {
            
            gr.DrawRectangle(pen,rec);
        }
    }
}
