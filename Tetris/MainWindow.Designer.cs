namespace Tetris
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.BestResultlabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Levellabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Scorelabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Lineslabel = new System.Windows.Forms.Label();
            this.SheetforText = new System.Windows.Forms.PictureBox();
            this.RandomBSheet = new System.Windows.Forms.PictureBox();
            this.Sheet = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SheetforText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomBSheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sheet)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.BestResultlabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Levellabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Scorelabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Lineslabel);
            this.panel1.Location = new System.Drawing.Point(422, 266);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 211);
            this.panel1.TabIndex = 6;
            // 
            // BestResultlabel
            // 
            this.BestResultlabel.AutoSize = true;
            this.BestResultlabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BestResultlabel.ForeColor = System.Drawing.Color.Gold;
            this.BestResultlabel.Location = new System.Drawing.Point(140, 176);
            this.BestResultlabel.Name = "BestResultlabel";
            this.BestResultlabel.Size = new System.Drawing.Size(0, 15);
            this.BestResultlabel.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(8, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "The best result: ";
            // 
            // Levellabel
            // 
            this.Levellabel.AutoSize = true;
            this.Levellabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Levellabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Levellabel.Location = new System.Drawing.Point(120, 23);
            this.Levellabel.Name = "Levellabel";
            this.Levellabel.Size = new System.Drawing.Size(14, 15);
            this.Levellabel.TabIndex = 11;
            this.Levellabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(39, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Level: ";
            // 
            // Scorelabel
            // 
            this.Scorelabel.AutoSize = true;
            this.Scorelabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Scorelabel.ForeColor = System.Drawing.Color.YellowGreen;
            this.Scorelabel.Location = new System.Drawing.Point(120, 132);
            this.Scorelabel.Name = "Scorelabel";
            this.Scorelabel.Size = new System.Drawing.Size(14, 15);
            this.Scorelabel.TabIndex = 9;
            this.Scorelabel.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(39, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Score: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(39, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Lines: ";
            // 
            // Lineslabel
            // 
            this.Lineslabel.AutoSize = true;
            this.Lineslabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lineslabel.ForeColor = System.Drawing.Color.MediumPurple;
            this.Lineslabel.Location = new System.Drawing.Point(120, 76);
            this.Lineslabel.Name = "Lineslabel";
            this.Lineslabel.Size = new System.Drawing.Size(14, 15);
            this.Lineslabel.TabIndex = 6;
            this.Lineslabel.Text = "0";
            // 
            // SheetforText
            // 
            this.SheetforText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.SheetforText.Image = ((System.Drawing.Image)(resources.GetObject("SheetforText.Image")));
            this.SheetforText.Location = new System.Drawing.Point(449, 12);
            this.SheetforText.Name = "SheetforText";
            this.SheetforText.Size = new System.Drawing.Size(140, 72);
            this.SheetforText.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SheetforText.TabIndex = 7;
            this.SheetforText.TabStop = false;
            // 
            // RandomBSheet
            // 
            this.RandomBSheet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.RandomBSheet.Location = new System.Drawing.Point(449, 90);
            this.RandomBSheet.Name = "RandomBSheet";
            this.RandomBSheet.Size = new System.Drawing.Size(140, 140);
            this.RandomBSheet.TabIndex = 4;
            this.RandomBSheet.TabStop = false;
            // 
            // Sheet
            // 
            this.Sheet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Sheet.Location = new System.Drawing.Point(34, 12);
            this.Sheet.Name = "Sheet";
            this.Sheet.Size = new System.Drawing.Size(350, 770);
            this.Sheet.TabIndex = 0;
            this.Sheet.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(646, 797);
            this.Controls.Add(this.SheetforText);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.RandomBSheet);
            this.Controls.Add(this.Sheet);
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.Text = "Tetris";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SheetforText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomBSheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sheet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Sheet;
        private System.Windows.Forms.PictureBox RandomBSheet;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Lineslabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Scorelabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Levellabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox SheetforText;
        private System.Windows.Forms.Label BestResultlabel;
        private System.Windows.Forms.Label label4;
    }
}

