namespace Chess
{
    internal class FigureOnSquare
    {
        public Figure Figure { get; }
        public Square Square { get; }

        public FigureOnSquare(Figure figure, Square square)
        {
            Figure = figure;
            Square = square;
        }
    }
}