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
    class Painter
    {
        public float BlockSize;
        public Graphics painter;
        public Color color = new Color();

        private int Width;
        private int Height;


        public Painter(Bitmap Sheet,float BlockSize,int Width,int Height)
        {
            this.BlockSize = BlockSize;
            color = Color.FromArgb(50, 50, 50);

            this.Width = Width;
            this.Height = Height;

            painter = Graphics.FromImage(Sheet);
        }
        public void Clear()
        {
            painter.Clear(color);
        }
        public void DrawArea()
        {
            Pen pen = new Pen(Color.Black,1);
            for (float i = 0; i < Height; i += BlockSize)
            {
                painter.DrawLine(pen, 0, i, Width, i);
            }
            for (float i = 0; i < Width; i += BlockSize)
            {
                painter.DrawLine(pen, i, 0, i, Height);
            }
        }
        public void DrawArea(Color @Color)
        {
            Pen pen = new Pen(@Color);
            for (float i = 0; i < Height; i += BlockSize)
            {
                painter.DrawLine(pen, 0, i, Width, i);
            }
            for (float i = 0; i < Width; i += BlockSize)
            {
                painter.DrawLine(pen, i, 0, i, Height);
            }
        }

    }
}
