using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Tetris
{
    class Square:IMove
    {
        public Color color
        {
            get
            {
                return Basecolor;
            }
        }

        Color Basecolor=Color.ForestGreen;
        public Point Location;
        Graphics painter;

        private Point BoardLocation;
        private const int width=2;
        private const int height=2;
        int BlockSize;

        Point[] baseCoordinates = new Point[4];

        public Square(Bitmap sheet, Point Location, int BlockSize)
        {
            this.BlockSize = BlockSize;
            painter = Graphics.FromImage(sheet);
            this.Location = Location;

            FillCoordinates();

    }
        Board board;
        public Square(Point Location, int BlockSize,Board board)
        {
            this.BlockSize = BlockSize;
            this.Location = Location;

            this.board = board;
            BoardLocation = new Point(Location.X / BlockSize, Location.Y / BlockSize);
            FillCoordinates();

        }

       
        private void InitCoordinates()
        {   
            for(int i=0;i<baseCoordinates.Length;i++)
            {
                baseCoordinates[i].X = BoardLocation.X;
                baseCoordinates[i].Y = BoardLocation.Y;
            }
        }
        private void FillCoordinates()
        {
            InitCoordinates();

            baseCoordinates[1].X ++;

            baseCoordinates[2].Y ++;

            baseCoordinates[3].X ++;
            baseCoordinates[3].Y ++;
        }

        public Point[] returnCoordinates()
        {
            return baseCoordinates;
        }

        public void Draw()
        {
           painter.FillRectangle(new SolidBrush(color), new RectangleF(Location, new SizeF(2 * BlockSize, 2 * BlockSize)));
        }
        public void Draw( Graphics InputPainter)
        {
            InputPainter.FillRectangle(new SolidBrush(color), new RectangleF(Location, new SizeF(2 * BlockSize, 2 * BlockSize)));
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
            ;
        }
    }
}
