using System;
using System.Drawing;
using System.Windows.Forms;
using Tetris.Properties;

namespace Tetris
{
    public interface IMainWindow
    {
        Bitmap MainBoard { get; set; }
        Bitmap Board { get; set; }
        int Level { get; set; }
        int Score { get; set; }
        int Speed { get; set; }
        int FullLinesCounter { get; set; }
        int TheBestResult { get; set; }
        int MainBoardWidth { get; }
        int MainBoardHeight { get; }
        int BoardWidth { get; }
        int BoardHeight { get; }


        event KeyEventHandler windowKeyDown;
        event KeyEventHandler windowKeyUp;
        event EventHandler TimerTick;
    }
    public partial class MainWindow : Form,IMainWindow
    {

        public MainWindow()
        {
            InitializeComponent();

            timer1.Tick+=(object sender,EventArgs e)=>
            {
                if (TimerTick != null)
                {
                    TimerTick(this, EventArgs.Empty);
                }
            };
            KeyDown += (object sender, KeyEventArgs e) =>
              {
                  windowKeyDown(this, e);
              };
            KeyUp += (object sender, KeyEventArgs e) =>
              {
                  windowKeyUp(this, e);
              };

            LinesBoxes = new PictureBox[] { LineBox1,LineBox2};
        }
        public event KeyEventHandler windowKeyDown;
        public event KeyEventHandler windowKeyUp;
        public event EventHandler TimerTick;

        PictureBox[] LinesBoxes;
        public Bitmap MainBoard
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
        public int MainBoardWidth
        {
            get
            {
                return Sheet.Width;
            }
        }
        public int MainBoardHeight
        {
            get
            {
                return Sheet.Height;
            }
        }

        public Bitmap Board
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
        public int BoardWidth
        {
            get
            {
                return RandomBSheet.Width;
            }
        }
        public int BoardHeight
        {
            get
            {
                return RandomBSheet.Height;
            }
        }


        public int Speed
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

       public int Score
        {
            get
            {
                return Convert.ToInt32(Scorelabel.Text);
            }
            set
            {
                Scorelabel.Text = value.ToString();
            }
        }

       public int TheBestResult
        {
            get
            {
                return Convert.ToInt32(BestResultlabel.Text);
            }
            set
            {
                BestResultlabel.Text = value.ToString();
            }
        }
        int lines;
        public int FullLinesCounter
        {
            get
            {
                return lines;
            }
            set
            {
                string Value = value.ToString();
                for(int i=0;i<Value.Length;i++)
                {
                    switch(Value[i])
                    {
                        case '0':
                            LinesBoxes[i].Image = Resources._0;
                            break;
                        case '1':
                            LinesBoxes[i].Image = Resources._111;
                            break;
                        case '2':
                            LinesBoxes[i].Image = Resources._2;
                            break;
                        case '3':
                            LinesBoxes[i].Image = Resources._3;
                            break;
                        case '4':
                            LinesBoxes[i].Image = Resources._4;
                            break;
                        case '5':
                            LinesBoxes[i].Image = Resources._5;
                            break;
                        case '6':
                            LinesBoxes[i].Image = Resources._6;
                            break;
                        case '7':
                            LinesBoxes[i].Image = Resources._7;
                            break;
                        case '8':
                            LinesBoxes[i].Image = Resources._8;
                            break;
                        case '9':
                            LinesBoxes[i].Image = Resources._9;
                            break;

                    }
                }
                lines = value;
            }
        }
        int level;
       public int Level
        {
            get
            {
                return level;
            }
            set
            {
                switch(value)
                {
                    case 1:
                        LevelBox.Image = Resources.Level_1;
                        break;
                    case 2:
                        LevelBox.Image = Resources.Level_2;
                        break;
                    case 3:
                        LevelBox.Image = Resources.Level_3;
                        break;
                }
                level = value;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
