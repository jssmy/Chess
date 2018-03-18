using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    public class Controller
    {
        Board board;

        public Controller()
        {
            board = new Board();
        }

        public  void Draw(Graphics gr)
        {
            board.Draw(gr);
        }

        public void Select(int x, int y)
        {
            board.select(x,y);
        }
    }
}
