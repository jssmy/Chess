using System;
using System.Drawing;

namespace Chess
{
    public class Pawn: Piece
    {
        public Pawn(int x, int y, Bitmap img) : base(x,y,img) {
            Arr = new String[,] {
                {"Y","X","Y" },
                {"-","O","-" },
                {"Y","X","Y" },
            }; 
        }
    }
}
