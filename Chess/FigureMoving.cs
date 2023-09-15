namespace Chess
{
    internal class FigureMoving
    {
        public Figure Figure { get; }
        public Square From { get; }
        public Square To { get; }
        public Figure Promotion { get; }

        public FigureMoving(FigureOnSquare figureOnSquare, Square to, Figure promotion = Figure.None) : 
            this(figureOnSquare.Figure, figureOnSquare.Square, to, promotion) { }
        
        // Pe2e4    Pe7e8Q
        // 01234    012345
        public FigureMoving(string moving) : this(
            figure : (Figure)moving[0],
            from : new Square(moving.Substring(1, 2)),
            to : new Square(moving.Substring(3, 2)),
            promotion : moving.Length == 6 ? (Figure)moving[5] : Figure.None)
        {
            
        }

        public FigureMoving(Figure figure, Square from, Square to, Figure promotion = Figure.None)
        {
            Figure = figure;
            From = from;
            To = to;
            Promotion = promotion;
        }
    }
}