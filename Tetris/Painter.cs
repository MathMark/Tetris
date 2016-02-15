using System.Drawing;

namespace Tetris
{
    class Painter
    {
        public float BlockSize;
        public Graphics painter;
        public Color color = new Color();

        private int Width;
        private int Height;


        public Painter(Bitmap Sheet,float BlockSize)
        {
            this.BlockSize = BlockSize;
            color = Color.FromArgb(50, 50, 50);

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
        public void PrintGameOver()
        {
            painter.DrawString("GAME OVER", new Font("Consolas", 16), new SolidBrush(Color.Gold), new Point(Width/2-50, Height/2));
        }

    }
}
