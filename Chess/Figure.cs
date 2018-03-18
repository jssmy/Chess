using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Figure
    {
        public string ID { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        protected Bitmap image { get; set; }
        protected Rectangle space { get; set; }
        protected Rectangle zoom { get; set; }

        public Figure(int x, int y, Bitmap bmp)
        {
            this.posX = x;
            this.posY = y;
            this.image = bmp;
            this.Width = this.image.Width;
            this.Height = this.image.Height;
        }
        

        public void Draw(Graphics gr)
        {
            space = new System.Drawing.Rectangle(0, 0, this.Width, this.Height);
            ///space = new System.Drawing.Rectangle(this.posX, this.posY, this.Width, this.Height);
            gr.DrawImage(image,this.posX,this.posY,space,GraphicsUnit.Pixel);
        }

    }
}
