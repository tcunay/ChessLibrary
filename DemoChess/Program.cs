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
                Print(ChessToAscii(chess));
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
                string text = "    a  b  c  d  e  f  g  h\n";
                text += "  +-------------------------+\n";

                for (int y = 7; y >= 0; y--)
                {
                    text += y + 1;
                    text += " | ";
                    for (int x = 0; x < 8; x++)
                    {
                        text += chessModel.GetFigureAt(x, y);
                        text += "  ";
                    }

                    text += "| ";
                    text += $"{y + 1}\n";
                }
                
                text += "  +-------------------------+\n";
                text += "    a  b  c  d  e  f  g  h\n";
                return text;
            }

            static void Print(string text)
            {
                ConsoleColor oldForceColor = Console.ForegroundColor;
                foreach (char x in text)
                {
                    Console.ForegroundColor = x switch
                    {
                        >= 'a' and <= 'z' => ConsoleColor.Red,
                        >= 'A' and <= 'Z' => ConsoleColor.Black,
                        _ => ConsoleColor.Green
                    };
                    Console.Write(x);
                }

                Console.ForegroundColor = oldForceColor;
            }
        }
    }
}