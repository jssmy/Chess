using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    public partial class Main : Form
    {
        Controller con;
        
        int x { get; set;}
        int y { get; set; }
        public Main()
        {
            InitializeComponent();
            con = new Controller();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void Main_Load(object sender, EventArgs e)
        {
            plataform.Visible = false;
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            
            if (plataform != null)
            {
                Graphics g = plataform.CreateGraphics();
                BufferedGraphicsContext contexto = BufferedGraphicsManager.Current;
                BufferedGraphics buffer = contexto.Allocate(g, plataform.DisplayRectangle);
                buffer.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                con.Draw(buffer.Graphics);
                buffer.Render(g);
                buffer.Dispose();
                g.Dispose();
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            //plataform = new PictureBox();
            con = new Controller();
            plataform.Visible = true;
            double x = (double)(this.Width-this.Panel.Width)*0.10;
            int y = this.menuBar.Height;
            
            Point p = new Point((int)x,y);
            plataform.Location = p;
            Size s = new Size(640,640);
            plataform.Size = s;
            this.Controls.Add(plataform);


        }

        private void plataform_MouseMove(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            posMouse.Text = "X: " + x + ", Y: " + y;
        }

        private void plataform_Click(object sender, EventArgs e)
        {
            con.Select(x,y);
        }
    }

   
}
