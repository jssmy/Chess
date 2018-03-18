using System;
using System.Drawing;

namespace Chess
{
    public class Piece : Figure
    {
        public int objX { get; set; }
        public int objY { get; set; }
        public Boolean objective_started { get; set; }
        protected int varX { get; set; }
        protected int varY { get; set;}
        public String [,] movePermited { get; set; }
        public String [,]Arr { get; set; }
        public bool selected { get; set; }
        private Pen pen;
        private Rectangle rec;
        public Piece(int x, int y, Bitmap img) :base(x,y,img)
        {
            selected = false;
            objective_started = false;
            varX = 1;
            varY = 1;
            pen =  new Pen(Color.Black, 4);
            rec   = new Rectangle(this.posX, this.posY, this.Width, this.Height);
        }

       

        public void Move(Graphics gr) {
            if (objective_started)
            {
                if (posX < objX) varX = 5;
                if (posX > objX) varX =-5;
                if (posY < objY) varY = 5;
                if (posY > objY) varY =-5;
                if (posX == objX) varX = 0;
                if (posY == objY) varY = 0;

                posX = posX + varX;
                posY = posY + varY;

                if (posX == objX && posY == objY) {
                    rec = new Rectangle(this.posX, this.posY, this.Width, this.Height);
                    objective_started = false; }
                    
            }

            Draw(gr);
            if (selected)
            {
                gr.DrawRectangle(pen, rec);
            }
            
        }

        
    }
}
