using System;
using Chess;

namespace DemoChess
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessModel chess = new ChessModel();

            while (true)
            {
                Console.WriteLine(chess.Fen);
                Console.WriteLine(ChessToAscii(chess));
                string move = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(move) == false)
                {
                    chess = chess.Move(move);
                }
                else
                {
                    break;
                }
            }

            static string ChessToAscii(ChessModel chessModel)
            {
                string text = "  +----------------+\n";

                for (int y = 7; y >= 0; y--)
                {
                    text += y + 1;
                    text += " | ";
                    for (int x = 0; x < 8; x++)
                    {
                        text += chessModel.GetFigureAt(x, y);
                        text += " ";
                    }

                    text += "|\n";
                }
                
                text += "  +----------------+\n";
                text += "    a b c d e f g h\n";
                return text;
            }
        }
    }
}