using System;
using System.Text;

namespace Chess
{
    internal class Board
    {
        public string Fen { get; private set; }
        public Figure[,] Figures { get; }
        public Color MoveColor { get; private set; }
        public int MoveNumber { get; private set; }
        
        public Board(string fen)
        {
            Fen = fen;
            Figures = new Figure[8, 8];
            Init();
        }

        private void Init()
        {
            //"rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNRwKQkq - 0 1"

            string[] parts = Fen.Split();
            if (parts.Length != 6)
            {
                throw new InvalidOperationException();
            }
            InitFigures(parts[0]);
            MoveColor = parts[1] == "b" ? Color.Black : Color.White;
            MoveNumber = int.Parse(parts[5]);
        }

        private void InitFigures(string data)
        {
            for (int j = 8; j >= 2 ; j--) 
                data = data.Replace(j.ToString(), (j - 1) + "1");

            string[] lines = data.Split('/');

            for (int y = 7; y >= 0; y--)
            {
                for (int x = 0; x < 8; x++)
                {
                    Figure figure = Figure.None;
                    figure = figure.ParseOrDefault(lines[7 - y][x]);
                    Figures[x, y] = figure;
                }
            }
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
            next.GenerateFen();
            
            return next;
        }

        private void GenerateFen()
        {
            Fen = FenFigures() + " " +
                   FenColor() +
                   " - - 0 " + MoveNumber;
        }

        private string FenFigures()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int y = 7; y >= 0; y--)
            {
                for (int x = 0; x < 8; x++)
                {
                    stringBuilder.Append(Figures[x, y].ParseByFen());

                    if(y > 0)
                        stringBuilder.Append('/');
                }
            }

            return stringBuilder.ToString();
        }

        private string FenColor() => 
            MoveColor == Color.White ? "w" : "b";
    }
}