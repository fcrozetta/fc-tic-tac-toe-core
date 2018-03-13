using System;
using tui_netcore;
using System.Collections.Generic;

namespace fc_tic_tac_toe_core
{
    class Program
    {

        public static String[,] Board = {   {" "," "," "},
                                            {" "," "," "},
                                            {" "," "," "}
                                        };
    public static string BoardDraw = " \n  \n  \n  \n  \n  \n  \n  \n  \n      1   2   3 \n \n A      |   |    \n     ---+---+--- \n B      |   |    \n     ---+---+--- \n C      |   |     ";

        public static void Quit(int errNum=0){
            Console.CursorVisible = true;
            Environment.Exit(errNum);
        }

        static void Main(string[] args)
        {
            Tui.ColorSchema inputColor = Tui.ColorSchema.Info;
            bool player1 = true;
            int RowsToGoDown = 13;
            int colsToGoRight = 8;
            Console.CursorVisible = false;
            Tui UserInput = new Tui(50, 10) { 
                Title = "Player 1" ,
                Body = "Choose a Row:"
            };
            Tui t = new Tui(50, 25)
            {
                Title = "Tic Tac Toe",
                Body  = "Welcome to Tic Tac Toe! \n This is a game for 2 Players. \n Enjoy"
            };
            t.DrawOk();

            while (true)
            {
                int numPlayer = (player1?1:2);
                UserInput.Title = $"Player {numPlayer}";
                t.Body = BoardDraw ;
                t.Draw();

                int rowTmp = RowsToGoDown;
                for (int i = 0; i < 3; i++)
                {
                    Console.SetCursorPosition(colsToGoRight, rowTmp);
                    Console.Write($" {Board[i, 0]} | {Board[i, 1]} | {Board[i, 2]}");
                    rowTmp+=2;
                }

                int userRow = 0;
                string rowChar = UserInput.DrawList(new List<string> { "A", "B", "C" },inputColor);
                //! This can be done in a more performatic way. But i find this more readable
                if(rowChar == "A") userRow = 0;
                if(rowChar == "B") userRow = 1;
                if(rowChar == "C") userRow = 2;

                UserInput.Body = "Choose a column:";
                int userCol = Convert.ToInt32(UserInput.DrawList(new List<string> { "1", "2", "3" },inputColor))-1;

                if (Board[userRow,userCol] == " ")
                {
                    Board[userRow,userCol] = (player1) ? "X" : "O";
                    player1 = !player1;

                }
                
            }

        }
    }
}
