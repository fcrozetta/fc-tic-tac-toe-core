using System;
using tui_netcore;
using System.Collections.Generic;

namespace fc_tic_tac_toe_core
{
    class Program
    {
        public List<List<string>> Board { get; set; }

        public static void Quit(int errNum=0){
            Console.CursorVisible = true;
            Environment.Exit(errNum);
        }

        

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Tui t = new Tui(100, 50)
            {
                Title = "Tic Tac Toe",
                Body  = "Welcome to Tic Tac Toe! \n This is a game for 2 Players. \n This Game was meant to be played only one time. \n Enjoy"
            };
            t.DrawOk();

            

        }
    }
}
