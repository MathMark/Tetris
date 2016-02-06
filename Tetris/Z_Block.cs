using System.Drawing;

namespace Tetris
{
    class Z_Block
    {
        public Point Location;
        Graphics painter;

       public Color color
        {
            get
            {
                return BaseColor;
            }
        }

        private Point BoardLocation;
        private int width;
        private int height;

        int BlockSize;
        static Color BaseColor = Color.Red;

        int position;
        public int Position
        {
            get
            {
                return position;
            }
            set
            {
                if ((value >= 0) && (value <= 1))
                {
                    position = value;
                }
                else
                {
                    position = 0;
                }
            }
        }

        Point[] baseCoordinates = new Point[4];

        public Point[] returnCoordinates()
        {
            return baseCoordinates;
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
            }
        }

        Board board;
        public Z_Block(Point Location, int position, int BlockSize, Board board)
        {
            this.BlockSize = BlockSize;

            this.Location = Location;
            this.Position = position;

            this.board = board;
            BoardLocation = new Point(Location.X / BlockSize, Location.Y / BlockSize);

            SetMeasurements();
            ChangeCoordinates();
        }

        public Z_Block(Bitmap sheet, Point Location, int position, int BlockSize)
        {
            this.BlockSize = BlockSize;

            this.Location = Location;
            painter = Graphics.FromImage(sheet);
            this.Position = position;

            SetMeasurements();
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
                    baseCoordinates[2].X++;
                    baseCoordinates[2].Y++;

                    baseCoordinates[3].X+=2;
                    baseCoordinates[3].Y++;

                    break;

                case 1:
                    InitCoordinates();
                    SetMeasurements();

                    baseCoordinates[1].Y++;
                    baseCoordinates[2].X++;
                    baseCoordinates[2].Y++;

                    baseCoordinates[3].X++;
                    baseCoordinates[3].Y+=2;

                    break;
            }
        }


        public void Draw()
        {
            switch (Position)
            {
                case 0:
                    painter.FillRectangle(new SolidBrush(color), new RectangleF(Location, new SizeF(2*BlockSize, BlockSize)));
                    painter.FillRectangle(new SolidBrush(color), new RectangleF(new PointF(Location.X + BlockSize, Location.Y + BlockSize), new SizeF(2 * BlockSize, BlockSize)));
                    break;
                case 1:
                    painter.FillRectangle(new SolidBrush(color), new RectangleF(new PointF(Location.X + BlockSize, Location.Y), new SizeF(BlockSize, 2*BlockSize)));
                    painter.FillRectangle(new SolidBrush(color), new RectangleF(new PointF(Location.X + 2*BlockSize, Location.Y+BlockSize), new SizeF(BlockSize, 2 * BlockSize)));

                    break;

            }

        }
        public void MoveLeft()
        {
            if ((BoardLocation.X > 0)&&(board.Exists(new Point(BoardLocation.X-1,BoardLocation.Y)) == false))
            {
                BoardLocation.X --;
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
