using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public interface IMainForm
    {
        Bitmap Image { get; set; }

        Bitmap RImage { get; set; }
 
    }
    public partial class Form1 : Form,IMainForm
    {

        public Form1()
        {
            InitializeComponent();

            BlockSize = Sheet.Width / 10;

            Draft = new Bitmap(Sheet.Width, Sheet.Height);
            painter = new Painter(Draft, BlockSize, Sheet.Width, Sheet.Height);


            RImage = DrawRandomBlock();

            board = new Board(Sheet.Height / BlockSize, Sheet.Width / BlockSize);

            GetRandomBlock();

            Board.ArrivedAtBottom += Board_ArrivedAtBottom;

            timer1.Interval = 700;
            // timer1.Start();
            timer1.Enabled = false;

        }

        private void Board_ArrivedAtBottom()
        {
            timer1.Stop();
            timer1.Dispose();
        }

        void GetRandomBlock()
        {
            RandomBlock = rand.Next(0, 4);
            //RandomBlock = 0;

            int RandomPosition = rand.Next(0, 4);

            switch (RandomBlock)
            {
                case 0:
                    t_block = new T_Block(StartPoint, RandomPosition, BlockSize,board);
                    moveLeft = t_block.MoveLeft;
                    moveRight = t_block.MoveRight;
                    moveDown = t_block.MoveDown;
                    rotate = t_block.Rotate;

                    BlockColor = t_block.color;
                    returnCoordinates = t_block.returnCoordinates;

                    break;
                case 1:
                    square = new Square(StartPoint, BlockSize,board);
                    moveLeft = square.MoveLeft;
                    moveRight = square.MoveRight;
                    moveDown = square.MoveDown;
                    rotate = square.Rotate;

                    BlockColor = square.color;
                    returnCoordinates = square.returnCoordinates;

                    break;
                case 2:
                    stick = new Stick(StartPoint, RandomPosition, BlockSize,board);
                    moveLeft = stick.MoveLeft;
                    moveRight = stick.MoveRight;
                    moveDown = stick.MoveDown;
                    rotate = stick.Rotate;

                    BlockColor = stick.color;
                    returnCoordinates = stick.returnCoordinates;

                    break;
                case 3:
                    z_block = new Z_Block(StartPoint, RandomPosition, BlockSize,board);
                    moveLeft = z_block.MoveLeft;
                    moveRight = z_block.MoveRight;
                    moveDown = z_block.MoveDown;
                    rotate = z_block.Rotate;

                    BlockColor = z_block.color;
                    returnCoordinates = z_block.returnCoordinates;
                    break;
                //
                default:
                    break;

            }
        }

        Bitmap DrawRandomBlock()
        {
            Bitmap RandomDraft = new Bitmap(RandomBSheet.Width, RandomBSheet.Height);
            Painter @Painter = new Painter(RandomDraft, BlockSize, RandomDraft.Width, RandomDraft.Height);

            int RandomPosition = rand.Next(0, 4);

            Color RColor = Color.FromArgb(40, 40, 40);

            Point Position = new Point(2 * BlockSize, 2 * BlockSize);

            switch(rand.Next(0,4))
            {
                case 0:
                    t_block = new T_Block(RandomDraft, Position, RandomPosition, BlockSize);
                    t_block.Draw();
                    @Painter.DrawArea(RColor);
                    return RandomDraft;
                case 1:
                    square = new Square(RandomDraft, Position, BlockSize);
                    square.Draw();
                    @Painter.DrawArea(RColor);
                    return RandomDraft;
                case 2:
                    stick = new Stick(RandomDraft, Position, RandomPosition, BlockSize);
                    stick.Draw();
                    @Painter.DrawArea(RColor);
                    return RandomDraft;
                case 3:
                    z_block = new Z_Block(RandomDraft, Position, RandomPosition, BlockSize);
                    z_block.Draw();
                    @Painter.DrawArea(RColor);
                    return RandomDraft;
                default:
                    return RandomDraft;
            }
        }


        public Bitmap Image
        {
            get
            {
                return (Bitmap)Sheet.Image;
            }
            set
            {
                Sheet.Image = value;
            }
        }

        public Bitmap RImage
        {
            get
            {
                return (Bitmap)RandomBSheet.Image;
            }
            set
            {
                RandomBSheet.Image = value;
            }
        }

        int RandomBlock;

        Bitmap Draft;

        T_Block t_block;
        Square square;
        Stick stick;
        Z_Block z_block;

        Painter painter;
        Board board;

        ReturnCoordinates returnCoordinates;
        MoveLeft moveLeft;
        MoveRight moveRight;
        MoveDown moveDown;
        Rotate rotate;

        static int BlockSize;
        static Color BlockColor;
        Point[] TempCoordinates = new Point[4];

        Random rand = new Random();
        Point StartPoint = new Point(4*BlockSize,0);

        private void timer1_Tick(object sender, EventArgs e)
        {
            painter.Clear();

            board.RelieveValue(returnCoordinates());
            moveDown();
            board.SetValue(returnCoordinates(), BlockColor);
            board.DrawBlocks(Draft, BlockSize);

            painter.DrawArea();
            Image = Draft;

        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            
;            switch(e.KeyCode.ToString())
            {
                case "Left":
                    painter.Clear();

                    board.RelieveValue(returnCoordinates());

                    moveLeft();

                    board.SetValue(returnCoordinates(), BlockColor);
                    board.DrawBlocks(Draft, BlockSize);

                    painter.DrawArea();
                    Image = Draft;
                    break;

                case "Right":
                    painter.Clear();

                    board.RelieveValue(returnCoordinates());
                    moveRight();
                    board.SetValue(returnCoordinates(), BlockColor);
                    board.DrawBlocks(Draft, BlockSize);

                    painter.DrawArea();
                    Image = Draft;
                    break;
                //case "Up":
                //    rotater();
                //    painter.Clear();

                //    blockPainter();

                //    painter.DrawArea();
                //    Image = Draft;
                //    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           // MessageBox.Show(e.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
