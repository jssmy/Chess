using System;
using System.Drawing;

namespace Chess
{
    public class Horse : Piece
    {
        public Horse(int x, int y, Bitmap img) : base(x,y,img)
        {
            Arr = new String[,] {
                {"-","X","-","X","-"},
                {"X","-","-","-","X"},
                {"-","-","O","-","-"},
                {"X","-","-","-","X"},
                {"-","X","-","X","-"},
            };
            movePermited = new String[Arr.GetLength(0), Arr.GetLength(0)];
        }
    }
}
