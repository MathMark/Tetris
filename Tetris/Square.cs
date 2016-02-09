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
        int BlockSize;

        Point[] baseCoordinates = new Point[4];

        public Square(Bitmap sheet, Point Location, int BlockSize)
        {
            this.BlockSize = BlockSize;
            painter = Graphics.FromImage(sheet);
            this.Location = Location;

    }
        Board board;
        public Square(Point Location, int BlockSize,Board board)
        {
            this.BlockSize = BlockSize;
            this.Location = Location;

            this.board = board;
            BoardLocation = new Point(Location.X / BlockSize, Location.Y / BlockSize);

            InitCoordinates();

        }

       
        private void InitCoordinates()
        {   
            for(int i=0;i<baseCoordinates.Length;i++)
            {
                baseCoordinates[i].X = BoardLocation.X;
                baseCoordinates[i].Y = BoardLocation.Y;
            }
            baseCoordinates[1].X++;

            baseCoordinates[2].Y++;

            baseCoordinates[3].X++;
            baseCoordinates[3].Y++;
        }

        public Point[] returnCoordinates()
        {
            return baseCoordinates;
        }

        public void Draw()
        {
           painter.FillRectangle(new SolidBrush(color), new RectangleF(Location, new SizeF(2 * BlockSize, 2 * BlockSize)));
        }

        public void MoveLeft()
        {
            if (board.AskPermission(baseCoordinates, Board.ShiftToLeft(returnCoordinates())) != true)
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
            if (board.AskPermission(baseCoordinates, Board.ShiftToRight(returnCoordinates())) != true)
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
            if (board.AskPermission(baseCoordinates, Board.ShiftToDown(returnCoordinates())) != true)
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
