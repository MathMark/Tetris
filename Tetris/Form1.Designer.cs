namespace Tetris
{
    partial class Form1
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
            this.Sheet = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.RandomBSheet = new System.Windows.Forms.PictureBox();
            this.RestartButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Lineslabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Sheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomBSheet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Sheet
            // 
            this.Sheet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Sheet.Location = new System.Drawing.Point(34, 12);
            this.Sheet.Name = "Sheet";
            this.Sheet.Size = new System.Drawing.Size(350, 560);
            this.Sheet.TabIndex = 0;
            this.Sheet.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // RandomBSheet
            // 
            this.RandomBSheet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.RandomBSheet.Location = new System.Drawing.Point(455, 26);
            this.RandomBSheet.Name = "RandomBSheet";
            this.RandomBSheet.Size = new System.Drawing.Size(140, 140);
            this.RandomBSheet.TabIndex = 4;
            this.RandomBSheet.TabStop = false;
            // 
            // RestartButton
            // 
            this.RestartButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RestartButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RestartButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RestartButton.Location = new System.Drawing.Point(59, 18);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(75, 23);
            this.RestartButton.TabIndex = 5;
            this.RestartButton.TabStop = false;
            this.RestartButton.Text = "Restart";
            this.RestartButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel1.Controls.Add(this.Lineslabel);
            this.panel1.Controls.Add(this.RestartButton);
            this.panel1.Location = new System.Drawing.Point(413, 248);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 153);
            this.panel1.TabIndex = 6;
            // 
            // Lineslabel
            // 
            this.Lineslabel.AutoSize = true;
            this.Lineslabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lineslabel.ForeColor = System.Drawing.SystemColors.Control;
            this.Lineslabel.Location = new System.Drawing.Point(39, 77);
            this.Lineslabel.Name = "Lineslabel";
            this.Lineslabel.Size = new System.Drawing.Size(63, 15);
            this.Lineslabel.TabIndex = 6;
            this.Lineslabel.Text = "Lines: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(642, 603);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.RandomBSheet);
            this.Controls.Add(this.Sheet);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Tetris";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Sheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomBSheet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Sheet;
        private System.Windows.Forms.PictureBox RandomBSheet;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button RestartButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Lineslabel;
    }
}

