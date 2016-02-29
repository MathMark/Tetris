using System;
using System.Linq;
using System.Drawing;
using Tetris.Properties;
using System.Windows.Forms;

namespace Tetris.Presenter
{
    public class presenter
    {
        private readonly IMainWindow View;
        private readonly Painter Painter;
        private readonly Painter PainterForNextBlock;
        private Block block;
        private Block nextblock;

        private readonly Board board;
        private readonly Board BoardForNextBlock;

        private readonly int BlockSize;
        Bitmap Draft;
        Bitmap DraftForNextBlock;


        private static int defaultSpeed = 400;
        private static int accelerate = 10;
        static Point incrementScore = new Point(15, 25);
        int RandomBlock;
        static Point PositionOfNextBlock = new Point(0, 0);

        Random rand = new Random();
        Point StartPoint;

        static int[] blocks;

        int indexOfNextBlock;

        event EventHandler GameOver;
        static bool gameOver=false;
        public int IndexOfNextBlock
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
                    blocks = Shuffle(blocks);
                }
            }
        }

        static Timer timer;
        public int Speed
        {
            get
            {
                if (timer.Enabled == false)
                {
                    return 0;
                }
                return timer.Interval;
            }
            set
            {
                if (value == 0)
                {
                    timer.Stop();
                }
                else
                {
                    
                    timer.Interval = value;
                    timer.Start();
                }
            }
        }

        public presenter(IMainWindow View)
        {
            timer = new Timer();
            timer.Tick += Timer_Tick;

            this.View = View;

            BlockSize = Block.BlockSize;
            View.TopScore = (int)Settings.Default["TopScore"];

            Draft = new Bitmap(View.MainBoardWidth, View.MainBoardHeight);//
            DraftForNextBlock = new Bitmap(View.BoardWidth, View.BoardHeight);

            this.Painter =new Painter(Draft,BlockSize);
            PainterForNextBlock = new Painter(DraftForNextBlock, BlockSize);

            board = new Board(4, Draft.Height / BlockSize, Draft.Width / BlockSize);
            BoardForNextBlock = new Board(DraftForNextBlock.Height / BlockSize, DraftForNextBlock.Width / BlockSize);

            StartPoint = new Point(3, 0);
            RandomBlock = rand.Next(0, 7);

            blocks = Enumerable.Range(0, 7).ToArray();
            blocks = Shuffle(blocks);
            IndexOfNextBlock = RandomBlock;

            block = new Block(blocks[RandomBlock], StartPoint, board);
            nextblock = new Block(blocks[IndexOfNextBlock], PositionOfNextBlock, board);

            IndexOfNextBlock++;
            ShowNextBlock();

            View.Level = 1;
            
            View.Score = 0;

            Block.ArrivedAtBottom += Block_ArrivedAtBottom;
            board.FullLine += Board_FullLine;
            View.windowKeyDown += View_windowKeyDown;
            View.windowKeyUp += View_windowKeyUp;
            GameOver += Presenter_GameOver;

            View.FullLinesCounter = 0;

            Speed = defaultSpeed;
        }

        private void Presenter_GameOver(object sender, EventArgs e)
        {
            Speed = 0;
            
            Painter.PrintGameOver();
            View.MainBoard = Draft;

            board.Clear();
            Painter.ColorArea = Color.Empty;
            gameOver = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Painter.Clear();

            block.MoveToDown();

            board.DrawBlocks(Draft, BlockSize);

            Painter.DrawArea();
            View.MainBoard = Draft;
        }

        private void View_windowKeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Down":
                    if (Speed != 0)
                    {
                        Speed = defaultSpeed;
                    }
                    
                    break;
                case "R"://Restart

                    if (View.Score > View.TopScore)
                    {
                        Settings.Default["TopScore"] = View.Score;
                        Settings.Default.Save();
                    }
                    gameOver = false;
                    Painter.ColorArea = Color.Black;
                    board.Clear();
                    View.Score = 0;
                    View.FullLinesCounter = 0;
                    View.Level = 1;
                    defaultSpeed = 400;
                    accelerate = 10;
                    incrementScore = new Point(15, 25);
                    View.TopScore = (int)Settings.Default["TopScore"];

                    blocks = Enumerable.Range(0, 7).ToArray();
                    blocks = Shuffle(blocks);
                    //IndexOfNextBlock = RandomBlock;

                    block = new Block(blocks[RandomBlock], StartPoint, board);
                    // Nextblock = new Block(blocks[IndexOfNextBlock], PositionOfNextBlock, board);

                    IndexOfNextBlock++;
                    ShowNextBlock();

                    View.SetNull();
                    Speed = defaultSpeed;
                    break;

                case "P":
                    if (Speed != 0)
                    {
                        Speed = 0;
                        Painter.PrintPause();
                        View.MainBoard = Draft;
                    }
                    else if(!gameOver)
                    {
                       Speed = defaultSpeed;
                    }
                    break;
                case "C":

                    View.TopScore = 0;
                    View.SetTopScoreToNull();
                    Settings.Default.Save();

                    break;
            }
        }

        private void Board_FullLine(int index)
        {
            View.FullLinesCounter = View.FullLinesCounter + 1;
            if (View.FullLinesCounter == 10)
            {
                View.Level = 2;
                defaultSpeed = 200;
                accelerate = 5;
                incrementScore = new Point(25, 35);
            }
            if (View.FullLinesCounter == 20)
            {
                View.Level = 3;
                defaultSpeed = 100;
                accelerate = 1;
                incrementScore = new Point(35, 100);
            }
            Speed = defaultSpeed;

            board.MoveValues(index);

            View.Score = View.Score + incrementScore.Y;
            board.DrawBlocks(Draft, BlockSize);
            View.MainBoard = Draft;
        }

        private void Block_ArrivedAtBottom()
        {
            View.Score = View.Score + incrementScore.X;
            board.CheckFullLines();

            block = new Block(blocks[IndexOfNextBlock], StartPoint, board);
            if (block.Over()==true)
            {
                GameOver(this,EventArgs.Empty);
            }
            else
            {
                IndexOfNextBlock++;
                ShowNextBlock();

                Speed = defaultSpeed;
            }
        }

        private void View_windowKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Speed != 0)
            {
                Painter.Clear();
                switch (e.KeyCode.ToString())
                {
                    case "Left":
                        block.MoveToLeft();
                        break;
                    case "Right":
                        block.MoveToRight();
                        break;
                    case "Up":
                        block.Rotate();
                        break;

                    case "Down":
                        Speed = accelerate;
                        break;
                }
                board.DrawBlocks(Draft, BlockSize);
                Painter.DrawArea();
                View.MainBoard = Draft;
            }
        }
        void ShowNextBlock()
        {
            nextblock = new Block(blocks[IndexOfNextBlock], PositionOfNextBlock, board);
            BoardForNextBlock.Clear();
            BoardForNextBlock.SetValue(nextblock.d, nextblock.skeleton, nextblock.Unit);
            PainterForNextBlock.Clear();
            BoardForNextBlock.DrawBlocks(DraftForNextBlock, BlockSize);
            PainterForNextBlock.DrawArea();

            View.Board = DraftForNextBlock;
        }

        public static int[] Shuffle(int[] blocks)
        {
            Random rnd = new Random();
			for (int i = blocks.Length - 1; i > 1; i--) 
			{
				int newIndex = rnd.Next(i + 1);
                int buffer = blocks[i];
                blocks[i] = blocks[newIndex];
                blocks[newIndex] = buffer;
			}

            return blocks;
        }
    }
}
