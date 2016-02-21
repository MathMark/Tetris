using System.Drawing;
using System;

namespace Tetris
{
    /*this is a matrix which is devided on blocks, each of 
    which containes 1 or 0 and color. If we have a blocks on sheet,
    they are reflect on the board. So it's kind of skeleton of main sheet*/
    public class Board
    {
        public event Action<int> FullLine;
        class Blockk
        {
            public bool Existence;

           public Bitmap unit;

            public Blockk(bool Existence, Bitmap unit)
            {
                this.Existence = Existence;
                this.unit = unit;
            }
            public Blockk()
            {
                Existence = false;
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
        

        public void CheckFullLines()
        {
            int counter = 0;
            for (int i = board.GetLength(0) - 1; i>=offset;i--)
            {
                for(int j=0;j<board.GetLength(1);j++)
                {
                    if(board[i,j].Existence==true)
                    {
                        counter++;
                    }
                }
                if (counter == board.GetLength(1))
                {
                    FullLine(i);
                }
                counter = 0;
            }
        }
       public bool CheckFullLine(int indexOfLine)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[indexOfLine, j].Existence == true)
                {
                    return true;
                }
            }
            return false;
        }

        public void MoveValues(int indexOfLine)
        {
            Blockk temp;
            while (CheckFullLine(indexOfLine - 1) != false)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    temp = board[indexOfLine, j];
                    board[indexOfLine, j] = board[indexOfLine - 1, j];
                }
                indexOfLine--;
            }
            for (int j = 0; j < board.GetLength(1); j++)
            {
                board[indexOfLine, j] = new Blockk();
            }
            CheckFullLines();
        }

        public Board(int width,int height)
        {
            board = new Blockk[width, height];
            offset = 0;
            Clear();
        }
        public Board(int offset,int width, int height)
        {
            this.offset = offset;
            board = new Blockk[width + offset, height];
            Clear();
        }

        public void Clear()
        {
            for(int i=0;i<board.GetLength(0);i++)
            {
                for(int j=0;j<board.GetLength(1);j++)
                {
                    board[i, j] = new Blockk();
                }
            }
        }

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

        public void SetValue(Point d,bool[,] matrix,Bitmap Unit)
        {
            for(int i=0;i< matrix.GetLength(0);i++)
            {
                for(int j=0;j< matrix.GetLength(1);j++)
                {
                    if(matrix[i,j]==true)
                    {
                        board[i + d.Y, j + d.X]=new Blockk(true, Unit);
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
                        board[i + d.Y, j + d.X] = new Blockk();
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
                        P.DrawImage(board[i, j].unit, new Point(j * BlockSize, i * BlockSize - offset * BlockSize));
                    }
                }
            }
        }

    }
}
