using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public  class Board
    {
        private List<UnitBoard> unitBoards { get; set; }
        private String[,] matrix { get; set; }
        private Bitmap red; //rojo
        private Bitmap white; // blanco
        private List<Piece> pieces;
        private Horse hors;
        private Pawn paw;
        private Rook rook;
        private Bishop bip;
        private King king;
        private Queen queen;
        private Rectangle rec;
        private Rectangle rec_piece;
        private Bitmap rec_move;
        public Board() {
            pieces = new List<Piece>();
            
            this.unitBoards = new List<UnitBoard>();
            this.red = new Bitmap(80,80);
            this.white = new Bitmap(80,80);
            this.rec_move = new Bitmap(80,80);
            for (int i = 0; i < 80; i++)
            {
                for (int j = 0; j < 80; j++)
                {
                    this.red.SetPixel(i,j,Color.Red);
                    this.white.SetPixel(i,j,Color.White);
                    this.rec_move.SetPixel(i,j,Color.Orange);
                }
            }
            this.Initialize();

            
        }

        private void Initialize() {
            this.matrix = new String[8,8];
            int count = 1;
            UnitBoard ub;
            
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (count % 2 == 0)
                    {
                        ub = new UnitBoard(red.Width*col,red.Height*row,red);
                    }
                    else
                    {
                        ub = new UnitBoard(white.Width * col, white.Height * row, white);
                    }
                    this.matrix[row,col] ="X";
                    if (row == 0) {
                        //horse
                        this.matrix[row, 1] = "H";
                        this.matrix[row, 6] = "H";
                        hors = new Horse(red.Width * 1, red.Height * row, Properties.Resources.WhiteKnight);
                        pieces.Add(hors);
                        hors = new Horse(red.Width * 6, red.Height * row, Properties.Resources.WhiteKnight);
                        pieces.Add(hors);
                        //rook
                        this.matrix[row, 0] = "R";
                        this.matrix[row, 7] = "R";
                        rook = new Rook(red.Width*0, red.Height*row,Properties.Resources.WhiteRook);
                        pieces.Add(rook);
                        rook = new Rook(red.Width * 7, red.Height *row, Properties.Resources.WhiteRook);
                        pieces.Add(rook);
                        //alfil
                        bip = new Bishop(red.Width*2,red.Height*row,Properties.Resources.WhiteBishop);
                        pieces.Add(bip);
                        bip = new Bishop(red.Width * 5, red.Height * row, Properties.Resources.WhiteBishop);
                        pieces.Add(bip);
                        //king
                        king = new King(red.Width*3,red.Height*row,Properties.Resources.WhiteKing);
                        pieces.Add(king);
                        queen = new Queen(red.Width*4,red.Height*row,Properties.Resources.WhiteQueen);
                        pieces.Add(queen);


                        /// secon player
                        

                    }
                    if (row == 1)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            this.matrix[row, i] = "P";
                            paw = new Pawn(red.Width*i,red.Height*row, Properties.Resources.WhitePawn);
                            pieces.Add(paw);

                        }
                    }
                       // second player
                    if (row == 7)
                    {
                        //horse
                        this.matrix[row, 1] = "H";
                        this.matrix[row, 6] = "H";
                        hors = new Horse(red.Width * 1, red.Height * row, Properties.Resources.BlackKnight);
                        pieces.Add(hors);
                        hors = new Horse(red.Width * 6, red.Height * row, Properties.Resources.BlackKnight);
                        pieces.Add(hors);
                        //rook
                        this.matrix[row, 0] = "R";
                        this.matrix[row, 7] = "R";
                        rook = new Rook(red.Width * 0, red.Height * row, Properties.Resources.BlackRook);
                        pieces.Add(rook);
                        rook = new Rook(red.Width * 7, red.Height * row, Properties.Resources.BlackRook);
                        pieces.Add(rook);
                        //alfil
                        bip = new Bishop(red.Width * 2, red.Height * row, Properties.Resources.BlackBishop);
                        pieces.Add(bip);
                        bip = new Bishop(red.Width * 5, red.Height * row, Properties.Resources.BlackBishop);
                        pieces.Add(bip);
                        //king
                        king = new King(red.Width * 3, red.Height * row, Properties.Resources.BlackKing);
                        pieces.Add(king);
                        queen = new Queen(red.Width * 4, red.Height * row, Properties.Resources.BlackQueen);
                        pieces.Add(queen);


                        
                        

                    }

                    if (row == 6)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            this.matrix[row, i] = "P";
                            paw = new Pawn(red.Width * i, red.Height * row, Properties.Resources.BlackPawn);
                            pieces.Add(paw);

                        }
                    }



                    unitBoards.Add(ub);
                    count++;
                }
                count++;
            }

        }

        public void Draw(Graphics gr)
        {
            foreach (UnitBoard u in unitBoards)
            {
                u.Draw(gr);
            }
            foreach (Piece p in pieces)
            {
                p.Move(gr);
            }
        }

        public void selected(int x, int y)
        {
            rec = new Rectangle(x,y,1,1);
            foreach(Piece p in pieces)
            {
                if (p.selected) {
                    p.selected = false;

                }
                rec_piece = new Rectangle(p.posX,p.posY,p.Width,p.Height);
                if (rec.IntersectsWith(rec_piece)) {
                    p.selected = true;
                   /* int ic = (p.Arr.GetLength(0)-1)/2;
                    int jc = (p.Arr.GetLength(1)-1)/2;
                    matrix[p.posX / 80, p.posY/80] = p.Arr[ic, jc];
                    UnitBoard un= unitBoards.Find(u=>u.posX==p.posX && u.posY==p.posY);
                    un.img(rec_move);
                    */

                }
            }
        }

    }
}
