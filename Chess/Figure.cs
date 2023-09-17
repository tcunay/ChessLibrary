using System;

namespace Chess
{
    internal enum Figure
    {
        None = '·',
        
        WhiteKing = 'K',
        WhiteQueen = 'Q',
        WhiteRook = 'R',
        WhiteBishop = 'B',
        WhiteKnight = 'N',
        WhitePawn = 'P',
        
        BlackKing = 'k',
        BlackQueen = 'q',
        BlackRook = 'r',
        BlackBishop = 'b',
        BlackKnight = 'n',
        BlackPawn = 'p',
    }
    
    internal static class FigureExtensions
    {
        public static Figure ParseOrDefault(this Figure figure, char value)
        {
            return value switch
            {
                >= 'A' and <= 'Z' => Enum.IsDefined(typeof(Figure), (int) value) ? (Figure) value : Figure.None,
                >= 'a' and <= 'z' => Enum.IsDefined(typeof(Figure), (int) char.ToUpper(value))
                    ? (Figure) char.ToUpper(value)
                    : Figure.None,
                _ => Figure.None
            };
        }

        public static char ParseByFen(this Figure figure)
        {
            return figure == Figure.None ? '1' : (char) figure;
        }
    }
}