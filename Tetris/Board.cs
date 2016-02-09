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

    class Board
    {
        public static event Action ArrivedAtBottom; 

        class Block
        {
            public bool Existence;
            public Color color;
            public Block(bool Existence, Color color)
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

        Block[,] board;

        public Point[] ShiftToLeft(Point[]baseCoordinates)
        {
            Point[] temp = new Point[baseCoordinates.Length];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = new Point(baseCoordinates[i].X - 1, baseCoordinates[i].Y);
            }
            return temp;

        }

        public Point[] ShiftToRight(Point[] baseCoordinates)
        {
            Point[] temp = new Point[baseCoordinates.Length];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = new Point(baseCoordinates[i].X + 1, baseCoordinates[i].Y);
            }
            return temp;

        }


        public Point[] ShiftToDown(Point[] baseCoordinates)
        {
            Point[] temp = new Point[baseCoordinates.Length];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = new Point(baseCoordinates[i].X, baseCoordinates[i].Y + 1);
            }
            return temp;

        }




        public Board(int width,int height)
        {
            board = new Block[width, height];
            Clear();
        }

        public int CountOfLines
        {
            get
            {
                return board.GetLength(0);
            }
           
        }
        public int CountOfColumns
        {
            get
            {
                return board.GetLength(1);
            }
            
        }


        public void Clear()
        {
            for(int i=0;i<board.GetLength(0);i++)
            {
                for(int j=0;j<board.GetLength(1);j++)
                {
                    board[i, j] = new Block(false, Color.Empty);
                }
            }
        }

        public bool AskPermission(Point[]CurrentCoordinates,Point[]FutureCoornates)
        {
            List<Point> temp = new List<Point>();

            for (int i=0;i<FutureCoornates.Length;i++)
            {
                if(Array.IndexOf(CurrentCoordinates, FutureCoornates[i])==-1)
                {
                    temp.Add(FutureCoornates[i]);
                }
            }
                foreach (Point Coordinate in temp)
            {
                if(CheckExistence(Coordinate)== true)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckExistence(Point coordinates)
        {
            if ((coordinates.X >= 0) && (coordinates.X < board.GetLength(1))
                    && (coordinates.Y >= 0) && (coordinates.Y < board.GetLength(0)))
            {
                if (board[coordinates.Y, coordinates.X].Existence == true)
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
        public void SetValue(Point[]coordinates,Color color)
        {
            bool arrivedAtBottom = false;
            foreach (Point coordinate in coordinates)
            {
                if ((coordinate.Y == board.GetLength(0)-1)||(CheckExistence(new Point(coordinate.X,coordinate.Y+1))==true))
                {
                    board[coordinate.Y, coordinate.X] = new Block(true, color);
                    arrivedAtBottom = true;
                }
                else
                {
                    board[coordinate.Y, coordinate.X] = new Block(true, color);
                }
            }
            if(arrivedAtBottom==true)
            {
                ArrivedAtBottom();
            }
        }

        public void RelieveValue(Point[] coordinates)
        {
            foreach (Point coordinate in coordinates)
            {
                board[coordinate.Y, coordinate.X] = new Block(false, Color.Empty);
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
                        P.FillRectangle(new SolidBrush(board[i, j].color), new Rectangle(new Point(j*BlockSize,i*BlockSize), new Size(BlockSize, BlockSize)));
                    }
                }
            }
        }
    }
}
