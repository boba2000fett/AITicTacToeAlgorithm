//Programmed by Trenton Andrews and Nate Wright
//Comments by Nate Wright
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{

    class Game
    {
        Player playerX;
        Player playerO;
        bool isMax;
        int intMax;
        int intMin;
        Board gameBoard; //Had to add this

        public Game()
        {
            playerX = new Player(1);
            playerO = new Player(1);
            gameBoard = new Board();

            WhichFirst();
        }

        public int WhichFirst()//This determines which player will be first, either 1 (Min) or 2 (Max)
        {
            Random rand = new Random();
            intMax = rand.Next(1, 3);
            if (intMax == 2)
            {
                isMax = true;
                return 1;
            }
            else
            {
                isMax = false;
                return 2;
            }
        }

        public int Play()//This method "Plays" the game. The method will call the
        {//Minimax algorithm, and then get a move. The player will then make that move on the board. 
            
            gameBoard.ResetGame();
            
            
            Console.WriteLine("Start of Game");
            
            int position;
            int gameEnd;
            
            do
            {
                Node rootNode = new Node(0,gameBoard);
                if (isMax == true)
                {
                    Console.WriteLine("Player Max's Turn");
                    position = playerX.Minimax(rootNode, gameBoard, true, 0,3);//Here the Minimax algorithm is called
                    gameBoard.PlacePiece(position, Piece.X);
                    DisplayBoard(gameBoard.DisplayGame());
                    isMax = false;
                }
                else
                {
                    Console.WriteLine("Player Min's Turn");
                    position = playerO.Minimax(rootNode, gameBoard, false, 0,2); //Here the Minimax algorithm is called
                    gameBoard.PlacePiece(position, Piece.O);
                    DisplayBoard(gameBoard.DisplayGame());
                    isMax = true;
                }
                
            } while (gameBoard.HasGameEnded() == 0);
            gameEnd = gameBoard.HasGameEnded();
            
            return gameEnd;
        }


        public void DisplayBoard(char[] charArray)//This Displays the current state of the board
        {
            for (int i = 0; i < 9; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("{0}", charArray[i]);
                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.ResetColor();
        }

    }
}







//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FinalProject
//{

//    class Game
//    {
//        Player playerX;
//        Player playerO;
//        bool isMax;
//        int intMax;
//        int intMin;
//        Board gameBoard; //Had to add this

//        public Game()
//        {
//            playerX = new Player(1);
//            playerO = new Player(0);
//            gameBoard = new Board();
//        }

//        public int WhichFirst()
//        {

//            return 0;

//        }

//        public void Play()
//        {

//            isMax = true;
//            int position;
//            while (gameBoard.HasGameEnded() == 0)
//            {
//                Node testNode = new Node(0, gameBoard);


//                if (isMax == true)
//                {
//                    position = playerX.MinimaxTest(testNode, gameBoard, true, 1, 3);
//                    gameBoard.PlacePiece(position, Piece.X);
//                    DisplayBoard(gameBoard.DisplayGame());
//                    isMax = false;
//                }
//                else
//                {
//                    position = playerO.MinimaxTest(testNode, gameBoard, false, 1, 3);
//                    gameBoard.PlacePiece(position, Piece.O);
//                    DisplayBoard(gameBoard.DisplayGame());
//                    isMax = true;
//                }

//                Console.ReadLine();



//            }
//        }


//        public void DisplayBoard(char[] charArray)
//        {
//            for (int i = 0; i < 9; i++)
//            {
//                Console.Write("{0}", charArray[i]);
//                if ((i + 1) % 3 == 0)
//                {
//                    Console.WriteLine();
//                }
//            }
//        }







//    }


//}
