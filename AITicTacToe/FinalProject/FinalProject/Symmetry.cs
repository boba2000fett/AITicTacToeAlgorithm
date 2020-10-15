//Programmed by Trenton Andrews
//Comments by Trenton Andrews
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    //Programmed by Trenton Andrews
    /// <summary>
    /// This Class essentially sees whether or not a move has already been made, by taking Rotations and Reflections into account.
    /// Essentially, in the game of Tic-Tac-Toe, placing moves in certain positions can bring about logicall equilivant state spaces with the game board.
    /// For example, I am playing the game, and I am calculating my first move (Look at the game board below). I first evaluate 
    /// position 0. Positions 2,6, and 8 are logically equilivant to position 0, and they will result in a congruent state space. Thus, I do not have to make those moves, as I essentially 
    /// already made them. 
    /// 
    /// 0  |  1  |  2
    /// --------------
    /// 3  |  4  |  5
    /// --------------
    /// 6  |  7  |  8
    /// </summary>
    class Symmetry
    {
        /// <summary>
        /// This finds the points of symmetry on a Tic-Tac-Toe board using a SINGLE combination.
        /// </summary>                                                                  //            90  180 270
        private int[][] combinations = new int[][] //                         90  90  180 180 270 270 VF  VF  VF 
        //                                                  90 180 270 VF HF  VF  HF  VF  HF  VF  HF  HF  HF  HF    Index(Position of Move)
                                              { new int[] { 2, 8,  6,  2, 6 ,   8,  6,  2,  8,   6,    2 }, //0
                                                new int[] { 5, 7,  3,   7 , 3,  5,  7,  5,  3 , 3,    5},  //1
                                                new int[] { 8, 6,  0,  0, 8 , 6,    8,  0,    6 , 0,    8}, //2
                                                new int[] { 1, 5,  7,  5,  1,  7,    5,  7,  1 , 7,    1}, //3
                                                new int[] { 4, 4,  4,  4, 4 , 4,  4,  4,  4,  4,  4 , 4,  4,  4 },  //4
                                                new int[] { 7, 3,  1,  3,  7,  1,    3,  1,  7 , 1,    7 }, //5
                                                new int[] { 0, 2,  8,  8, 0 , 2,    0,  8,   2 , 8,  0}, //6
                                                new int[] { 3, 1,  5,  1 , 5,  3,  1,    3,  5 , 5,   3}, //7
                                                new int[] { 6, 0,  2,  6, 2 ,   0,  2,  6,  0,   2,    6}};//8


        //private int[][] combinations = new int[][] //                         90  90  180 180 270 270 VF  VF  VF 
        ////                                                  90 180 270 VF HF  VF  HF  VF  HF  VF  HF  HF  HF  HF    Index(Position of Move)
        //                                      { new int[] { 2, 8,  6,  2, 6 , 0,  8,  6,  2,  8,  0 , 6,  0,  2 }, //0
        //                                        new int[] { 5, 7,  3,  1, 7 , 3,  5,  7,  1,  5,  3 , 3,  1,  5},  //1
        //                                        new int[] { 8, 6,  0,  0, 8 , 6,  2,  8,  0,  2,  6 , 0,  2,  8}, //2
        //                                        new int[] { 1, 5,  7,  5, 3 , 1,  7,  3,  5,  7,  1 , 7,  3,  1}, //3
        //                                        new int[] { 4, 4,  4,  4, 4 , 4,  4,  4,  4,  4,  4 , 4,  4,  4 },  //4
        //                                        new int[] { 7, 3,  1,  3, 5 , 7,  1,  5,  3,  1,  7 , 1,  5,  7 }, //5
        //                                        new int[] { 0, 2,  8,  8, 0 , 2,  6,  0,  8,  6,  2 , 8,  6,  0}, //6
        //                                        new int[] { 3, 1,  5,  7, 1 , 5,  3,  1,  7,  3,  5 , 5,  7,  3}, //7
        //                                        new int[] { 6, 0,  2,  6, 2 , 8,  0,  2,  6,  0,  8 , 2,  8,  6}};//8












        ///// <summary>
        ///// This chart shows the points of symmetry using a DOUBLE combination.
        ///// (Pairing a Rotation and a Single Reflection)
        ///// </summary>                                                  
        //private int[][] doubleCombination = new int[][]
        ////                                              90  90  180 180 270 270
        ////                                              VF  HF  VF  HF  VF  HF    Index(Position of Move)
        //                                   {new int[]{  0,  8,  6,  2,  8,  0 },//0
        //                                    new int[]{  3,  5,  7,  1,  5,  3 },//1
        //                                    new int[]{  6,  2,  8,  0,  2,  6 },//2
        //                                    new int[]{  1,  7,  3,  5,  7,  1 },//3
        //                                    new int[]{  4,  4,  4,  4,  4,  4 },//4
        //                                    new int[]{  7,  1,  5,  3,  1,  7 },//5
        //                                    new int[]{  2,  6,  0,  8,  6,  2 },//6
        //                                    new int[]{  5,  3,  1,  7,  3,  5 },//7
        //                                    new int[]{  8,  0,  2,  6,  0,  8}};//8


        ///// <summary>
        ///// This chart shows the poitns of symmetry using a TRIPLE combination
        ///// (Pairing a Rotation with both Reflections)        
        ///// </summary>                         
        //private int[][] tripleCombination = new int[][]
        //                                                //90  180 270
        //                                                //VF  VF  VF
        //                                                //HF  HF  HF    Index(Position of Move)
        //{                                   new int[] {   6,  0,  2 },//0
        //                                    new int[] {   3,  1,  5 },//1
        //                                    new int[] {   0,  2,  8 },//2
        //                                    new int[] {   7,  3,  1 },//3
        //                                    new int[] {   4,  4,  4 },//4
        //                                    new int[] {   1,  5,  7 },//5
        //                                    new int[] {   8,  6,  0 },//6
        //                                    new int[] {   5,  7,  3 },//7
        //                                    new int[] {   2,  8,  6}};//8




        public Symmetry()
        {




        }

        //public bool CheckSymmetry(int[] moveList, int nextMove)
        //{
        //    if(SingleCombination(moveList, nextMove) != true &&
        //        DoubleCombination(moveList, nextMove) != true &&
        //        TripleCombination(moveList, nextMove) != true )
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }

        //}


        //public bool SingleCombination(int[] moveList, int nextMove, int[] movesOnBoard)//If the Move is found, the algorithm will return true. Otherwise, it will return false.
        //{
        //    int counter = 0;
        //    if(moveList.Count() == 0)
        //    {
        //        return false;
        //    }
        //    foreach(int previousMove in moveList)
        //    {                
        //        foreach(int movecurrentlyonBoard in movesOnBoard)
        //        {
        //            for (int i = 0; i < combinations[nextMove].Length; i++)
        //            {
        //                if (previousMove != nextMove)
        //                {
        //                    if (previousMove == combinations[nextMove][i] && movecurrentlyonBoard == combinations[movecurrentlyonBoard][i])
        //                    {
        //                        //return true;
        //                        counter++;
        //                    }
        //                }

        //            }
        //        }

        //    }

        //    if(counter < moveList.Count())
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }

        //    //return false;
        //}


        public bool CheckSymmetry(int[] moveList, int nextMove, int[] movesOnBoard)//If the Move is found, the algorithm will return true. Otherwise, it will return false.
        {
            int counter = 0;
            if (moveList.Count() == 0)
            {
                return false;
            }
            
            switch (movesOnBoard.Count())
            {
                case 0://This is used when there are currently no Moves on the board.
                    foreach (int previousMove in moveList)
                    {
                        for (int i = 0; i < combinations[nextMove].Length; i++)
                        {
                            if (previousMove != nextMove)
                            {
                                if (previousMove == combinations[nextMove][i])
                                {
                                    return true;
                                    //counter++;
                                }
                            }

                        }
                    }

                    break;
                case 1://This is used when there is 1 move already on the board
                    foreach (int previousMove in moveList)
                    {
                        for (int i = 0; i < combinations[nextMove].Length; i++ )
                        {
                            if (previousMove != nextMove)
                            {
                                if (previousMove == combinations[nextMove][i] && movesOnBoard[0] == combinations[movesOnBoard[0]][i])
                                {
                                    return true;
                                    //counter++;
                                }
                            }

                        }
                    }
                    break;

                case 2://This is used when there is 2 moves already on the board
                    foreach (int previousMove in moveList)
                    {
                        for (int i = 0; i < combinations[nextMove].Length; i++)
                        {
                            if (previousMove != nextMove)
                            {
                                if (previousMove == combinations[nextMove][i] &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[0]][i] || movesOnBoard[1] == combinations[movesOnBoard[0]][i] &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[1]][i] || movesOnBoard[1] == combinations[movesOnBoard[1]][i])))

                                {
                                    return true;
                                }
                            }

                        }
                    }
                    break;
                case 3: //This is used when there is 3 moves already on the board
                    foreach (int previousMove in moveList)
                    {
                        for (int i = 0; i < combinations[nextMove].Length; i++)
                        {
                            if (previousMove != nextMove)
                            {
                                if (previousMove == combinations[nextMove][i] &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[0]][i] || movesOnBoard[1] == combinations[movesOnBoard[0]][i] || movesOnBoard[2] == combinations[movesOnBoard[0]][i]) &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[1]][i] || movesOnBoard[1] == combinations[movesOnBoard[1]][i] || movesOnBoard[2] == combinations[movesOnBoard[1]][i]) &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[2]][i] || movesOnBoard[1] == combinations[movesOnBoard[2]][i] || movesOnBoard[2] == combinations[movesOnBoard[2]][i]))
                                {
                                    return true;
                                }
                            }

                        }
                    }

                    break;
                case 4://This is used when there is 4 moves already on the board
                    foreach (int previousMove in moveList)
                    {
                        for (int i = 0; i < combinations[nextMove].Length; i++)
                        {
                            if (previousMove != nextMove)
                            {
                                if (previousMove == combinations[nextMove][i] &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[0]][i] || movesOnBoard[1] == combinations[movesOnBoard[0]][i] || movesOnBoard[2] == combinations[movesOnBoard[0]][i] || movesOnBoard[3] == combinations[movesOnBoard[0]][i]) &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[1]][i] || movesOnBoard[1] == combinations[movesOnBoard[1]][i] || movesOnBoard[2] == combinations[movesOnBoard[1]][i] || movesOnBoard[3] == combinations[movesOnBoard[1]][i]) &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[2]][i] || movesOnBoard[1] == combinations[movesOnBoard[2]][i] || movesOnBoard[2] == combinations[movesOnBoard[2]][i] || movesOnBoard[3] == combinations[movesOnBoard[2]][i]) &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[3]][i] || movesOnBoard[1] == combinations[movesOnBoard[3]][i] || movesOnBoard[2] == combinations[movesOnBoard[3]][i] || movesOnBoard[3] == combinations[movesOnBoard[3]][i]))
                                {
                                    return true;
                                }
                            }

                        }
                    }
                    break;
                case 5://This is used when there is 5 moves already on the board
                    foreach (int previousMove in moveList)
                    {
                        for (int i = 0; i < combinations[nextMove].Length; i++)
                        {
                            if (previousMove != nextMove)
                            {
                                if (previousMove == combinations[nextMove][i] &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[0]][i] || movesOnBoard[1] == combinations[movesOnBoard[0]][i] || movesOnBoard[2] == combinations[movesOnBoard[0]][i] || movesOnBoard[3] == combinations[movesOnBoard[0]][i] || movesOnBoard[4] == combinations[movesOnBoard[0]][i]) &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[1]][i] || movesOnBoard[1] == combinations[movesOnBoard[1]][i] || movesOnBoard[2] == combinations[movesOnBoard[1]][i] || movesOnBoard[3] == combinations[movesOnBoard[1]][i] || movesOnBoard[4] == combinations[movesOnBoard[1]][i]) &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[2]][i] || movesOnBoard[1] == combinations[movesOnBoard[2]][i] || movesOnBoard[2] == combinations[movesOnBoard[2]][i] || movesOnBoard[3] == combinations[movesOnBoard[2]][i] || movesOnBoard[4] == combinations[movesOnBoard[2]][i]) &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[3]][i] || movesOnBoard[1] == combinations[movesOnBoard[3]][i] || movesOnBoard[2] == combinations[movesOnBoard[3]][i] || movesOnBoard[3] == combinations[movesOnBoard[3]][i] || movesOnBoard[4] == combinations[movesOnBoard[3]][i]) &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[4]][i] || movesOnBoard[1] == combinations[movesOnBoard[4]][i] || movesOnBoard[2] == combinations[movesOnBoard[4]][i] || movesOnBoard[3] == combinations[movesOnBoard[4]][i] || movesOnBoard[4] == combinations[movesOnBoard[4]][i]))
                                {
                                    return true;
                                }
                            }

                        }
                    }
                    break;
                case 6: //This is used when there is 6 moves already on the board
                    foreach (int previousMove in moveList)
                    {
                        for (int i = 0; i < combinations[nextMove].Length; i++)
                        {
                            if (previousMove != nextMove)
                            {
                                if (previousMove == combinations[nextMove][i] &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[0]][i] || movesOnBoard[1] == combinations[movesOnBoard[0]][i] || movesOnBoard[2] == combinations[movesOnBoard[0]][i] || movesOnBoard[3] == combinations[movesOnBoard[0]][i] || movesOnBoard[4] == combinations[movesOnBoard[0]][i] || movesOnBoard[5] == combinations[movesOnBoard[0]][i]) &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[1]][i] || movesOnBoard[1] == combinations[movesOnBoard[1]][i] || movesOnBoard[2] == combinations[movesOnBoard[1]][i] || movesOnBoard[3] == combinations[movesOnBoard[1]][i] || movesOnBoard[4] == combinations[movesOnBoard[1]][i] || movesOnBoard[5] == combinations[movesOnBoard[1]][i]) &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[2]][i] || movesOnBoard[1] == combinations[movesOnBoard[2]][i] || movesOnBoard[2] == combinations[movesOnBoard[2]][i] || movesOnBoard[3] == combinations[movesOnBoard[2]][i] || movesOnBoard[4] == combinations[movesOnBoard[2]][i] || movesOnBoard[5] == combinations[movesOnBoard[2]][i]) &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[3]][i] || movesOnBoard[1] == combinations[movesOnBoard[3]][i] || movesOnBoard[2] == combinations[movesOnBoard[3]][i] || movesOnBoard[3] == combinations[movesOnBoard[3]][i] || movesOnBoard[4] == combinations[movesOnBoard[3]][i] || movesOnBoard[5] == combinations[movesOnBoard[3]][i]) &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[4]][i] || movesOnBoard[1] == combinations[movesOnBoard[4]][i] || movesOnBoard[2] == combinations[movesOnBoard[4]][i] || movesOnBoard[3] == combinations[movesOnBoard[4]][i] || movesOnBoard[4] == combinations[movesOnBoard[4]][i] || movesOnBoard[5] == combinations[movesOnBoard[4]][i]) &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[5]][i] || movesOnBoard[1] == combinations[movesOnBoard[5]][i] || movesOnBoard[2] == combinations[movesOnBoard[5]][i] || movesOnBoard[3] == combinations[movesOnBoard[5]][i] || movesOnBoard[5] == combinations[movesOnBoard[5]][i] || movesOnBoard[5] == combinations[movesOnBoard[5]][i]))
                                {
                                    return true;
                                }
                            }

                        }
                    }
                    break;
                case 7: //This is used when there is 7 moves already on the board
                    foreach (int previousMove in moveList)
                    {
                        for (int i = 0; i < combinations[nextMove].Length; i++)
                        {
                            if (previousMove != nextMove)
                            {
                                if (previousMove == combinations[nextMove][i] &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[0]][i] || movesOnBoard[1] == combinations[movesOnBoard[0]][i] || movesOnBoard[2] == combinations[movesOnBoard[0]][i] || movesOnBoard[3] == combinations[movesOnBoard[0]][i] || movesOnBoard[4] == combinations[movesOnBoard[0]][i] || movesOnBoard[5] == combinations[movesOnBoard[0]][i] || movesOnBoard[6] == combinations[movesOnBoard[0]][i]) &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[1]][i] || movesOnBoard[1] == combinations[movesOnBoard[1]][i] || movesOnBoard[2] == combinations[movesOnBoard[1]][i] || movesOnBoard[3] == combinations[movesOnBoard[1]][i] || movesOnBoard[4] == combinations[movesOnBoard[1]][i] || movesOnBoard[5] == combinations[movesOnBoard[1]][i] || movesOnBoard[6] == combinations[movesOnBoard[1]][i]) &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[2]][i] || movesOnBoard[1] == combinations[movesOnBoard[2]][i] || movesOnBoard[2] == combinations[movesOnBoard[2]][i] || movesOnBoard[3] == combinations[movesOnBoard[2]][i] || movesOnBoard[4] == combinations[movesOnBoard[2]][i] || movesOnBoard[5] == combinations[movesOnBoard[2]][i] || movesOnBoard[6] == combinations[movesOnBoard[2]][i]) &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[3]][i] || movesOnBoard[1] == combinations[movesOnBoard[3]][i] || movesOnBoard[2] == combinations[movesOnBoard[3]][i] || movesOnBoard[3] == combinations[movesOnBoard[3]][i] || movesOnBoard[4] == combinations[movesOnBoard[3]][i] || movesOnBoard[5] == combinations[movesOnBoard[3]][i] || movesOnBoard[6] == combinations[movesOnBoard[3]][i]) &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[4]][i] || movesOnBoard[1] == combinations[movesOnBoard[4]][i] || movesOnBoard[2] == combinations[movesOnBoard[4]][i] || movesOnBoard[3] == combinations[movesOnBoard[4]][i] || movesOnBoard[4] == combinations[movesOnBoard[4]][i] || movesOnBoard[5] == combinations[movesOnBoard[4]][i] || movesOnBoard[6] == combinations[movesOnBoard[4]][i]) &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[5]][i] || movesOnBoard[1] == combinations[movesOnBoard[5]][i] || movesOnBoard[2] == combinations[movesOnBoard[5]][i] || movesOnBoard[3] == combinations[movesOnBoard[5]][i] || movesOnBoard[5] == combinations[movesOnBoard[5]][i] || movesOnBoard[5] == combinations[movesOnBoard[5]][i] || movesOnBoard[6] == combinations[movesOnBoard[5]][i]) &&
                                    (movesOnBoard[0] == combinations[movesOnBoard[6]][i] || movesOnBoard[1] == combinations[movesOnBoard[6]][i] || movesOnBoard[2] == combinations[movesOnBoard[6]][i] || movesOnBoard[3] == combinations[movesOnBoard[6]][i] || movesOnBoard[5] == combinations[movesOnBoard[6]][i] || movesOnBoard[5] == combinations[movesOnBoard[6]][i] || movesOnBoard[6] == combinations[movesOnBoard[6]][i]))
                                {
                                    return true;
                                }
                            }

                        }
                    }
                    break;

            }
            return false;
            
        }




    }


}
