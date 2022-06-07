namespace MeatballTennis
{
    partial class GameCanvas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameCanvas));
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.P1Score = new System.Windows.Forms.Label();
            this.P2Score = new System.Windows.Forms.Label();
            this.Gover = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 10;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // P1Score
            // 
            this.P1Score.AutoSize = true;
            this.P1Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1Score.Location = new System.Drawing.Point(13, 13);
            this.P1Score.Name = "P1Score";
            this.P1Score.Size = new System.Drawing.Size(82, 31);
            this.P1Score.TabIndex = 0;
            this.P1Score.Text = "P1: 0";
            // 
            // P2Score
            // 
            this.P2Score.AutoSize = true;
            this.P2Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2Score.Location = new System.Drawing.Point(511, 13);
            this.P2Score.Name = "P2Score";
            this.P2Score.Size = new System.Drawing.Size(82, 31);
            this.P2Score.TabIndex = 1;
            this.P2Score.Text = "P2: 0";
            // 
            // Gover
            // 
            this.Gover.AutoSize = true;
            this.Gover.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gover.Location = new System.Drawing.Point(182, 188);
            this.Gover.Name = "Gover";
            this.Gover.Size = new System.Drawing.Size(255, 51);
            this.Gover.TabIndex = 2;
            this.Gover.Text = "Game Over!";
            this.Gover.Visible = false;
            // 
            // GameCanvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.Gover);
            this.Controls.Add(this.P2Score);
            this.Controls.Add(this.P1Score);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 480);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "GameCanvas";
            this.Text = "Meatball Tennis";
            this.Load += new System.EventHandler(this.GameCanvas_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameCanvas_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameCanvas_KeyUp);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameCanvas_FormClose);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameCanvas_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Label P1Score;
        private System.Windows.Forms.Label P2Score;
        private System.Windows.Forms.Label Gover;
    }
}

