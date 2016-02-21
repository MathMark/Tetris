using System;
using System.Drawing;
using System.Windows.Forms;

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
        }
        public event KeyEventHandler windowKeyDown;
        public event KeyEventHandler windowKeyUp;
        public event EventHandler TimerTick;


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

        public int FullLinesCounter
        {
            get
            {
                return Int32.Parse(Lineslabel.Text);
            }
            set
            {
                Lineslabel.Text = value.ToString();
            }
        }
       public int Level
        {
            get
            {
                return Convert.ToInt32(Levellabel.Text);
            }
            set
            {
                Levellabel.Text = value.ToString();
            }
        }
    }
}
