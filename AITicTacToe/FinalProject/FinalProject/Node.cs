//Programmed by Trenton Andrews
//Comments by Nate Wright
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{

    class Node : IComparable
    {
        private Node parentNode;
        private LinkedList<Node> childrenNodeList = new LinkedList<Node>();
        private int heuristicValue;
        private int positionOnBoard;
        Board board;
        private Symmetry sym = new Symmetry();
        private int childPosition;


        public Node(int position, Board gameBoard)
        {//Constructor for a Node object.
            parentNode = null;
            positionOnBoard = position;
            board = gameBoard;
        }
        public Node(Node parentNode, int position, Board gameBoard, bool isLeafNode)//I ADDED A PARAMETER SO WHEN YOU CREATE THE OBJECT, you get the heuristic
        {//Constructor for a Node object, using this one your able to get the heuristic value.
            this.parentNode = parentNode;
            positionOnBoard = position;
            board = gameBoard;
            int ended = gameBoard.HasGameEnded();
            if (ended != 0)
            {
                this.heuristicValue = ended;
            }
            else if(isLeafNode)
            {
                heuristicValue = board.GetHeuristic();
            }
        }
        public Node(Node parentNode, int position, Board gameBoard, bool isLeafNode, Piece gamePiece)
        {
            this.parentNode = parentNode;
            this.positionOnBoard = position;
            this.board = gameBoard;
            this.parentNode.childrenNodeList.AddLast(this);
            this.board.PlacePiece(position, gamePiece);
             if (isLeafNode)
            {
                this.heuristicValue = board.GetHeuristic();
            }
        }


        public int Perculate(bool isMax)
        {//Method to get the heuristic value of a child node.
            heuristicValue = MaxorMinChildNode(isMax);

            childPosition = MaxorMinChildNodePOSITION(isMax);
            //return MaxorMinChildNodePOSITION(isMax);
            return heuristicValue;
        }

        public Node AddChildNode(int position, Piece gamePiece, int[] moveList, bool isLeafNode)//I CHANGED THE ADDCHILDNODE TO RETURN A NODE, THIS IS SO YOU CAN RETRIEVE A NODE INSTANCE 
        {
            //Method to add a child node based on the last move made.

            //if (board.PlacePiece(position, gamePiece) == true)//Make Comment Here about What makes this constructor different
            //{
            //    Node childNode = new Node(this, position, board, isLeafNode);

            //    childrenNodeList.AddLast(childNode);
            //    //board.RemovePiece(position);
            //    return childNode;
            //}
            //return null;

            if (sym.CheckSymmetry(moveList, position, board.usedPositions()) == false)//Make Comment Here about What makes this constructor different
            {
                if (board.PlacePiece(position, gamePiece) == true)//Make Comment Here about What makes this constructor different
                {
                    Node childNode = new Node(this, position, board, isLeafNode);

                    childrenNodeList.AddLast(childNode);
                    //board.RemovePiece(position);
                    return childNode;
                }
                return null;
            }
            return null;


            
            /*
             *  
             *  
             * 
             */


        }

        public bool PlaceMove(int position, Piece gamePiece)//Method used to place a piece on the board.
        {
            return board.PlacePiece(position, gamePiece);
        }

        public void RemovePiece(int positionOnBoard)//Method used to remove a pieve from the board.
        {
            board.RemovePiece(positionOnBoard);
        }

        public int GetBestMove()
        {//Method gets the best move from based on child node position.
            return childPosition;
        }


        public Board GetBoard()
        {
            return board;
        }

        /// <summary>
        /// This method essentially will look at the children node, and find either the Max 
        /// or Min of them. It will then return the position of that object on the board.
        /// 
        /// </summary>
        /// <param name="isMax"></param>
        /// <returns></returns>
        public int MaxorMinChildNode(bool isMax)
        {

            int minNumber = 999;
            int maxNumber = -999;
            int nodePosition = 64;
            if (isMax == true)
            {
                foreach (Node childNode in childrenNodeList)
                {
                    if (childNode.heuristicValue > maxNumber)
                    {
                        maxNumber = childNode.heuristicValue;
                        nodePosition = childNode.positionOnBoard;
                    }
                }
                return maxNumber;
            }
            else
            {
                foreach (Node childNode in childrenNodeList)
                {
                    if (childNode.heuristicValue < minNumber)
                    {
                        minNumber = childNode.heuristicValue;
                        nodePosition = childNode.positionOnBoard;
                    }
                }
                return minNumber;
            }
        }
        public int MaxorMinChildNodePOSITION(bool isMax)
        {
            //Method gets the ChildNodes Position, and heuristic value.

                int minNumber = 999;
            int maxNumber = -999;
            int nodePosition = 64;
            if (isMax == true)
            {
                foreach (Node childNode in childrenNodeList)
                {
                    if (childNode.heuristicValue > maxNumber)
                    {
                        maxNumber = childNode.heuristicValue;
                        nodePosition = childNode.positionOnBoard;
                    }
                }
                return nodePosition;
            }
            else
            {
                foreach (Node childNode in childrenNodeList)
                {
                    if (childNode.heuristicValue < minNumber)
                    {
                        minNumber = childNode.heuristicValue;
                        nodePosition = childNode.positionOnBoard;
                    }
                }
                return nodePosition;
            }


        }




        public int CompareTo(object obj) //Have to add this for Class (In order to Implement IComparable)
        {
            //Method used to compare objects, and determine if they are a node object or not.
                if (!(obj is Node))
                throw new ArgumentException("Not a Node!");
            Node node = obj as Node;

            return this.heuristicValue.CompareTo(node.heuristicValue);

        }

        public int ChildrenCount()//Method to count the total number of Child Nodes.
        {
            if (childrenNodeList != null)
            {
                return childrenNodeList.Count();
            }
            else
            {
                return 0;
            }
        }

        public int GetHeuristic()//Method to get the current Heuristic value of the board state.
        {
            return board.GetHeuristic();
        }


        public int[] GetAvailablePositions()//Method to get the current number of available positions.
        {

            return board.GetAvailablePositions();
        }

    }

}








