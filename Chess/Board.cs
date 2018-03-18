using System;
using System.Collections.Generic;
using System.Drawing;

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
        private List<UnitBoard> tmp_uboards { get; set; }
        private Piece tmp_p;
        Boolean selected { get; set; }
        private String ID_piece;
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
                    this.matrix[row, col] = "*";
                    unitBoards.Add(ub);
                    count++;
                }
                count++;
            }
            //
           
                //horse
                this.matrix[0, 1] = "KN1";
                this.matrix[0, 6] = "kN1";
                hors = new Horse(red.Width * 1, red.Height * 0, Properties.Resources.WhiteKnight);
                hors.ID = "KN11";
                pieces.Add(hors);
                hors = new Horse(red.Width * 6, red.Height * 0, Properties.Resources.WhiteKnight);
                hors.ID = "KN12";
                pieces.Add(hors);
                //rook
                this.matrix[0, 0] = "R1";
                this.matrix[0, 7] = "R1";
                rook = new Rook(red.Width * 0, red.Height * 0, Properties.Resources.WhiteRook);
                rook.ID = "R11";
                pieces.Add(rook);
                rook = new Rook(red.Width * 7, red.Height * 0, Properties.Resources.WhiteRook);
                rook.ID = "R12";
                pieces.Add(rook);
                //alfil
                this.matrix[0, 2] = "B1";
                this.matrix[0, 5] = "B1";
                bip = new Bishop(red.Width * 2, red.Height * 0, Properties.Resources.WhiteBishop);
                bip.ID = "B11";
                pieces.Add(bip);
                bip = new Bishop(red.Width * 5, red.Height * 0, Properties.Resources.WhiteBishop);
                bip.ID = "B12";
                pieces.Add(bip);
                //king
                this.matrix[0, 3] = "K1";
                king = new King(red.Width * 3, red.Height *0, Properties.Resources.WhiteKing);
                king.ID = "K11";
                pieces.Add(king);
                this.matrix[0, 4] = "Q1";
                queen = new Queen(red.Width * 4, red.Height * 0, Properties.Resources.WhiteQueen);
                queen.ID = "Q11";
                pieces.Add(queen);


            
            
                for (int i = 0; i < 8; i++)
                {
                    this.matrix[1, i] = "P1";
                    paw = new Pawn(red.Width * i, red.Height * 1, Properties.Resources.WhitePawn, 1);
                    paw.ID = "P1" + (i + 1);
                    pieces.Add(paw);

                }
            // second player
            
                //horse
                this.matrix[7, 1] = "KN2";
                this.matrix[7, 6] = "KN2";
                hors = new Horse(red.Width * 1, red.Height * 7, Properties.Resources.BlackKnight);
                hors.ID = "KN21";
                pieces.Add(hors);
                hors = new Horse(red.Width * 6, red.Height * 7, Properties.Resources.BlackKnight);
                hors.ID = "KN22";
                pieces.Add(hors);
                //rook
                this.matrix[7, 0] = "R2";
                this.matrix[7, 7] = "R2";
                rook = new Rook(red.Width * 0, red.Height * 7, Properties.Resources.BlackRook);
                rook.ID = "R21";
                pieces.Add(rook);
                rook = new Rook(red.Width * 7, red.Height * 7, Properties.Resources.BlackRook);
                rook.ID = "R22";
                pieces.Add(rook);
                //alfil
                this.matrix[7, 2] = "B2";
                this.matrix[7, 5] = "B2";
                bip = new Bishop(red.Width * 2, red.Height * 7, Properties.Resources.BlackBishop);
                bip.ID = "B21";
                pieces.Add(bip);
                bip = new Bishop(red.Width * 5, red.Height * 7, Properties.Resources.BlackBishop);
                bip.ID = "B22";
                pieces.Add(bip);
                //king
                this.matrix[7, 3] = "K2";
                king = new King(red.Width * 3, red.Height * 7, Properties.Resources.BlackKing);
                king.ID = "K21";
                pieces.Add(king);
                this.matrix[7, 4] = "Q2";
                queen = new Queen(red.Width * 4, red.Height * 7, Properties.Resources.BlackQueen);
                queen.ID = "Q21";
                pieces.Add(queen);






            
                for (int i = 0; i < 8; i++)
                {
                    this.matrix[6, i] = "P2";
                    paw = new Pawn(red.Width * i, red.Height * 6, Properties.Resources.BlackPawn, 2);
                    paw.ID = "P2" + (i + 1);
                    pieces.Add(paw);

                }



            
        }

        public void Draw(Graphics gr)
        {
            foreach (UnitBoard u in unitBoards)
            {
                u.Move(gr);
            }
            foreach (Piece p in pieces)
            {
                p.Move(gr);
            }
        }

        public void select(int x, int y)
        {
            
            rec = new Rectangle(x,y,1,1);
            un_selected();
            un_shadow();

            foreach (Piece p in pieces)
            {
                rec_piece = new Rectangle(p.posX,p.posY,p.Width,p.Height);
                 if (rec.IntersectsWith(rec_piece)) {
                    p.selected = true;
                    ID_piece = p.ID;
                    selected = true;
                    shadow(p);
                    break;
                }
            }
            set_objective(rec);



        }

        private void shadow(Piece p)
        {
            
            int lmit = p.Arr.GetLength(0);
            for (int i = 0; i < lmit; i++)
            {
                for (int j = 0; j < lmit; j++)
                {
                    if (p.Arr[i, j] == "X")
                    {
                     UnitBoard un = unitBoards.Find(u=> u.posX == (p.posX - (80 * (lmit - 1) / 2) + 80 * j) && u.posY == (p.posY - (80 * (lmit - 1) / 2) + 80 * i));
                        if (un != null)
                        {
                            un.Shadow = true;
                        }
                    }

                }
            }



        }

        private void un_shadow() {
            List<UnitBoard> uboars = unitBoards.FindAll(u=>u.Shadow);
            tmp_uboards = uboars;
            tmp_uboards = uboars;
            foreach(UnitBoard ub in uboars)
            {
                ub.Shadow = false;
            }
        }

        private void un_selected()
        {
            Piece pi = pieces.Find(p=>p.selected);
            if (pi!=null)
            {
                pi.selected = false;
            }
        }


        private void set_objective(Rectangle rec) {
            //List<UnitBoard> unit_shadows = unitBoards.FindAll(u=>u.Shadow);

            Piece p = pieces.Find(x=>x.ID==ID_piece);
            if(tmp_uboards!=null && p != null)
            {
                foreach (UnitBoard u in tmp_uboards)
                {
                    Rectangle tmp_rec = new Rectangle(u.posX,u.posY,u.Width,u.Height);
                    if (tmp_rec.IntersectsWith(rec))
                    {
                        p.objective_started = true;
                        p.objX = u.posX;
                        p.objY = u.posY;
                        matrix[u.posX / 80, u.posY / 80] = "*";
                        matrix[p.objX / 80, p.objY / 80] =p.ID;
                        ID_piece = "";
                        break;

                    }
                }
            }
            tmp_uboards = null;
            
        }
            
    }
}

