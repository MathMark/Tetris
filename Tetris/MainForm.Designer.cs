namespace Tetris
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SheetforText = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LineBox1 = new System.Windows.Forms.PictureBox();
            this.LineBox2 = new System.Windows.Forms.PictureBox();
            this.LevelBox = new System.Windows.Forms.PictureBox();
            this.BestResultlabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Scorelabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RandomBSheet = new System.Windows.Forms.PictureBox();
            this.Sheet = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SheetforText)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LineBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LevelBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomBSheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sheet)).BeginInit();
            this.SuspendLayout();
            // 
            // SheetforText
            // 
            this.SheetforText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.SheetforText.Image = ((System.Drawing.Image)(resources.GetObject("SheetforText.Image")));
            this.SheetforText.Location = new System.Drawing.Point(516, 23);
            this.SheetforText.Name = "SheetforText";
            this.SheetforText.Size = new System.Drawing.Size(140, 72);
            this.SheetforText.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SheetforText.TabIndex = 11;
            this.SheetforText.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.LevelBox);
            this.panel1.Controls.Add(this.BestResultlabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Scorelabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(440, 325);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 435);
            this.panel1.TabIndex = 10;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.LineBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LineBox2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(132, 120);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(117, 69);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // LineBox1
            // 
            this.LineBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.LineBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LineBox1.Location = new System.Drawing.Point(3, 3);
            this.LineBox1.Name = "LineBox1";
            this.LineBox1.Size = new System.Drawing.Size(52, 63);
            this.LineBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LineBox1.TabIndex = 14;
            this.LineBox1.TabStop = false;
            // 
            // LineBox2
            // 
            this.LineBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.LineBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LineBox2.Location = new System.Drawing.Point(61, 3);
            this.LineBox2.Name = "LineBox2";
            this.LineBox2.Size = new System.Drawing.Size(53, 63);
            this.LineBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LineBox2.TabIndex = 15;
            this.LineBox2.TabStop = false;
            // 
            // LevelBox
            // 
            this.LevelBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.LevelBox.Location = new System.Drawing.Point(161, 28);
            this.LevelBox.Name = "LevelBox";
            this.LevelBox.Size = new System.Drawing.Size(55, 69);
            this.LevelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LevelBox.TabIndex = 8;
            this.LevelBox.TabStop = false;
            // 
            // BestResultlabel
            // 
            this.BestResultlabel.AutoSize = true;
            this.BestResultlabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BestResultlabel.ForeColor = System.Drawing.Color.Gold;
            this.BestResultlabel.Location = new System.Drawing.Point(146, 351);
            this.BestResultlabel.Name = "BestResultlabel";
            this.BestResultlabel.Size = new System.Drawing.Size(0, 15);
            this.BestResultlabel.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(14, 351);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "The best result: ";
            // 
            // Scorelabel
            // 
            this.Scorelabel.AutoSize = true;
            this.Scorelabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Scorelabel.ForeColor = System.Drawing.Color.YellowGreen;
            this.Scorelabel.Location = new System.Drawing.Point(146, 263);
            this.Scorelabel.Name = "Scorelabel";
            this.Scorelabel.Size = new System.Drawing.Size(14, 15);
            this.Scorelabel.TabIndex = 9;
            this.Scorelabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(20, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 32);
            this.label3.TabIndex = 10;
            this.label3.Text = "Level: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(20, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "Score: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(20, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Lines: ";
            // 
            // RandomBSheet
            // 
            this.RandomBSheet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.RandomBSheet.Location = new System.Drawing.Point(516, 101);
            this.RandomBSheet.Name = "RandomBSheet";
            this.RandomBSheet.Size = new System.Drawing.Size(140, 140);
            this.RandomBSheet.TabIndex = 9;
            this.RandomBSheet.TabStop = false;
            // 
            // Sheet
            // 
            this.Sheet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Sheet.Location = new System.Drawing.Point(41, 20);
            this.Sheet.Name = "Sheet";
            this.Sheet.Size = new System.Drawing.Size(350, 770);
            this.Sheet.TabIndex = 8;
            this.Sheet.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(771, 802);
            this.Controls.Add(this.SheetforText);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.RandomBSheet);
            this.Controls.Add(this.Sheet);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.SheetforText)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LineBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LevelBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomBSheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sheet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox SheetforText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox LineBox1;
        private System.Windows.Forms.PictureBox LineBox2;
        private System.Windows.Forms.PictureBox LevelBox;
        private System.Windows.Forms.Label BestResultlabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Scorelabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox RandomBSheet;
        private System.Windows.Forms.PictureBox Sheet;
    }
}