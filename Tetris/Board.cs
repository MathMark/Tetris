using System.Drawing;
using System.Windows.Forms;
using System;

namespace Tetris
{
    
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

        public void SetValue(Point[]coordinates,Color color)
        {
            foreach(Point coordinate in coordinates)
            {
                if (coordinate.Y == board.GetLength(0)-1)
                {
                    board[coordinate.Y, coordinate.X] = new Block(true, color);
                    ArrivedAtBottom();
                   // break;
                }
                else
                {
                    board[coordinate.Y, coordinate.X] = new Block(true, color);
                }
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
