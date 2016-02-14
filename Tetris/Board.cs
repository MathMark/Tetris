using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Tetris
{
    /*this is a matrix which is devided on blocks, each of 
    which containes 1 or 0 and color. If we have a blocks on sheet,
    they are reflect on the board. So it's kind of skeleton of main sheet*/

   public class Board
    {
        class Blockk
        {
            public bool Existence;
            public Color color;
            

            public Blockk(bool Existence, Color color)
            {
                this.Existence = Existence;
                this.color = color;
            }
            public override string ToString()
            {
                if (this.Existence == true)
                {
                    return 1.ToString();
                }
                else
                {
                    return 0.ToString();
                }
            }
        }

        Blockk[,] board;
        int offset;

        public Board(int width,int height)
        {
            board = new Blockk[width+offset, height];
            offset = 0;
            Clear();
        }
        public Board(int offset,int width, int height)
        {
            this.offset = offset;
            board = new Blockk[width + 4, height];
            Clear();
        }

        public void Clear()
        {
            for(int i=0;i<board.GetLength(0);i++)
            {
                for(int j=0;j<board.GetLength(1);j++)
                {
                    board[i, j] = new Blockk(false, Color.Empty);
                }
            }
        }

        //public bool AskPermission(Point[]CurrentCoordinates,Point[]FutureCoornates)
        //{
        //    List<Point> temp = new List<Point>();

        //    for (int i=0;i<FutureCoornates.Length;i++)
        //    {
        //        if(Array.IndexOf(CurrentCoordinates, FutureCoornates[i])==-1)
        //        {
        //            temp.Add(FutureCoornates[i]);
        //        }
        //    }
        //        foreach (Point Coordinate in temp)
        //    {
        //        if(CheckExistence(Coordinate)== true)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        public bool CheckExistence(Point coordinates)
        {
            if ((coordinates.X >= 0) && (coordinates.X < board.GetLength(0))
                    && (coordinates.Y >= 0) && (coordinates.Y < board.GetLength(1)))
            {
                if (board[coordinates.X, coordinates.Y].Existence == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public void SetValue(Point d,bool[,] matrix,Color color)
        {
            for(int i=0;i< matrix.GetLength(0);i++)
            {
                for(int j=0;j< matrix.GetLength(1);j++)
                {
                    if(matrix[i,j]==true)
                    {
                        board[i + d.Y, j + d.X]=new Blockk(true,color);
                    }
                }
            }
        }
        public void RelieveValue(Point d, bool[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == true)
                    {
                        board[i + d.Y, j + d.X] = new Blockk(false, Color.Empty);
                    }
                }
            }
        }


        public void DrawBlocks(Bitmap sheet,int BlockSize)
        {
            Graphics P = Graphics.FromImage(sheet);

            for(int i=0;i<board.GetLength(0);i++)
            {
                for(int j=0;j<board.GetLength(1);j++)
                {
                    if(board[i,j].Existence==true)
                    {
                        P.FillRectangle(new SolidBrush(board[i, j].color), new Rectangle(new Point(j*BlockSize,i*BlockSize-offset*BlockSize), new Size(BlockSize, BlockSize)));
                    }
                }
            }
        }

        public void MoveValues(int IndexLine)
        {

        }
    }
}
