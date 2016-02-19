using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    Shuffle();
                }
            }
        }


        public presenter(IMainWindow View)
        {
            this.View = View;
            BlockSize = Block.BlockSize;
            View.TheBestResult = (int)Settings.Default["TheBestResult"];

            Draft = new Bitmap(View.MainBoardWidth, View.MainBoardHeight);//
            DraftForNextBlock = new Bitmap(View.BoardWidth, View.BoardHeight);

            this.Painter =new Painter(Draft,BlockSize);
            PainterForNextBlock = new Painter(DraftForNextBlock, BlockSize);

            board = new Board(4, Draft.Height / BlockSize, Draft.Width / BlockSize);
            BoardForNextBlock = new Board(DraftForNextBlock.Height / BlockSize, DraftForNextBlock.Width / BlockSize);

            StartPoint = new Point(3, 0);
            RandomBlock = rand.Next(0, 7);

            blocks = Enumerable.Range(0, 7).ToArray();
            Shuffle();
            IndexOfNextBlock = RandomBlock;

            block = new Block(blocks[RandomBlock], StartPoint, board);
            nextblock = new Block(blocks[IndexOfNextBlock], PositionOfNextBlock, board);

            IndexOfNextBlock++;
            ShowNextBlock();

            View.Level = 1;
            View.Speed = defaultSpeed;
            //timer1.Enabled = true;

            Block.ArrivedAtBottom += Block_ArrivedAtBottom;
            board.FullLine += Board_FullLine;
            Block.GameOver += Block_GameOver;
            View.windowKeyDown += View_windowKeyDown;
            View.TimerTick += View_TimerTick;
            View.windowKeyUp += View_windowKeyUp;
        }

        private void View_windowKeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Down":
                    if (View.Speed != 0)
                    {
                        View.Speed = defaultSpeed;
                    }
                    break;
                case "R"://Restart

                    if (View.Score > View.TheBestResult)
                    {
                        Settings.Default["TheBestResult"] = View.Score;
                        Settings.Default.Save();
                    }
                    board.Clear();
                    View.Score = 0;
                    View.FullLinesCounter = 0;
                    View.Level = 1;
                    defaultSpeed = 400;
                    accelerate = 10;
                    incrementScore = new Point(15, 25);
                    View.TheBestResult = (int)Settings.Default["TheBestResult"];

                    blocks = Enumerable.Range(0, 7).ToArray();
                    Shuffle();
                    //IndexOfNextBlock = RandomBlock;

                    block = new Block(blocks[RandomBlock], StartPoint, board);
                    // Nextblock = new Block(blocks[IndexOfNextBlock], PositionOfNextBlock, board);

                    IndexOfNextBlock++;
                    ShowNextBlock();

                    View.Speed = defaultSpeed;
                    //timer1.Enabled = true;
                    break;

                case "P":
                    if (View.Speed != 0)
                    {
                        View.Speed = 0;
                    }
                    else
                    {
                       View.Speed = defaultSpeed;
                    }
                    break;
                case "C":
                    Settings.Default["TheBestResult"] = 0;
                    Settings.Default.Save();
                    View.TheBestResult = 0;
                    break;
            }
        }

        private void View_TimerTick(object sender, EventArgs e)
        {
            Painter.Clear();

            block.MoveToDown();

            board.DrawBlocks(Draft, BlockSize);

            Painter.DrawArea();
            View.MainBoard = Draft;
        }

        private void Block_GameOver()
        {
            View.Speed = 0;
            board.Clear();

            Painter.PrintGameOver();

            View.MainBoard = Draft;
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
            View.Speed = defaultSpeed;

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
            IndexOfNextBlock++;
            ShowNextBlock();

            View.Speed = defaultSpeed;
        }

        private void View_windowKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (View.Speed != 0)
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
                        View.Speed = accelerate;
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
            BoardForNextBlock.SetValue(nextblock.d, nextblock.skeleton, nextblock.color);
            PainterForNextBlock.Clear();
            BoardForNextBlock.DrawBlocks(DraftForNextBlock, BlockSize);
            PainterForNextBlock.DrawArea();

            View.Board = DraftForNextBlock;
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
    }
}
