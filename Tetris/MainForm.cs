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
        int TopScore { get; set; }
        int MainBoardWidth { get; }
        int MainBoardHeight { get; }
        int BoardWidth { get; }
        int BoardHeight { get; }
        void SetNull();
        void SetTopScoreToNull();


        event KeyEventHandler windowKeyDown;
        event KeyEventHandler windowKeyUp;
        event EventHandler TimerTick;
    }
    public partial class MainForm : Form,IMainWindow
    {
        public MainForm()
        {
            InitializeComponent();
            timer1.Tick += (object sender, EventArgs e) =>
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
			
            LinesBoxes = new PictureBox[] { LineBox1, LineBox2 };
            ScoreBoxes = new PictureBox[] { ScoreBox1, ScoreBox2, ScoreBox3, ScoreBox4, ScoreBox5, ScoreBox6 };
            TopScoreBoxes = new PictureBox[] { TopScoreBox1, TopScoreBox2, TopScoreBox3, TopScoreBox4, TopScoreBox5, TopScoreBox6 };
            SetNull();
        }

        public event KeyEventHandler windowKeyDown;
        public event KeyEventHandler windowKeyUp;
        public event EventHandler TimerTick;

        public void SetNull()
        {
            for (int i = 1; i < ScoreBoxes.Length; i++)
            {
                ScoreBoxes[i].Image = null;
            }
            ScoreBox1.Image = Resources._0;
            LineBox1.Image = Resources._0;
            LineBox2.Image = null;
        }
        public void SetTopScoreToNull()
        {
            Settings.Default["TopScore"] = 0;
            for (int i = 1; i < TopScoreBoxes.Length; i++)
            {
                TopScoreBoxes[i].Image = null;
            }
            TopScoreBox1.Image = Resources.TopScore_0;
        }

        public void SetNumbers(string Value, PictureBox[] pictureBoxes)
        {
            for (int i = 0; i < Value.Length; i++)
            {
				pictureBoxes[i].Image = (Bitmap)Tetris.Properties.Resources.ResourceManager.GetObject("_" + Value[i].ToString());
            }
        }

        PictureBox[] LinesBoxes;
        PictureBox[] ScoreBoxes;
        PictureBox[] TopScoreBoxes;

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
                if (timer1.Enabled == false)
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
        int score;
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                //string Value = value.ToString();
                SetNumbers(value.ToString(), ScoreBoxes);
                score = value;
            }
        }

        public int TopScore
        {
            get
            {
                return (int)Settings.Default["TopScore"];
            }
            set
            {
                string Value = value.ToString();
                for (int i = 0; i < Value.Length; i++)
                {
                    switch (Value[i])
                    {
                        case '0':
                            TopScoreBoxes[i].Image = Resources.TopScore_0;
                            break;
                        case '1':
                            TopScoreBoxes[i].Image = Resources.TopScore_1;
                            break;
                        case '2':
                            TopScoreBoxes[i].Image = Resources.TopScore_2;
                            break;
                        case '3':
                            TopScoreBoxes[i].Image = Resources.TopScore_3;
                            break;
                        case '4':
                            TopScoreBoxes[i].Image = Resources.TopScore_4;
                            break;
                        case '5':
                            TopScoreBoxes[i].Image = Resources.TopScore_5;
                            break;
                        case '6':
                            TopScoreBoxes[i].Image = Resources.TopScore_6;
                            break;
                        case '7':
                            TopScoreBoxes[i].Image = Resources.TopScore_7;
                            break;
                        case '8':
                            TopScoreBoxes[i].Image = Resources.TopScore_8;
                            break;
                        case '9':
                            TopScoreBoxes[i].Image = Resources.TopScore_9;
                            break;

                    }
                }
                Settings.Default["TopScore"] = value;
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
                SetNumbers(value.ToString(), LinesBoxes);
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
                switch (value)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
