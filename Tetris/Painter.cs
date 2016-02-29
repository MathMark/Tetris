using System.Drawing;
using Tetris.Properties;

namespace Tetris
{
    class Painter
    {
        public float BlockSize;
        public Graphics painter;
        public Color color = new Color();

        private int Width;
        private int Height;

        public Color ColorArea;

        public Painter(Bitmap Sheet,float BlockSize)
        {
            this.BlockSize = BlockSize;
            color = Color.FromArgb(50, 50, 50);
            ColorArea = Color.Black;

            this.Width = Sheet.Width;
            this.Height = Sheet.Height;

            painter = Graphics.FromImage(Sheet);
        }
        public void Clear()
        {
            painter.Clear(color);
        }
        public void DrawArea()
        {
            Pen pen = new Pen(ColorArea, 1);
            for (float i = 0; i < Height; i += BlockSize)
            {
                painter.DrawLine(pen, 0, i, Width, i);
            }
            for (float i = 0; i < Width; i += BlockSize)
            {
                painter.DrawLine(pen, i, 0, i, Height);
            }
        }

        public void PrintGameOver()
        {
            Clear();
            painter.DrawImage(Resources.GameOver, new Point(0, 0));
        }
        public void PrintPause()
        {
           Clear();
            painter.DrawImage(Resources.Pause2, new Point(0, 0));
            painter.DrawImage(Resources.Pause, new Point(0, Height - Resources.Pause.Height));
        }

    }
}
