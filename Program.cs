using System;
using tui_netcore;
using System.Collections.Generic;

namespace fc_tic_tac_toe_core
{
    class Program
    {
        public static String[,] Board = {   {"A","B","C"},
                                            {"D","E","F"},
                                            {"G","H","I"}
                                        };
    public static string BoardDraw = " \n  \n  \n  \n  \n  \n  \n  \n  \n      1   2   3 \n \n A      |   |    \n     ---+---+--- \n B      |   |    \n     ---+---+--- \n C      |   |     ";

        public static void Quit(int errNum=0){
            Console.CursorVisible = true;
            Environment.Exit(errNum);
        }

        static void Main(string[] args)
        {
            // int numPlayer = 1;
            int RowsToGoDown = 13;
            int colsToGoRight = 8;
            Console.CursorVisible = false;
            Tui UserInput = new Tui(50, 5) { 
                Title = "Player 1" ,
                Body = "Choose a Row (A,B,C):"
            };
            Tui t = new Tui(50, 25)
            {
                Title = "Tic Tac Toe",
                Body  = "Welcome to Tic Tac Toe! \n This is a game for 2 Players. \n Enjoy"
            };
            t.DrawOk();

            
            t.Body = BoardDraw ;
            t.DrawOk(); // TODO: THis should not stop, just draw the box

            int rowTmp = RowsToGoDown;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(colsToGoRight, rowTmp);
                Console.Write($" {Board[i, 0]} | {Board[i, 1]} | {Board[i, 2]}");
                rowTmp+=2;
            }

            string row = UserInput.DrawInput();
        }
    }
}
