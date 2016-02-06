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
            ((System.ComponentModel.ISupportInitialize)(this.Sheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomBSheet)).BeginInit();
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
            this.RandomBSheet.Location = new System.Drawing.Point(410, 12);
            this.RandomBSheet.Name = "RandomBSheet";
            this.RandomBSheet.Size = new System.Drawing.Size(206, 274);
            this.RandomBSheet.TabIndex = 4;
            this.RandomBSheet.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(642, 603);
            this.Controls.Add(this.RandomBSheet);
            this.Controls.Add(this.Sheet);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Tetris";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Sheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomBSheet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Sheet;
        private System.Windows.Forms.PictureBox RandomBSheet;
        public System.Windows.Forms.Timer timer1;
    }
}

