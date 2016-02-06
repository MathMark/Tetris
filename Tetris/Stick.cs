using System.Drawing;

namespace Tetris
{
    class Stick
    {
        public Color color
        {
            get
            {
               return BaseColor;
            }
        }
        static Color BaseColor=Color.Yellow;
        private Point Location;
        Graphics painter;

        Point[] baseCoordinates = new Point[4];
        int BlockSize;

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
        Board board;

        private Point BoardLocation;
        private int width;
        private int height;

        private void SetMeasurements()
        {
            switch(Position)
            {
                case 0:
                    width = 1;
                    height = 4;
                    break;
                case 1:
                    width = 4;
                    height = 1;
                    break;
            }
        }

        public Stick(Point Location, int position, int BlockSize,Board board)
        {
            this.BlockSize = BlockSize;

            this.Location = Location;
            this.Position = position;

            ChangeCoordinates();
            SetMeasurements();

            this.board = board;
            BoardLocation = new Point(Location.X / BlockSize, Location.Y / BlockSize);

        }
        public Stick(Bitmap sheet,Point Location, int position, int BlockSize)
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
            switch(Position)
            {
                case 0:
                    InitCoordinates();
                    SetMeasurements();

                    baseCoordinates[1].Y++;
                    baseCoordinates[2].Y += 2;
                    baseCoordinates[3].Y += 3;
                    break;
                case 1:
                    InitCoordinates();
                    SetMeasurements();

                    baseCoordinates[1].X++;
                    baseCoordinates[2].X += 2;
                    baseCoordinates[3].X += 3;
                    break;

            }
        }

        public Point[] returnCoordinates()
        {
            return baseCoordinates;
        }
        
        public void Draw()
        {
            switch (Position)
            {
                case 0:
                    painter.FillRectangle(new SolidBrush(color), new RectangleF(Location, new SizeF(BlockSize, 4 * BlockSize)));
                    break;
                case 1:
                    painter.FillRectangle(new SolidBrush(color), new RectangleF(new PointF(Location.X - BlockSize, Location.Y + BlockSize), new SizeF(4 * BlockSize, BlockSize)));
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
            if ((BoardLocation.X+width <= board.CountOfColumns-1))
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
            if(BoardLocation.Y +height<= board.CountOfLines-1)
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
