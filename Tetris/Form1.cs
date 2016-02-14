using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

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
        Block Nextblock;
        public Form1()
        {
            InitializeComponent();

            BlockSize = Sheet.Width / 10;

            Draft = new Bitmap(Sheet.Width, Sheet.Height);
            DraftForNextBlock = new Bitmap(RandomBSheet.Width, RandomBSheet.Height);
            painter = new Painter(Draft, BlockSize);
            PainterForNextBlock = new Painter(DraftForNextBlock, BlockSize);


            board = new Board(Sheet.Height / BlockSize, Sheet.Width / BlockSize);
            BoardForNextBlock = new Board(RandomBSheet.Height / BlockSize, RandomBSheet.Width / BlockSize);


            Block.ArrivedAtBottom += Board_ArrivedAtBottom;

            StartPoint = new Point(0, 0);
            RandomBlock = rand.Next(0, 7);

            blocks = Enumerable.Range(0, 7).ToArray();
            Shuffle();
            IndexOfNextBlock = RandomBlock;

            block = new Block(blocks[RandomBlock], StartPoint,board);
            Nextblock = new Block(blocks[IndexOfNextBlock], StartPoint, board);

            IndexOfNextBlock++;
            ShowNextBlock();

            timer1.Interval = 400;
            timer1.Enabled = false;

        }
        #region variables

        int RandomBlock;

        Bitmap Draft;
        Bitmap DraftForNextBlock;

        Painter painter;
        Painter PainterForNextBlock;
        Board board;
        Board BoardForNextBlock;

        static int BlockSize;

        Random rand = new Random();
        Point StartPoint;

        static int[] blocks;
        #endregion

        int indexOfNextBlock;
        int IndexOfNextBlock
        {
            get
            {
                return indexOfNextBlock;
            }
            set
            {
                if ((value >= 0) && (value < 7))
                {
                    indexOfNextBlock = value;
                }
                else
                {
                    indexOfNextBlock = 0;
                    Shuffle();
                }
            }
        }

        #region methods

        void ShowNextBlock()
        {
            Nextblock = new Block(blocks[IndexOfNextBlock], StartPoint, board);
            BoardForNextBlock.Clear();
            BoardForNextBlock.SetValue(Nextblock.d, Nextblock.skeleton, Nextblock.color);
            PainterForNextBlock.Clear();
            BoardForNextBlock.DrawBlocks(DraftForNextBlock, BlockSize);
            PainterForNextBlock.DrawArea();

            RImage = DraftForNextBlock;
        }


        public static void Shuffle()
        {
            Random rng = new Random();
            int n = blocks.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = blocks[k];
                blocks[k] = blocks[n];
                blocks[n] = value;
            }
        }
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

                block = new Block(blocks[IndexOfNextBlock], StartPoint, board);
            IndexOfNextBlock++;
            ShowNextBlock();


            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        #endregion
    }
}
