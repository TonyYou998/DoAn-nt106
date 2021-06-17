
namespace Client
{
    partial class Join
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
            this.Roll_number = new System.Windows.Forms.PictureBox();
            this.btn_exit = new System.Windows.Forms.PictureBox();
            this.btn_Roll = new System.Windows.Forms.PictureBox();
            this.alert = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.Roll_number)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Roll)).BeginInit();
            this.SuspendLayout();
            // 
            // Roll_number
            // 
            this.Roll_number.BackColor = System.Drawing.Color.Transparent;
            this.Roll_number.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Roll_number.Location = new System.Drawing.Point(913, 47);
            this.Roll_number.Name = "Roll_number";
            this.Roll_number.Size = new System.Drawing.Size(297, 287);
            this.Roll_number.TabIndex = 23;
            this.Roll_number.TabStop = false;
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_exit.Location = new System.Drawing.Point(983, 469);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(174, 70);
            this.btn_exit.TabIndex = 22;
            this.btn_exit.TabStop = false;
            // 
            // btn_Roll
            // 
            this.btn_Roll.BackColor = System.Drawing.Color.Transparent;
            this.btn_Roll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Roll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Roll.Location = new System.Drawing.Point(983, 378);
            this.btn_Roll.Name = "btn_Roll";
            this.btn_Roll.Size = new System.Drawing.Size(174, 70);
            this.btn_Roll.TabIndex = 21;
            this.btn_Roll.TabStop = false;
            this.btn_Roll.Click += new System.EventHandler(this.btn_roll_Click);
            // 
            // alert
            // 
            this.alert.AutoSize = true;
            this.alert.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.alert.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.alert.Location = new System.Drawing.Point(52, 19);
            this.alert.Name = "alert";
            this.alert.Size = new System.Drawing.Size(63, 26);
            this.alert.TabIndex = 24;
            this.alert.Text = "label1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(913, 9);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(297, 30);
            this.progressBar1.TabIndex = 25;
            // 
            // Join
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1270, 712);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.alert);
            this.Controls.Add(this.Roll_number);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_Roll);
            this.DoubleBuffered = true;
            this.Name = "Join";
            this.Text = "Player_Join";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Join_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Roll_number)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Roll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Roll_number;
        private System.Windows.Forms.PictureBox btn_exit;
        private System.Windows.Forms.PictureBox btn_Roll;
        private System.Windows.Forms.Label alert;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}