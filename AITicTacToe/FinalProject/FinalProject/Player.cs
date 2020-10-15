//Programmed by Trenton Andrews
//Comments by Nate Wright and Trenton Andrews
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{


    class Player
    {
        int playerType;
        Node gameNode;
        Node currentNode;
        bool isMax;

        public Player(int player)
        {
            playerType = player;
        }

        public void RefreshNodes(Node currentNode)
        {

        }

        public int Minimax(Node rootNode, Board gameBoard, bool isMax, int depth, int maxDepth)//This is the MiniMax algorithm that is used to create our depth tree.
        {
            LinkedList<int> moveList = new LinkedList<int>();
            int heuristic = -61;
            Node newNode;
            int[] movesAvailable = rootNode.GetAvailablePositions();

            if (gameBoard.HasGameEnded() != 0)
            {
                return 0;
                
            }


            if (depth <= maxDepth)
            {
                if (isMax)//This checks to see if the Max player is the one that triggered this event, based on the current move, it will create a child node based on the root node.
                {


                    for (int q = 0; q < movesAvailable.Count(); q++)
                    {

                        if (depth == maxDepth || movesAvailable.Count() == 1)
                        {
                            newNode = rootNode.AddChildNode(movesAvailable[q], Piece.X, moveList.ToArray(), true);//This line will attempt to add an X at the first spot available.
                                //If the depth is equal to MaxDepth, meaning the bottom of the tree has been reached, then the new object created will have a heuristic evaluation. 
                        
                        }
                        else
                        {
                            
                            newNode = rootNode.AddChildNode(movesAvailable[q], Piece.X, moveList.ToArray(), false);//This line will attempt to add an X at the first spot available.
                        }

                        if (newNode != null)//This essentially checks if the AddChildMethod was successful in placing a Move at the spot.
                        {
                            moveList.AddLast(movesAvailable[q]);                            
                            Minimax(newNode, gameBoard, false, depth + 1, maxDepth);//Here the MiniMax method is called again, passing newNode into it.
                            newNode.RemovePiece(movesAvailable[q]);//After the method is returned, the move that was placed on the board above is now removed.
                        }
                       

                    }

                    rootNode.Perculate(isMax);

                }
                else //This checks to see if the Min player is the one that triggered this event, based on the current move, it will create a child node based on the root node.
                {
                    for (int z = 0; z < movesAvailable.Count(); z++)
                    {

                        if (depth == maxDepth || movesAvailable.Count() == 1)
                        {
                            newNode = rootNode.AddChildNode(movesAvailable[z], Piece.O, moveList.ToArray(), true);//This line will attempt to add an O at the first spot available.
                            //If the depth is equal to MaxDepth, meaning the bottom of the tree has been reached, then the new object created will have a heuristic evaluation. 
                        }
                        else
                        {
                            newNode = rootNode.AddChildNode(movesAvailable[z], Piece.O, moveList.ToArray(), false);//This line will attempt to add an O at the first spot available.
                        }

                        if (newNode != null )
                        {
                            moveList.AddLast(movesAvailable[z]);
                            Minimax(newNode, gameBoard, true, depth + 1, maxDepth);// Here the MiniMax method is called again, passing newNode into it.
                            newNode.RemovePiece(movesAvailable[z]);
                        }
                       

                    }

                    rootNode.Perculate(isMax);//This "Perculates" the values up the tree. This is where the Parent gets either the max or min of the Child Nodes,
                }

            }
            
            return rootNode.GetBestMove();//Here, the root returns the best move. Meaning, the root will return the position that gave the highest (or lowest) heuristic value.

        }

        public Node GetBoard()
        {
            return gameNode;
        }

        

    }





}
