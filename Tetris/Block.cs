using System;
using System.Drawing;


namespace Tetris
{
    public class Block:IMove
    {
        public static event Action ArrivedAtBottom;

        int typeBlock;
        public Point d;

        public int TypeBlock
        {
            get
            {
                return typeBlock;
            }
            set
            {
                if((value>=0)&&(value<=7))
                {
                    typeBlock = value;
                }
                else
                {
                    typeBlock = 0;
                }
            }
        }

        Board board;

        public bool[,] skeleton;
        public Color color
        {
            get
            {
                return basecolor;
            }
        }
        Color basecolor;

        public Block(int TypeBlock,Point Location,Board board)
        {
            this.board = board;
            this.d = Location;

            this.TypeBlock = TypeBlock;
            switch(typeBlock)
            {
                case 0://T-Block
                    skeleton =new bool[4,4]{
                        { false,false,false,false},
                        { false,true,true,true},
                        { false,false,true,false},
                        { false,false,false,false}  
                    };
                    basecolor = Color.DodgerBlue;
                    break;
                case 1://O-Block
                    skeleton = new bool[4, 4]{
                        { false,false,false,false},
                        { false,true,true,false},
                        { false,true,true,false},
                        { false,false,false,false}
                    };
                    basecolor = Color.DarkOrange;
                    break;
                case 2://I-Block
                    skeleton = new bool[4, 4]{
                        { false,false,false,false},
                        { true,true,true,true},
                        { false,false,false,false},
                        { false,false,false,false}
                    };
                    basecolor = Color.Yellow;
                    break;
                case 3://S-Block
                    skeleton = new bool[4, 4]{
                        { false,false,false,false},
                        { false,false,true,true},
                        { false,true,true,false},
                        { false,false,false,false}
                    };
                    basecolor = Color.Red;
                    break;
                case 4://Z-Block
                    skeleton = new bool[4, 4]{
                        { false,false,false,false},
                        { false,true,true,false},
                        { false,false,true,true},
                        { false,false,false,false}
                    };
                    basecolor = Color.MediumPurple;
                    break;
                case 5://L-Block
                    skeleton = new bool[4, 4]{
                        { false,false,false,false},
                        { false,true,true,true},
                        { false,true,false,false},
                        { false,false,false,false}
                    };
                    basecolor = Color.YellowGreen;
                    break;
                case 6://J-Block
                    skeleton = new bool[4, 4]{
                        { false,false,false,false},
                        { false,true,true,true},
                        { false,false,false,true},
                        { false,false,false,false}
                    };
                    basecolor = Color.Gray;
                    break;

            }
        }
        public void MoveToLeft()
        {
            for (int i = 0; i < skeleton.GetLength(0); i++)
            {
                for (int j = 0; j < skeleton.GetLength(1); j++)
                {
                    if (skeleton[i, j] == true)
                    {
                        if ((j-1 <0) || (skeleton[i, j-1] == false))
                        {
                            if (board.CheckExistence(new Point(i + d.Y, j-1 + d.X)) == true)
                            {
                                return;
                            }
                        }
                    }
                }
            }
            board.RelieveValue(d, skeleton);
            d.X--;
            board.SetValue(d, skeleton, color);
        }
        public void MoveToRight()
        {
            for (int i = 0; i < skeleton.GetLength(0); i++)
            {
                for (int j = skeleton.GetLength(1)-1; j >=0; j--)
                {
                    if (skeleton[i, j] == true)
                    {
                        if ((j + 1 > skeleton.GetLength(1) - 1) || (skeleton[i, j + 1] == false))
                        {
                            if (board.CheckExistence(new Point(i + d.Y, j + 1 + d.X)) == true)
                            {
                                return;
                            }
                        }
                    }
                }
            }
            board.RelieveValue(d, skeleton);
            d.X++;
            board.SetValue(d, skeleton, color);
        }
        public void MoveToDown()
        {
            for (int i = skeleton.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < skeleton.GetLength(1); j++)
                {
                    if (skeleton[i, j] == true)
                    {
                        if ((i + 1 > skeleton.GetLength(0) - 1) || (skeleton[i + 1, j] == false))
                        {
                            if (board.CheckExistence(new Point(i + 1 + d.Y, j + d.X)) == true)
                            {
                                ArrivedAtBottom();
                                return;
                            }
                        }
                    }
                }
            }
            board.RelieveValue(d,skeleton);
            d.Y++;
            board.SetValue(d, skeleton, color);
        }
        public void Rotate()
        {
            bool[,] temp = new bool[4, 4];

            for(int j=temp.GetLength(1)-1;j>=0;j--)
            {
                for(int i=0; i<temp.GetLength(0);i++)
                {
                    temp[i, j] = skeleton[temp.GetLength(1) - j - 1, i];
                }
            }
            board.RelieveValue(d, skeleton);
            skeleton = (bool[,])temp.Clone();
            board.SetValue(d, skeleton, color);
        }

    }
}
