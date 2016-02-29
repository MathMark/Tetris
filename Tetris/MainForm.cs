using System;
using System.Drawing;
using System.Windows.Forms;
using Tetris.Properties;
using System.Media;

namespace Tetris
{
    public interface IMainWindow
    {
        Bitmap MainBoard { get; set; }
        Bitmap Board { get; set; }
        int Level { get; set; }
        int Score { get; set; }
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
    }

    public partial class MainForm : Form,IMainWindow
    {
        public MainForm()
        {
            InitializeComponent();

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
                pictureBoxes[i].Image = (Bitmap)Resources.ResourceManager.GetObject("_" + Value[i].ToString());
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

        int score;
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
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
                    TopScoreBoxes[i].Image = (Bitmap)Resources.ResourceManager.GetObject("TopScore_" + Value[i]); 
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
                LevelBox.Image = (Bitmap)Resources.ResourceManager.GetObject("Level_" + value);
                level = value;
            }
        }

    }
}
