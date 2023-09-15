using System;

namespace Chess
{
    internal class Board
    {
        public string Fen { get; }
        public Figure[,] Figures { get; }
        public Color MoveColor { get; private set; }
        public int MoveNumber { get; private set; }
        
        public Board(string fen)
        {
            Fen = fen;
            Figures = new Figure[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Figures[i, j] = Figure.None;
                }
            }
            
            Init();
        }

        private void Init()
        {
            SetFigureAt(new Square("a1"), Figure.WhiteKing);
            SetFigureAt(new Square("h8"), Figure.BlackKing);
            MoveColor = Color.White;
        }

        public Figure GetFigureAt(Square square)
        {
            if (square.OnBoard())
            {
                return Figures[square.X, square.Y];
            }

            return Figure.None;
        }

        public void SetFigureAt(Square square, Figure figure)
        {
            if (square.OnBoard())
            {
                Figures[square.X, square.Y] = figure;
            }
        }

        public Board Move(FigureMoving moving)
        {
            Board next = new Board(Fen);
            next.SetFigureAt(moving.From, Figure.None);
            next.SetFigureAt(moving.To, moving.Promotion == Figure.None ? moving.Figure : moving.Promotion);

            if (MoveColor == Color.Black)
            {
                next.MoveNumber++;
            }

            next.MoveColor.FlipColor();
            
            return next;
        }
    }
}