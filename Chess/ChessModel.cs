namespace Chess
{
    public class ChessModel
    {
        public string Fen { get; }
        
        private Board Board { get; set; }

        public ChessModel(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNRwKQkq - 0 1")
        {
            Fen = fen;
            Board = new Board(Fen);
        }

        private ChessModel(Board board)
        {
            Board = board;
        }
        
        public ChessModel Move(string move)
        {
            FigureMoving moving = new FigureMoving(move);
            Board nextBoard = Board.Move(moving);
            ChessModel nextChessModel = new ChessModel(nextBoard);
            return nextChessModel;
        }

        public char GetFigureAt(int x, int y)
        {
            Square square = new Square(x, y);

            Figure figure = Board.GetFigureAt(square);
           
            return (char)figure;
        }
    }
}