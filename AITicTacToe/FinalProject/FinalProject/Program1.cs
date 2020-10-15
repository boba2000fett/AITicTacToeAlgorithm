//Programmed by Trenton Andrews
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{

    class Program
    {
        static void Main(string[] args)//This is the method that essentially runs everything. It makes a Game Object, and then it iterates the Play Method of 
            //Said Game object until there are 50 games.
        {




            Board testBoard = new Board();


            Game game = new Game();
            int resultMaxWins = 0;//This counts the amount of times that Max won.
            int resultMinWins = 0;//This counts the amount of times that Min won.
            int resultDraw = 0; //This counts the amount of times that the game resulted in a Draw.
            int result = 0;
            int counter = 0;
            for (counter = 0; counter < 50; counter++)//This is the method that "Plays" the game. The result of the game is returned, and the Loop
                //Will then increment the appropriate variable.
            {
                result = game.Play();
                if (result == 5)
                {
                    Console.WriteLine("Draw");
                    resultDraw++;
                }
                else if (result == 10)
                {
                    Console.WriteLine("Player Max (X) Won");
                    resultMaxWins++;
                }
                else
                {
                    Console.WriteLine("Player Min (O) Won");
                    resultMinWins++;
                }
                Console.WriteLine($"Press Enter to Start a New Game: Current Game: {counter + 1}");
                Console.ReadLine();
                Console.Clear();

            }
            Console.WriteLine("Max Won {1} Games, Min won {2} Games, {0} games resulted in a Draw", resultDraw, resultMaxWins, resultMinWins);
            Console.ReadLine();




        }

        //public void DisplayBoard(char[] charArray)
        //{
        //    for (int i = 0; i < 9; i++)
        //    {
        //        Console.Write("{0}", charArray[i]);
        //        if ((i + 1) % 3 == 0)
        //        {
        //            Console.WriteLine();
        //        }
        //    }
        //}


    }














}
