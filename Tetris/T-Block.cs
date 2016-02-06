using System;
using System.Drawing;

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
        private int width;
        private int height;

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

        private void SetMeasurements()
        {
            switch(Position)
            {
                case 0:
                    width = 3;
                    height = 2;
                    break;
                case 1:
                    width = 2;
                    height = 3;
                    break;
                case 3:
                    goto case 0;
                case 4:
                    goto case 1;
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

            ChangeCoordinates();
            SetMeasurements();
        }

        public T_Block(Bitmap sheet, Point Location, int position, int BlockSize)
        {
            this.BlockSize = BlockSize;

            this.Location = Location;

            painter = Graphics.FromImage(sheet);
            this.Position = position;

            ChangeCoordinates();
        }

        private void InitCoordinates()
        {
            for (int i = 0; i < baseCoordinates.Length; i++)
            {
                baseCoordinates[i].X = BoardLocation.X;
                baseCoordinates[i].Y = BoardLocation.Y;
            }
        }

        private void ChangeCoordinates()
        {
            switch (Position)
            {
                case 0:
                    InitCoordinates();
                    SetMeasurements();

                    baseCoordinates[1].X++;
                    baseCoordinates[2].X += 2;

                    baseCoordinates[3].X++;
                    baseCoordinates[3].Y++;

                    break;

                case 1:
                    InitCoordinates();
                    SetMeasurements();

                    baseCoordinates[1].Y++;
                    baseCoordinates[2].Y += 2;

                    baseCoordinates[3].X--;
                    baseCoordinates[3].Y++;

                    break;
            

                case 2:
                    InitCoordinates();
                    SetMeasurements();

                    baseCoordinates[1].X--;
                    baseCoordinates[1].Y++;
                    baseCoordinates[2].Y++;

                    baseCoordinates[3].X++;
                    baseCoordinates[3].Y++;

                    break;

                case 3:
                    InitCoordinates();
                    SetMeasurements();

                    baseCoordinates[1].Y++;
                    baseCoordinates[2].Y += 2;

                    baseCoordinates[3].X++;
                    baseCoordinates[3].Y++;

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

        public void MoveLeft()
        {
            if ((BoardLocation.X > 0))
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
            if ((BoardLocation.X+width <= board.CountOfColumns - 1))
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
            if (BoardLocation.Y+height <= board.CountOfLines - 1)
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
