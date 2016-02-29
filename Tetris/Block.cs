﻿using System;
using System.Drawing;
using System.Collections;
using Tetris.Properties;


namespace Tetris
{
    public class Block:IMove
    {
        public static event Action ArrivedAtBottom;

        int typeBlock;
        public Point d;
        public int TypeBlock
        {
            get
            {
                return typeBlock;
            }
            set
            {
                if((value>=0)&&(value<=7))
                {
                    typeBlock = value;
                }
                else
                {
                    typeBlock = 0;
                }
            }
        }
        const int blockSize = 35;
        public static int BlockSize
        {
            get
            {
                return blockSize;
            }
        }

        Board board;

        public bool[,] skeleton;
        public Bitmap Unit
        {
            get
            {
                return unit;
            }
        }
        Bitmap unit;

        BitArray[,] structure = new BitArray[3,3];

        public Block(int TypeBlock,Point Location,Board board)
        {
            this.board = board;
            this.d = Location;
           
            this.TypeBlock = TypeBlock;
            switch(typeBlock)
            {
                case 0://T-Block
                       skeleton =new bool[3,3]{
                           { false,false,false},
                           { true,true,true},
                           { false,true,false}, 
                       };

                    unit = Resources.Blue;
                    break;
                case 1://O-Block

                    skeleton = new bool[2, 2]{
                           { true,true},
                           { true,true}
                       };
                    unit = Resources.Orange;
                    break;
                case 2://I-Block
                    skeleton = new bool[4, 4]{
                        { false,false,false,false},
                        { true,true,true,true},
                        { false,false,false,false},
                        { false,false,false,false}
                    };
                    unit = Resources.Yellow;
                    break;
                case 3://S-Block
 
                    skeleton = new bool[3, 3]{
                           { false,false,false},
                           { false,true,true},
                           { true,true,false},
                       };
                    unit = Resources.BlueGreen;
                    break;
                case 4://Z-Block
                    skeleton = new bool[3, 3]{
                           { false,false,false},
                           { true,true,false},
                           { false,true,true},
                       };
                    unit = Resources.Gray;
                    break;
                case 5://L-Block
                    skeleton = new bool[3, 3]{
                           { false,false,false},
                           { true,true,true},
                           { true,false,false},
                       };
                    unit = Resources.Strongblue;
                    break;
                case 6://J-Block

                    skeleton = new bool[3, 3]{
                           { false,false,false},
                           { true,true,true},
                           { false,false,true},
                       };
                    unit = Resources.Purple;
                    break;
            }

        }
        public bool Over()
        {
            if (board.CheckExistence(new Point(d.Y + skeleton.GetLength(0), d.X)) == true)
            {
                return true;
            }
            return false;
        }
        public void MoveToLeft()
        {
            for (int i = 0; i < skeleton.GetLength(0); i++)
            {
                for (int j = 0; j < skeleton.GetLength(1); j++)
                {
                    if (skeleton[i, j] == true)
                    {
                        if ((j-1 <0) || (skeleton[i, j-1] == false))
                        {
                            if (board.CheckExistence(new Point(i + d.Y, j-1 + d.X)) == true)
                            {
                                return;
                            }
                        }
                    }
                }
            }
            board.RelieveValue(d, skeleton);
            d.X--;
            board.SetValue(d, skeleton, Unit);
        }
        public void MoveToRight()
        {
            for (int i = 0; i < skeleton.GetLength(0); i++)
            {
                for (int j = skeleton.GetLength(1)-1; j >=0; j--)
                {
                    if (skeleton[i, j] == true)
                    {
                        if ((j + 1 > skeleton.GetLength(1) - 1) || (skeleton[i, j + 1] == false))
                        {
                            if (board.CheckExistence(new Point(i + d.Y, j + 1 + d.X)) == true)
                            {
                                return;
                            }
                        }
                    }
                }
            }
            board.RelieveValue(d, skeleton);
            d.X++;
            board.SetValue(d, skeleton, Unit);
        }
        public void MoveToDown()
        {
            for (int i = skeleton.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < skeleton.GetLength(1); j++)
                {
                    if (skeleton[i, j] == true)
                    {
                        if ((i + 1 > skeleton.GetLength(0) - 1) || (skeleton[i + 1, j] == false))
                        {
                            if (board.CheckExistence(new Point(i + 1 + d.Y, j + d.X)) == true)
                            {
                                ArrivedAtBottom();
                                return;
                            }
                        }
                    }
                }
            }
            board.RelieveValue(d,skeleton);
            d.Y++;
            board.SetValue(d, skeleton, Unit);
        }
        public void Rotate()
        {
            bool[,] temp = new bool[skeleton.GetLength(0), skeleton.GetLength(1)];

            if (TypeBlock != 1)
            {
                for (int i = 0; i < skeleton.GetLength(0); i++)
                {
                    for (int j = 0; j < skeleton.GetLength(1); j++)
                    {
                        if(skeleton[i, j]==false)
                        {
                            if(board.CheckExistence(new Point(i+d.Y,j+d.X))==true)
                            {
                                return;
                            }
                        }
                        else if (skeleton[i, j] == true)
                        {
                            temp[skeleton.GetLength(1) - 1 - j, i] = true;
                        }
                    }
                }


                board.RelieveValue(d, skeleton);
                skeleton = (bool[,])temp.Clone();
                board.SetValue(d, skeleton, Unit);
            }
        }

    }
}
