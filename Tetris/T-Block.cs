using System;
using System.Drawing;
using System.Windows.Forms;
namespace Tetris
{
    class T_Block:IBlocko,IMove
    {
        public Color color
        {
            get
            {
                return Basecolor;
            }
        }

        static Color Basecolor=Color.DodgerBlue;
        public Point Location;
        Graphics painter;

        int BlockSize;

        private Point BoardLocation;

        Point[] baseCoordinates = new Point[4];

        int position;
        public int Position
        {
            get
            {
                return position;
            }
            set
            {
                if((value>=0)&&(value<=3))
                {
                    position = value;
                }
                else
                {
                    position = 0; 
                }
            }
        }

        Board board;
        public T_Block(Point Location, int position, int BlockSize, Board board)
        {
            this.BlockSize = BlockSize;

            this.Location = Location;

            this.Position = position;
            this.board = board;
            BoardLocation = new Point(Location.X / BlockSize, Location.Y / BlockSize);

            InitCoordinates();
        }

        public T_Block(Bitmap sheet, Point Location, int position, int BlockSize)
        {
            this.BlockSize = BlockSize;

            this.Location = Location;

            painter = Graphics.FromImage(sheet);
            this.Position = position;
        }

        private void InitCoordinates()
        {
            for (int i = 0; i < baseCoordinates.Length; i++)
            {
                baseCoordinates[i].X = BoardLocation.X;
                baseCoordinates[i].Y = BoardLocation.Y;
            }

            switch (Position)
            {
                case 0:
                    baseCoordinates[1].X--;

                    baseCoordinates[2].X++;

                    baseCoordinates[3].Y++;

                    break;

                case 1:
                    baseCoordinates[1].Y++;

                    baseCoordinates[2].Y--;

                    baseCoordinates[3].X--;

                    break;


                case 2:
                    baseCoordinates[1].X--;

                    baseCoordinates[2].X++;

                    baseCoordinates[3].Y--;

                    break;

                case 3:
                    baseCoordinates[1].Y++;

                    baseCoordinates[2].Y--;

                    baseCoordinates[3].X++;

                    break;
            }


       }

        private void ChangeCoordinates()
        {
            switch (Position)
            {
                case 0:
                    baseCoordinates[2].X++;

                    baseCoordinates[3].Y++;

                    break;

                case 1:
                    baseCoordinates[1].Y++;

                    baseCoordinates[2].Y--;

                    baseCoordinates[3].X--;

                    break;


                case 2:
                    baseCoordinates[1].X--;

                    baseCoordinates[2].X++;

                    baseCoordinates[3].Y--;

                    break;

                case 3:
                    baseCoordinates[1].Y++;

                    baseCoordinates[2].Y--;

                    baseCoordinates[3].X++;

                    break;
            }

        }

        public Point[] returnCoordinates()
        {
            return baseCoordinates;
        }

        public void Draw()
        {
            switch(Position)
            {
                case 0:
                    painter.FillRectangle(new SolidBrush(color), new RectangleF(Location, new SizeF(3 * BlockSize, BlockSize)));
                    painter.FillRectangle(new SolidBrush(color), new RectangleF(new PointF(Location.X + BlockSize, Location.Y + BlockSize), new SizeF(BlockSize, BlockSize)));
                    break;
                case 1:
                    painter.FillRectangle(new SolidBrush(color), new RectangleF(Location, new SizeF(BlockSize, BlockSize)));
                    painter.FillRectangle(new SolidBrush(color), new RectangleF(new PointF(Location.X + BlockSize, Location.Y - BlockSize), new SizeF(BlockSize, 3*BlockSize)));
                    break;
                case 2:
                    painter.FillRectangle(new SolidBrush(color), new RectangleF(Location, new SizeF(3*BlockSize, BlockSize)));
                    painter.FillRectangle(new SolidBrush(color), new RectangleF(new PointF(Location.X + BlockSize, Location.Y - BlockSize), new SizeF(BlockSize, BlockSize)));
                    break;
                case 3:
                    painter.FillRectangle(new SolidBrush(color), new RectangleF(Location, new SizeF(BlockSize, 3*BlockSize)));
                    painter.FillRectangle(new SolidBrush(color), new RectangleF(new PointF(Location.X + BlockSize, Location.Y + BlockSize), new SizeF(BlockSize, BlockSize)));
                    break;

                default:
                    break; 

            }
            
        }
        public Point[]MoveTemporaryToLeft()
        {
            Point[] temp = new Point[baseCoordinates.Length];

            for(int i=0;i<temp.Length;i++)
            {
                temp[i] = new Point( baseCoordinates[i].X-1,baseCoordinates[i].Y);
            }
            return temp;

        }

        public Point[] MoveTemporaryToRight()
        {
            Point[] temp = new Point[baseCoordinates.Length];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = new Point(baseCoordinates[i].X + 1, baseCoordinates[i].Y);
            }
            return temp;

        }


        public Point[] MoveTemporaryToDown()
        {
            Point[] temp = new Point[baseCoordinates.Length];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = new Point(baseCoordinates[i].X, baseCoordinates[i].Y+1);
            }
            return temp;

        }


        public void MoveLeft()
        {
            if (board.AskPermission(baseCoordinates,MoveTemporaryToLeft())!=true)
            {
                BoardLocation.X--;
                for (int i = 0; i < baseCoordinates.Length; i++)
                {
                    baseCoordinates[i].X--;
                }
            }
        }
        public void MoveRight()
        {
            if (board.AskPermission(baseCoordinates, MoveTemporaryToRight()) != true)
            {
                BoardLocation.X++;
                for (int i = 0; i < baseCoordinates.Length; i++)
                {
                    baseCoordinates[i].X++;
                }
            }
        }
        public void MoveDown()
        {
            if (board.AskPermission(baseCoordinates, MoveTemporaryToDown()) != true)
            {
                BoardLocation.Y++;
                for (int i = 0; i < baseCoordinates.Length; i++)
                {
                    baseCoordinates[i].Y++;
                }
            }
        }
        public void Rotate()
        {
            Position++;
        }
    }
}
