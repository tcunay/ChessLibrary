namespace Chess
{
    internal enum Color
    {
        None = 0,
        White = 1,
        Black = 2,
    }

    internal static class ColorMethods
    {
        public static Color FlipColor(this Color color)
        {
            return color switch
            {
                Color.Black => Color.White,
                Color.White => Color.Black,
                _ => Color.None
            };
        }
    }
}