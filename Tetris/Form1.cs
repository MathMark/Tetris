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
        Block block;
        public Form1()
        {
            InitializeComponent();

            BlockSize = Sheet.Width / 10;

            Draft = new Bitmap(Sheet.Width, Sheet.Height);
            painter = new Painter(Draft, BlockSize, Sheet.Width, Sheet.Height);


            board = new Board(Sheet.Height / BlockSize, Sheet.Width / BlockSize);

            StartPoint = new Point(0, 0);

            RandomBlock = rand.Next(0, 6);

            RandomBlock = rand.Next(0, 4);
           // RImage = DrawRandomBlock();

            Block.ArrivedAtBottom += Board_ArrivedAtBottom;

            block = new Block(RandomBlock, StartPoint,board);

            timer1.Interval = 400;
            timer1.Enabled = false;

        }
        #region variables

        int RandomBlock;

        Bitmap Draft;

        Painter painter;
        Board board;

        static int BlockSize;

        Point[] TempCoordinates = new Point[4];

        Random rand = new Random();
        Point StartPoint;
        int RandomPosition;

        #endregion


        #region methods


        //Bitmap DrawRandomBlock()
        //{
        //    Bitmap RandomDraft = new Bitmap(RandomBSheet.Width, RandomBSheet.Height);
        //    Painter @Painter = new Painter(RandomDraft, BlockSize, RandomDraft.Width, RandomDraft.Height);

        //    Color RColor = Color.FromArgb(40, 40, 40);

        //    Point Position = new Point(2 * BlockSize, 2 * BlockSize);

            //switch(RandomBlock)
            //{
                //case 0:
                //    t_block = new T_Block(RandomDraft, Position, RandomPosition, BlockSize);
                //    t_block.Draw();
                //    @Painter.DrawArea(RColor);
                //    return RandomDraft;
                //case 1:
                //    square = new Square(RandomDraft, Position, BlockSize);
                //    square.Draw();
                //    @Painter.DrawArea(RColor);
                //    return RandomDraft;
                //case 2:
                //    stick = new Stick(RandomDraft, Position, RandomPosition, BlockSize);
                //    stick.Draw();
                //    @Painter.DrawArea(RColor);
                //    return RandomDraft;
                //case 3:
                //    z_block = new Z_Block(RandomDraft, Position, RandomPosition, BlockSize);
                //    z_block.Draw();
                //    @Painter.DrawArea(RColor);
                //    return RandomDraft;
                //default:
                //    return RandomDraft;
           // }
       // }

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

        #endregion

        #region events

        private void timer1_Tick(object sender, EventArgs e)
        {
            painter.Clear();

            //board.RelieveValue(returnCoordinates());
            //moveDown();
            block.MoveToDown();
           // board.SetValue(block);

            board.DrawBlocks(Draft, BlockSize);

            painter.DrawArea();
            Image = Draft;

        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            
           switch(e.KeyCode.ToString())
            {
                case "Left":
                    painter.Clear();

                    block.MoveToLeft();

                    board.DrawBlocks(Draft, BlockSize);

                    painter.DrawArea();
                    Image = Draft;
                    break;

                case "Right":
                    painter.Clear();

                    block.MoveToRight();
                    board.DrawBlocks(Draft, BlockSize);

                    painter.DrawArea();
                    Image = Draft;
                    break;
                case "Up":
                    painter.Clear();

                    block.Rotate();

                    board.DrawBlocks(Draft, BlockSize);

                    painter.DrawArea();
                    Image = Draft;
                    break;
            }
        }

        private void Board_ArrivedAtBottom()
        {
            timer1.Stop();
            timer1.Dispose();
            //GetRandomBlock();

            RandomBlock = rand.Next(0, 4);
            RandomPosition = rand.Next(0, 4);
            //block = new Block(RandomBlock, StartPoint, board);
            block = new Block(0, StartPoint, board);
            // RImage = DrawRandomBlock();//
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        #endregion
    }
}
