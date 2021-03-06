﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class King: Piece
    {
        public King(int x, int y, Bitmap img): base(x,y,img) {
            this.Arr = new String[,] {
                {"X","X","X"},
                {"X","O","X"},
                {"X","X","X"},
            };

            movePermited = new String[Arr.GetLength(0), Arr.GetLength(0)];
        }
    }
}
