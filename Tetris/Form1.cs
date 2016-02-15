using System;
using System.Drawing;
using System.Windows.Forms;
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

            RestartButton.Enabled = false;
            //BlockSize = Sheet.Width / 10;
            BlockSize = 35;

            Draft = new Bitmap(Sheet.Width, Sheet.Height);
            DraftForNextBlock = new Bitmap(RandomBSheet.Width, RandomBSheet.Height);
            painter = new Painter(Draft, BlockSize);
            PainterForNextBlock = new Painter(DraftForNextBlock, BlockSize);


            board = new Board(4,Sheet.Height / BlockSize, Sheet.Width / BlockSize);
            BoardForNextBlock = new Board(RandomBSheet.Height / BlockSize, RandomBSheet.Width / BlockSize);


            Block.ArrivedAtBottom += Board_ArrivedAtBottom;
            Board.FullLine += Board_FullLine;
            Block.GameOver += Block_GameOver;

            StartPoint = new Point(2, 0);
            RandomBlock = rand.Next(0, 7);

            blocks = Enumerable.Range(0, 7).ToArray();
            Shuffle();
            IndexOfNextBlock = RandomBlock;

            block = new Block(blocks[RandomBlock], StartPoint,board);
            Nextblock = new Block(blocks[IndexOfNextBlock], PositionOfNextBlock, board);

            IndexOfNextBlock++;
            ShowNextBlock();

            Speed = 400;
            timer1.Enabled = true;
            

        }

        private void Block_GameOver()
        {
            Speed = 0;
           // painter.Clear();
            board.Clear();
            painter.PrintGameOver();
            Image = Draft;
            RestartButton.Enabled = true;
        }

        private void Board_FullLine(int index)
        {
            board.MoveValues(index);
            FullLinesCounter = FullLinesCounter + 1;
            Score = Score + 25;
            board.DrawBlocks(Draft,BlockSize);
            Image = Draft;
        }
        #region variables

        int RandomBlock;
        static Point PositionOfNextBlock = new Point(0, 0);

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

        #region methods

        void ShowNextBlock()
        {
            Nextblock = new Block(blocks[IndexOfNextBlock], PositionOfNextBlock, board);
            BoardForNextBlock.Clear();
            BoardForNextBlock.SetValue(Nextblock.d, Nextblock.skeleton, Nextblock.color);
            PainterForNextBlock.Clear();
            BoardForNextBlock.DrawBlocks(DraftForNextBlock, BlockSize);
            PainterForNextBlock.DrawArea();

            RImage = DraftForNextBlock;
           // timer1.Start();
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

        int Speed
        {
            get
            {
                if(timer1.Enabled==false)
                {
                    return 0;
                }
                return timer1.Interval;
            }
            set
            {
                if (value == 0)
                {
                    if (timer1.Enabled != false)
                    timer1.Enabled = false;
                }
                else
                {
                    if (timer1.Enabled != false)
                        timer1.Enabled = false;
                    timer1.Interval = value;
                    timer1.Enabled = true;
                }
            }
        }

        int Score
        {
            get
            {
                return Convert.ToInt32(Scorelabel.Text);
            }
            set
            {
                Scorelabel.Text = value + " ";
            }
        }

        int FullLinesCounter
        {
            get
            {
                return Int32.Parse(Lineslabel.Text);
            }
            set
            {
                Lineslabel.Text = value+" ";
            }
        }

        #endregion

        #region events

        private void timer1_Tick(object sender, EventArgs e)
        {
            painter.Clear();

            block.MoveToDown();

            board.DrawBlocks(Draft, BlockSize);

            painter.DrawArea();
            Image = Draft;

        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (Speed != 0)
            {
                switch (e.KeyCode.ToString())
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

                        try
                        {
                            block.Rotate();
                        }
                        catch
                        {
                            ;//
                        }

                        board.DrawBlocks(Draft, BlockSize);

                        painter.DrawArea();
                        Image = Draft;
                        break;
                    case "Down":

                        Speed = 400;
                        break;
                }
            }
        }

        private void Board_ArrivedAtBottom()
        {
           // Speed = 0;

            Score = Score + 15;
            board.CheckFullLines();

            block = new Block(blocks[IndexOfNextBlock], StartPoint, board);
            IndexOfNextBlock++;
            ShowNextBlock();


            // timer1.Start();
           // Speed = 400;
            //timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //painter.Clear();
            //board.SetValue(block.d, block.skeleton, block.color);
            //board.DrawBlocks(Draft,BlockSize);
            //painter.DrawArea();
            //Image = Draft;
           // timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode.ToString() == "Down")&&(Speed!=0))
            {
                Speed = 10;
            }
        }

        #endregion

        private void RestartButton_Click(object sender, EventArgs e)
        {
            RestartButton.Enabled = false;
            board.Clear();
            Score = 0;
            FullLinesCounter = 0;

            blocks = Enumerable.Range(0, 7).ToArray();
            Shuffle();
            IndexOfNextBlock = RandomBlock;

            block = new Block(blocks[RandomBlock], StartPoint, board);
            Nextblock = new Block(blocks[IndexOfNextBlock], PositionOfNextBlock, board);

            IndexOfNextBlock++;
            ShowNextBlock();

            Speed = 400;
            timer1.Enabled = true;
        }
    }
}
