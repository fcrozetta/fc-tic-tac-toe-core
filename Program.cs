using System;
using tui_netcore;
using System.Collections.Generic;

namespace fc_tic_tac_toe_core
{
    class Program
    {
        public static bool player1 = true;
        public static int numPlayer = 1;
        public static int RowsToGoDown = 13;
        public static int colsToGoRight = 8;

        public static String[,] BoardEmpty ={   {" "," "," "},
                                                {" "," "," "},
                                                {" "," "," "}
                                            };
        public static String[,] Board;
        public static string BoardDraw = " \n  \n  \n  \n  \n  \n  \n  \n  \n      1   2   3 \n \n A      |   |    \n     ---+---+--- \n B      |   |    \n     ---+---+--- \n C      |   |     ";

        public static void Quit(int errNum=0){
            Console.CursorVisible = true;
            Environment.Exit(errNum);
        }

        private static void VictoryCondition(){
            // * This is opposite, because we check the last player move
            string charPlayer = player1 ? "O" : "X";
            bool flagNewGame = false;
            Tui victory = new Tui(50, 10)
            {
                Title = "Game Over"
            };

            if (
                // * Top left Corner
                (Board[0, 0] == charPlayer && Board[0,1] == charPlayer && Board[0,2] == charPlayer) || //Horizontal top
                (Board[0, 0] == charPlayer && Board[1,1] == charPlayer && Board[2,2] == charPlayer) || //Diagonal top left ~ bottom right
                (Board[0, 0] == charPlayer && Board[1,0] == charPlayer && Board[2,0] == charPlayer) || //Vertical Left 
                // * Middle left
                (Board[1, 0] == charPlayer && Board[1,1] == charPlayer && Board[1,2] == charPlayer) || //Horizontal middle
                // * Bottom left
                (Board[2, 0] == charPlayer && Board[2,1] == charPlayer && Board[2,2] == charPlayer) || //horizontal bottom 
                (Board[2, 0] == charPlayer && Board[2,1] == charPlayer && Board[2,2] == charPlayer) || //Vertical Left 
                (Board[2, 0] == charPlayer && Board[1,1] == charPlayer && Board[0,2] == charPlayer) || //Diagonal bottom left ~ top right
                // * Top middle
                (Board[0, 1] == charPlayer && Board[1,1] == charPlayer && Board[2,1] == charPlayer) || //Vertical middle
                // * Top right
                (Board[0, 2] == charPlayer && Board[1,2] == charPlayer && Board[2,2] == charPlayer)    // Vertical right
                
            )
            {
                flagNewGame = true;
                victory.Body = $"'{charPlayer}' Won! \n \n ";

            }else if (
                // * Board Full, no winners
                Board[0, 0] != " " && Board[0, 1] != " " && Board[0, 2] != " " &&
                Board[1, 0] != " " && Board[1, 1] != " " && Board[1, 2] != " " &&
                Board[2, 0] != " " && Board[2, 1] != " " && Board[2, 2] != " ")
            {
                flagNewGame = true;
                victory.Body = "No winners! \n \n ";
            }


            if (flagNewGame)
            {
                victory.Body += $"Play Again?";
                if (victory.DrawYesNo(Tui.ColorSchema.System, "Yes", "No", true))
                {
                    Board = BoardEmpty;
                    numPlayer = 1;
                    player1 = true;
                }else
                {
                    Quit();
                }

            }

        }

        static void Main(string[] args)
        {
            Tui.ColorSchema inputColor = Tui.ColorSchema.Info;
            Board = (string[,])BoardEmpty.Clone();

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
                VictoryCondition();
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
