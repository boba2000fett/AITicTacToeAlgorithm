//Programmed by Trenton Andrews
//Comments by Nate Wright
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{

    public enum Piece
    {
        Empty,
        X,
        O
    }
    class Board
    {
        public Piece[] gameArray = new Piece[9]; //Creates an Array called gameArray that holds 9 pieces.

        int spacesAvailable;
        int i; //Loop variable
        int a;//Loop variable
        int heuristic; //This is the heuristic evaulation of the Board.
        int minHeuristic;
        int maxHeuristic;
        int[,] winConditions = //This is an Array that holds the direction that is consided a win condition.
           {{0,1,2 },
            {3,4,5 },
            {6,7,8 },
            {0,3,6 },
            {1,4,7 },
            {2,5,8 },
            {0,4,8 },
            {2,4,6 }};

        bool[] heuristicFound = new bool[8];//I added this. This is like a parallel array to winConditions, and it is used for the HeuristicEvaluation method. Essentially,
        //It is here to make it so the same row, column, or diagnoal is not counted multiple times in the heuristic evauluation of the board. 

        public Board()
        {

        }
        public Board(Piece[] gameBoard)
        {

        }

        public int HasGameEnded() //Checks to see if any of the piece are in the state of a Win Condition, then declares a Winner.
        {
            for (i = 0; i < 8; i++)
            {
                if (gameArray[winConditions[i, 0]].Equals(Piece.X) &&
                    gameArray[winConditions[i, 1]].Equals(Piece.X) &&
                    gameArray[winConditions[i, 2]].Equals(Piece.X))
                {
                    return 10;
                }
                else if (gameArray[winConditions[i, 0]].Equals(Piece.O) &&
                    gameArray[winConditions[i, 1]].Equals(Piece.O) &&
                    gameArray[winConditions[i, 2]].Equals(Piece.O))
                {
                    return -10;
                }
            }
            int counter = 0;
            for(i = 0; i < 9; i++)
            {
                if (!gameArray[i].Equals(Piece.Empty))
                {
                    counter++;
                }
            }
            if(counter == 9)
            {
                return 5;
            }
            return 0;
        }

        public bool PlacePiece(int position, Piece gamePiece) //Method we use to add a piece to the board. It first checks if the spot is empty. If it is, then it places the piece
            //and returns true. If it is not empty, or there is a piece in that spot, then it will return False.
        {
                  
            if (gameArray[position].Equals(Piece.Empty))
            {
                gameArray[position] = gamePiece;
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public void RemovePiece(int position) //Method we use to remove Game Pieces from the Board.
        {
            gameArray[position] = Piece.Empty;
        }

        public int GetHeuristic() //Method we use to Get the Heuristic value of each row, so the A.I. can find the next best move it could make.
        {
            bool found = false;
            heuristic = 0;
            maxHeuristic = 0;
            minHeuristic = 0;
            for (i = 0; i < 8; i++)
            {
                heuristicFound[i] = false;
            }


            for (i = 0; i < 9; i++) //This goes through a switch statement, and compares the heuristic values of each direction to determine where the next piece should go.
            {

                    if (gameArray[i].Equals(Piece.X))
                    {

                        switch (i)
                        {
                            case 0:
                                if (gameArray[i + 1].Equals(Piece.Empty) && gameArray[i + 2].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.X) && gameArray[i + 2].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.Empty) && gameArray[i + 2].Equals(Piece.X))//This checks the Row
                                {
                                    if (heuristicFound[0] == false)
                                    {

                                        maxHeuristic++;
                                        heuristicFound[0] = true;
                                    }

                                }
                                if (gameArray[i + 3].Equals(Piece.Empty) && gameArray[i + 6].Equals(Piece.Empty) ||
                                    gameArray[i + 3].Equals(Piece.X) && gameArray[i + 6].Equals(Piece.Empty) ||
                                    gameArray[i + 3].Equals(Piece.Empty) && gameArray[i + 6].Equals(Piece.X))//This checks the Column
                                {
                                    if (heuristicFound[3] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[3] = true;
                                    }
                                }
                                if (gameArray[i + 4].Equals(Piece.Empty) && gameArray[i + 8].Equals(Piece.Empty) ||
                                    gameArray[i + 4].Equals(Piece.X) && gameArray[i + 8].Equals(Piece.Empty) ||
                                    gameArray[i + 4].Equals(Piece.Empty) && gameArray[i + 8].Equals(Piece.X))//This checks the Diagnoal
                                {
                                    if (heuristicFound[6] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[6] = true;
                                    }
                                }
                                break;
                            case 1:
                                if (gameArray[i + 1].Equals(Piece.Empty) && gameArray[i - 1].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.X) && gameArray[i - 1].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.Empty) && gameArray[i - 1].Equals(Piece.X))//This checks the row 
                                {
                                    if (heuristicFound[0] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[0] = true;
                                    }
                                }
                                if (gameArray[i + 3].Equals(Piece.Empty) && gameArray[i + 6].Equals(Piece.Empty) ||
                                    gameArray[i + 3].Equals(Piece.X) && gameArray[i + 6].Equals(Piece.Empty) ||
                                    gameArray[i + 3].Equals(Piece.Empty) && gameArray[i + 6].Equals(Piece.X))//This checks the column
                                {
                                    if (heuristicFound[4] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[4] = true;
                                    }
                                }
                                break;
                            case 2:
                                if (gameArray[i - 1].Equals(Piece.Empty) && gameArray[i - 2].Equals(Piece.Empty) ||
                                    gameArray[i - 1].Equals(Piece.X) && gameArray[i - 2].Equals(Piece.Empty) ||
                                    gameArray[i - 1].Equals(Piece.Empty) && gameArray[i - 2].Equals(Piece.X))//This checks the row
                                {
                                    if (heuristicFound[0] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[0] = true;
                                    }
                                }
                                if (gameArray[i + 3].Equals(Piece.Empty) && gameArray[i + 6].Equals(Piece.Empty) ||
                                    gameArray[i + 3].Equals(Piece.X) && gameArray[i + 6].Equals(Piece.Empty) ||
                                    gameArray[i + 3].Equals(Piece.Empty) && gameArray[i + 6].Equals(Piece.X))//This checks the column
                                {
                                    if (heuristicFound[5] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[5] = true;
                                    }
                                }
                                if (gameArray[i + 2].Equals(Piece.Empty) && gameArray[i + 4].Equals(Piece.Empty) ||
                                    gameArray[i + 2].Equals(Piece.X) && gameArray[i + 4].Equals(Piece.Empty) ||
                                    gameArray[i + 2].Equals(Piece.Empty) && gameArray[i + 4].Equals(Piece.X))//This checks the diagnoal
                                {
                                    if (heuristicFound[7] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[7] = true;
                                    }
                                }
                                break;
                            case 3:
                                if (gameArray[i + 1].Equals(Piece.Empty) && gameArray[i + 2].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.X) && gameArray[i + 2].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.Empty) && gameArray[i + 2].Equals(Piece.X))//this checks row
                                {
                                    if (heuristicFound[1] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[1] = true;
                                    }
                                }
                                if (gameArray[i - 3].Equals(Piece.Empty) && gameArray[i + 3].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.X) && gameArray[i + 3].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.Empty) && gameArray[i + 3].Equals(Piece.X))//This checks the column
                                {
                                    if (heuristicFound[3] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[3] = true;
                                    }
                                }
                                break;

                            case 4:
                                if (gameArray[i + 1].Equals(Piece.Empty) && gameArray[i - 1].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.X) && gameArray[i - 1].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.Empty) && gameArray[i - 1].Equals(Piece.X))//This checks the row
                                {
                                    if (heuristicFound[1] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[1] = true;
                                    }
                                }
                                if (gameArray[i - 4].Equals(Piece.Empty) && gameArray[i + 4].Equals(Piece.Empty) ||
                                    gameArray[i - 4].Equals(Piece.X) && gameArray[i + 4].Equals(Piece.Empty) ||
                                    gameArray[i - 4].Equals(Piece.Empty) && gameArray[i + 4].Equals(Piece.X))//This checks the diagnoal (Locations 0,4, and 8)
                                {
                                    if (heuristicFound[6] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[6] = true;
                                    }
                                }
                                if (gameArray[i - 2].Equals(Piece.Empty) && gameArray[i + 2].Equals(Piece.Empty) ||
                                    gameArray[i - 2].Equals(Piece.X) && gameArray[i + 2].Equals(Piece.Empty) ||
                                    gameArray[i - 2].Equals(Piece.Empty) && gameArray[i + 2].Equals(Piece.X))//This checks the diagnoal (Locations 2,4, and 6)
                                {
                                    if (heuristicFound[7] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[7] = true;
                                    }
                                }
                                if (gameArray[i - 3].Equals(Piece.Empty) && gameArray[i + 3].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.X) && gameArray[i + 3].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.Empty) && gameArray[i + 3].Equals(Piece.X))//This checks the column
                                {
                                    if (heuristicFound[4] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[4] = true;
                                    }
                                }
                                break;
                            case 5:
                                if (gameArray[i - 2].Equals(Piece.Empty) && gameArray[i - 1].Equals(Piece.Empty) ||
                                    gameArray[i - 2].Equals(Piece.X) && gameArray[i - 1].Equals(Piece.Empty) ||
                                    gameArray[i - 2].Equals(Piece.Empty) && gameArray[i - 1].Equals(Piece.X))//This checks the row
                                {
                                    if (heuristicFound[1] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[1] = true;
                                    }
                                }
                                if (gameArray[i - 3].Equals(Piece.Empty) && gameArray[i + 3].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.X) && gameArray[i + 3].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.Empty) && gameArray[i + 3].Equals(Piece.X))//This checks the column
                                {
                                    if (heuristicFound[5] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[5] = true;
                                    }
                                }
                                break;
                            case 6:
                                if (gameArray[i + 1].Equals(Piece.Empty) && gameArray[i + 2].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.X) && gameArray[i + 2].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.Empty) && gameArray[i + 2].Equals(Piece.X))//Row check
                                {
                                    if (heuristicFound[2] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[2] = true;
                                    }
                                }
                                if (gameArray[i - 4].Equals(Piece.Empty) && gameArray[i - 2].Equals(Piece.Empty) ||
                                    gameArray[i - 4].Equals(Piece.X) && gameArray[i - 2].Equals(Piece.Empty) ||
                                    gameArray[i - 4].Equals(Piece.Empty) && gameArray[i - 2].Equals(Piece.X))//Diagnoal check
                                {
                                    if (heuristicFound[7] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[7] = true;
                                    }
                                }
                                if (gameArray[i - 3].Equals(Piece.Empty) && gameArray[i - 6].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.X) && gameArray[i - 6].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.Empty) && gameArray[i - 6].Equals(Piece.X))//Column check
                                {
                                    if (heuristicFound[3] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[3] = true;
                                    }
                                }
                                break;
                            case 7:
                                if (gameArray[i + 1].Equals(Piece.Empty) && gameArray[i - 1].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.X) && gameArray[i - 1].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.Empty) && gameArray[i - 1].Equals(Piece.X))//Row check
                                {
                                    if (heuristicFound[2] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[2] = true;
                                    }
                                }
                                if (gameArray[i - 3].Equals(Piece.Empty) && gameArray[i - 6].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.X) && gameArray[i - 6].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.Empty) && gameArray[i - 6].Equals(Piece.X))//Column check
                                {
                                    if (heuristicFound[4] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[4] = true;
                                    }
                                }
                                break;
                            case 8:
                                if (gameArray[i - 2].Equals(Piece.Empty) && gameArray[i - 1].Equals(Piece.Empty) ||
                                    gameArray[i - 2].Equals(Piece.X) && gameArray[i - 1].Equals(Piece.Empty) ||
                                    gameArray[i - 2].Equals(Piece.Empty) && gameArray[i - 1].Equals(Piece.X))//Row check
                                {
                                    if (heuristicFound[2] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[2] = true;
                                    }
                                }
                                if (gameArray[i - 4].Equals(Piece.Empty) && gameArray[i - 8].Equals(Piece.Empty) ||
                                    gameArray[i - 4].Equals(Piece.X) && gameArray[i - 8].Equals(Piece.Empty) ||
                                    gameArray[i - 4].Equals(Piece.Empty) && gameArray[i - 8].Equals(Piece.X))
                                {
                                    if (heuristicFound[6] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[6] = true;
                                    }
                                }
                                if (gameArray[i - 3].Equals(Piece.Empty) && gameArray[i - 6].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.X) && gameArray[i - 6].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.Empty) && gameArray[i - 6].Equals(Piece.X))//Column check
                                {
                                    if (heuristicFound[5] == false)
                                    {
                                        maxHeuristic++;
                                        heuristicFound[5] = true;
                                    }
                                }
                                break;
                        }
                    }
                    else if (gameArray[i].Equals(Piece.O))
                    {
                        switch (i)
                        {
                            case 0:
                            if (gameArray[i + 1].Equals(Piece.Empty) && gameArray[i + 2].Equals(Piece.Empty) ||
                                gameArray[i + 1].Equals(Piece.O) && gameArray[i + 2].Equals(Piece.Empty) ||
                                gameArray[i + 1].Equals(Piece.Empty) && gameArray[i + 2].Equals(Piece.O))//This checks the Row
                            {
                                
                                if (heuristicFound[0] == false)
                                {
                                    
                                        minHeuristic++;
                                    
                                    
                                    heuristicFound[0] = true;
                                }

                            }
                                if (gameArray[i + 3].Equals(Piece.Empty) && gameArray[i + 6].Equals(Piece.Empty) ||
                                    gameArray[i + 3].Equals(Piece.O) && gameArray[i + 6].Equals(Piece.Empty) ||
                                    gameArray[i + 3].Equals(Piece.Empty) && gameArray[i + 6].Equals(Piece.O))//This checks the Column
                                {
                                    if (heuristicFound[3] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[3] = true;
                                    }
                                }
                                if (gameArray[i + 4].Equals(Piece.Empty) && gameArray[i + 8].Equals(Piece.Empty) ||
                                    gameArray[i + 4].Equals(Piece.O) && gameArray[i + 8].Equals(Piece.Empty) ||
                                    gameArray[i + 4].Equals(Piece.Empty) && gameArray[i + 8].Equals(Piece.O))//This checks the Diagnoal
                                {
                                    if (heuristicFound[6] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[6] = true;
                                    }
                                }
                                break;
                            case 1:
                                if (gameArray[i + 1].Equals(Piece.Empty) && gameArray[i - 1].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.O) && gameArray[i - 1].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.Empty) && gameArray[i - 1].Equals(Piece.O))//This checks the row 
                                {
                                    if (heuristicFound[0] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[0] = true;
                                    }
                                }
                                if (gameArray[i + 3].Equals(Piece.Empty) && gameArray[i + 6].Equals(Piece.Empty) ||
                                    gameArray[i + 3].Equals(Piece.O) && gameArray[i + 6].Equals(Piece.Empty) ||
                                    gameArray[i + 3].Equals(Piece.Empty) && gameArray[i + 6].Equals(Piece.O))//This checks the column
                                {
                                    if (heuristicFound[4] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[4] = true;
                                    }
                                }
                                break;
                            case 2:
                                if (gameArray[i - 1].Equals(Piece.Empty) && gameArray[i - 2].Equals(Piece.Empty) ||
                                    gameArray[i - 1].Equals(Piece.O) && gameArray[i - 2].Equals(Piece.Empty) ||
                                    gameArray[i - 1].Equals(Piece.Empty) && gameArray[i - 2].Equals(Piece.O))//This checks the row
                                {
                                    if (heuristicFound[0] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[0] = true;
                                    }
                                }
                                if (gameArray[i + 3].Equals(Piece.Empty) && gameArray[i + 6].Equals(Piece.Empty) ||
                                    gameArray[i + 3].Equals(Piece.O) && gameArray[i + 6].Equals(Piece.Empty) ||
                                    gameArray[i + 3].Equals(Piece.Empty) && gameArray[i + 6].Equals(Piece.O))//This checks the column
                                {
                                    if (heuristicFound[5] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[5] = true;
                                    }
                                }
                                if (gameArray[i + 2].Equals(Piece.Empty) && gameArray[i + 4].Equals(Piece.Empty) ||
                                    gameArray[i + 2].Equals(Piece.O) && gameArray[i + 4].Equals(Piece.Empty) ||
                                    gameArray[i + 2].Equals(Piece.Empty) && gameArray[i + 4].Equals(Piece.O))//This checks the diagnoal
                                {
                                    if (heuristicFound[7] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[7] = true;
                                    }
                                }
                                break;
                            case 3:
                                if (gameArray[i + 1].Equals(Piece.Empty) && gameArray[i + 2].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.O) && gameArray[i + 2].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.Empty) && gameArray[i + 2].Equals(Piece.O))//this checks row
                                {
                                    if (heuristicFound[1] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[1] = true;
                                    }
                                }
                                if (gameArray[i - 3].Equals(Piece.Empty) && gameArray[i + 3].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.O) && gameArray[i + 3].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.Empty) && gameArray[i + 3].Equals(Piece.O))//This checks the column
                                {
                                    if (heuristicFound[3] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[3] = true;
                                    }
                                }
                                break;

                            case 4:
                                if (gameArray[i + 1].Equals(Piece.Empty) && gameArray[i - 1].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.O) && gameArray[i - 1].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.Empty) && gameArray[i - 1].Equals(Piece.O))//This checks the row
                                {
                                    if (heuristicFound[1] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[1] = true;
                                    }
                                }
                                if (gameArray[i - 4].Equals(Piece.Empty) && gameArray[i + 4].Equals(Piece.Empty) ||
                                    gameArray[i - 4].Equals(Piece.O) && gameArray[i + 4].Equals(Piece.Empty) ||
                                    gameArray[i - 4].Equals(Piece.Empty) && gameArray[i + 4].Equals(Piece.O))//This checks the diagnoal (Locations 0,4, and 8)
                                {
                                    if (heuristicFound[6] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[6] = true;
                                    }
                                }
                                if (gameArray[i - 2].Equals(Piece.Empty) && gameArray[i + 2].Equals(Piece.Empty) ||
                                    gameArray[i - 2].Equals(Piece.O) && gameArray[i + 2].Equals(Piece.Empty) ||
                                    gameArray[i - 2].Equals(Piece.Empty) && gameArray[i + 2].Equals(Piece.O))//This checks the diagnoal (Locations 2,4, and 6)
                                {
                                    if (heuristicFound[7] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[7] = true;
                                    }
                                }
                                if (gameArray[i - 3].Equals(Piece.Empty) && gameArray[i + 3].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.O) && gameArray[i + 3].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.Empty) && gameArray[i + 3].Equals(Piece.O))//This checks the column
                                {
                                    if (heuristicFound[4] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[4] = true;
                                    }
                                }
                                break;
                            case 5:
                                if (gameArray[i - 2].Equals(Piece.Empty) && gameArray[i - 1].Equals(Piece.Empty) ||
                                    gameArray[i - 2].Equals(Piece.O) && gameArray[i - 1].Equals(Piece.Empty) ||
                                    gameArray[i - 2].Equals(Piece.Empty) && gameArray[i - 1].Equals(Piece.O))//This checks the row
                                {
                                    if (heuristicFound[1] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[1] = true;
                                    }
                                }
                                if (gameArray[i - 3].Equals(Piece.Empty) && gameArray[i + 3].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.O) && gameArray[i + 3].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.Empty) && gameArray[i + 3].Equals(Piece.O))//This checks the column
                                {
                                    if (heuristicFound[5] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[5] = true;
                                    }
                                }
                                break;
                            case 6:
                                if (gameArray[i + 1].Equals(Piece.Empty) && gameArray[i + 2].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.O) && gameArray[i + 2].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.Empty) && gameArray[i + 2].Equals(Piece.O))//Row check
                                {
                                    if (heuristicFound[2] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[2] = true;
                                    }
                                }
                                if (gameArray[i - 4].Equals(Piece.Empty) && gameArray[i - 2].Equals(Piece.Empty) ||
                                    gameArray[i - 4].Equals(Piece.O) && gameArray[i - 2].Equals(Piece.Empty) ||
                                    gameArray[i - 4].Equals(Piece.Empty) && gameArray[i - 2].Equals(Piece.O))//Diagnoal check
                                {
                                    if (heuristicFound[7] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[7] = true;
                                    }
                                }
                                if (gameArray[i - 3].Equals(Piece.Empty) && gameArray[i - 6].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.O) && gameArray[i - 6].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.Empty) && gameArray[i - 6].Equals(Piece.O))//Column check
                                {
                                    if (heuristicFound[3] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[3] = true;
                                    }
                                }
                                break;
                            case 7:
                                if (gameArray[i + 1].Equals(Piece.Empty) && gameArray[i - 1].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.O) && gameArray[i - 1].Equals(Piece.Empty) ||
                                    gameArray[i + 1].Equals(Piece.Empty) && gameArray[i - 1].Equals(Piece.O))//Row check
                                {
                                    if (heuristicFound[2] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[2] = true;
                                    }
                                }
                                if (gameArray[i - 3].Equals(Piece.Empty) && gameArray[i - 6].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.O) && gameArray[i - 6].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.Empty) && gameArray[i - 6].Equals(Piece.O))//Column check
                                {
                                    if (heuristicFound[4] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[4] = true;
                                    }
                                }
                                break;
                            case 8:
                                if (gameArray[i - 2].Equals(Piece.Empty) && gameArray[i - 1].Equals(Piece.Empty) ||
                                    gameArray[i - 2].Equals(Piece.O) && gameArray[i - 1].Equals(Piece.Empty) ||
                                    gameArray[i - 2].Equals(Piece.Empty) && gameArray[i - 1].Equals(Piece.O))//Row check
                                {
                                    if (heuristicFound[2] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[2] = true;
                                    }
                                }
                                if (gameArray[i - 4].Equals(Piece.Empty) && gameArray[i - 8].Equals(Piece.Empty) ||
                                    gameArray[i - 4].Equals(Piece.O) && gameArray[i - 8].Equals(Piece.Empty) ||
                                    gameArray[i - 4].Equals(Piece.Empty) && gameArray[i - 8].Equals(Piece.O))
                                {
                                    if (heuristicFound[6] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[6] = true;
                                    }
                                }
                                if (gameArray[i - 3].Equals(Piece.Empty) && gameArray[i - 6].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.O) && gameArray[i - 6].Equals(Piece.Empty) ||
                                    gameArray[i - 3].Equals(Piece.Empty) && gameArray[i - 6].Equals(Piece.O))//Column check
                                {
                                    if (heuristicFound[5] == false)
                                    {
                                        minHeuristic++;
                                        heuristicFound[5] = true;
                                    }
                                }
                                break;
                        }
                    }
                }
            // }
            


            
            heuristic = maxHeuristic - minHeuristic; //Here is the heurisitc evauluation E(X) = N(X) - O(X)




            return heuristic;
        }

       

        public char[] DisplayGame() //Displays the current board state, starts out as an empty grid, but then gets populated with X's, and O's.
        {
            char[] charArray = new char[9];
            for (i = 0; i < 9; i++)
            {
                if (gameArray[i].Equals(Piece.X))
                {
                    charArray[i] = 'X';
                }
                else if (gameArray[i].Equals(Piece.O))
                {
                    charArray[i] = 'O';
                }
                else
                {
                    charArray[i] = ' ';
                }
            }
            return charArray;
        }

        public void ResetGame() //Resets the currrent Game to its starting condition, a empty grid.
        {
            for (i = 0; i < 9; i++)
            {
                gameArray[i] = Piece.Empty;
            }
        }

        public int[] usedPositions() //This keeps track of what positions are currently occupied.
        {
            LinkedList<int> usedPositions = new LinkedList<int>();
            for (i = 0; i < 9; i++)
            {
                if (!gameArray[i].Equals(Piece.Empty))
                {
                    usedPositions.AddLast(i);
                }
            }
            return usedPositions.ToArray();

        }

        public bool[] BetterusedPositions() //Make Comment Here about What makes this constructor different
        {
            LinkedList<bool> BetterusedPositions = new LinkedList<bool>();
            for (i = 0; i < 9; i++)
            {
                if (!gameArray[i].Equals(Piece.Empty))
                {
                    if (gameArray[i].Equals(Piece.X))
                        BetterusedPositions.AddLast(true);
                    else
                        BetterusedPositions.AddLast(false);
                }
            }
            return BetterusedPositions.ToArray();

        }

        public int[] GetAvailablePositions() //This keeps track of what positions are currently available.
        {
            LinkedList<int> usedPositions = new LinkedList<int>();
            for (i = 0; i < 9; i++)
            {
                if (gameArray[i].Equals(Piece.Empty))
                {
                    usedPositions.AddLast(i);
                }
            }
            return usedPositions.ToArray();
        }


    }




}
