namespace Chess
{
    internal struct Square
    {
        public static Square None { get; } = new Square(-1, -1);
        
        public int X { get; }
        public int Y { get; }

        public Square(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Square(string e2)
        {
            char character = e2[0];
            char number = e2[1];

            if (e2.Length == 2 &&
                character is >= 'a' and <= 'h' &&
                number is >= '1' and <= '8')
            {
                X = character - 'a';
                Y = number - '1';
            }
            else
            {
                this = None;
            }
        }

        public bool OnBoard()
        {
            return X is >= 0 and < 8 &&
                   Y is >= 0 and < 8;
        }
        
        
    }
}