namespace MeatballTennis
{
    partial class GameSetup
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
            this.Cancel = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.ServerButton = new System.Windows.Forms.RadioButton();
            this.ClientButton = new System.Windows.Forms.RadioButton();
            this.IPAddress = new System.Windows.Forms.TextBox();
            this.Port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(208, 95);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(127, 95);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 0;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ServerButton
            // 
            this.ServerButton.AutoSize = true;
            this.ServerButton.Checked = true;
            this.ServerButton.Location = new System.Drawing.Point(13, 13);
            this.ServerButton.Name = "ServerButton";
            this.ServerButton.Size = new System.Drawing.Size(56, 17);
            this.ServerButton.TabIndex = 2;
            this.ServerButton.TabStop = true;
            this.ServerButton.Text = "Server";
            this.ServerButton.UseVisualStyleBackColor = true;
            this.ServerButton.CheckedChanged += new System.EventHandler(this.ServerButton_CheckedChanged);
            // 
            // ClientButton
            // 
            this.ClientButton.AutoSize = true;
            this.ClientButton.Location = new System.Drawing.Point(75, 13);
            this.ClientButton.Name = "ClientButton";
            this.ClientButton.Size = new System.Drawing.Size(51, 17);
            this.ClientButton.TabIndex = 3;
            this.ClientButton.Text = "Client";
            this.ClientButton.UseVisualStyleBackColor = true;
            // 
            // IPAddress
            // 
            this.IPAddress.Enabled = false;
            this.IPAddress.Location = new System.Drawing.Point(75, 50);
            this.IPAddress.Name = "IPAddress";
            this.IPAddress.Size = new System.Drawing.Size(100, 20);
            this.IPAddress.TabIndex = 4;
            this.IPAddress.Text = "127.0.0.1";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(218, 50);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(47, 20);
            this.Port.TabIndex = 5;
            this.Port.Text = "32792";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Port";
            // 
            // GameSetup
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 139);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.IPAddress);
            this.Controls.Add(this.ClientButton);
            this.Controls.Add(this.ServerButton);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Cancel);
            this.Name = "GameSetup";
            this.Text = "Meatball Tennis";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.RadioButton ServerButton;
        private System.Windows.Forms.RadioButton ClientButton;
        private System.Windows.Forms.TextBox IPAddress;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}