using System;
using System.Drawing;

namespace Chess
{
    public class Pawn: Piece
    {
        public Pawn(int x, int y, Bitmap img, int type) : base(x,y,img) {

            if (type == 1)
            {
                Arr = new String[,] {
                {"-","-","-" },
                {"-","O","-" },
                {"Y","X","Y" },
            };
            }
            if (type == 2)
            {
                Arr = new String[,] {
                {"Y","X","Y" },
                {"-","O","-" },
                {"-","-","-" },
            };
            }
            

            movePermited = new String[Arr.GetLength(0), Arr.GetLength(0)];
        }
    }
}
