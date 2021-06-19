
namespace Client
{
    partial class Host
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
            this.btn_Start = new System.Windows.Forms.PictureBox();
            this.alert = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.Roll_number)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Roll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Start)).BeginInit();
            this.SuspendLayout();
            // 
            // Roll_number
            // 
            this.Roll_number.BackColor = System.Drawing.Color.Transparent;
            this.Roll_number.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Roll_number.Location = new System.Drawing.Point(910, 50);
            this.Roll_number.Name = "Roll_number";
            this.Roll_number.Size = new System.Drawing.Size(300, 300);
            this.Roll_number.TabIndex = 18;
            this.Roll_number.TabStop = false;
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_exit.Location = new System.Drawing.Point(983, 577);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(174, 70);
            this.btn_exit.TabIndex = 17;
            this.btn_exit.TabStop = false;
            // 
            // btn_Roll
            // 
            this.btn_Roll.BackColor = System.Drawing.Color.Transparent;
            this.btn_Roll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Roll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Roll.Location = new System.Drawing.Point(980, 380);
            this.btn_Roll.Name = "btn_Roll";
            this.btn_Roll.Size = new System.Drawing.Size(174, 70);
            this.btn_Roll.TabIndex = 16;
            this.btn_Roll.TabStop = false;
            this.btn_Roll.Click += new System.EventHandler(this.btn_roll_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.BackColor = System.Drawing.Color.Transparent;
            this.btn_Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Start.Location = new System.Drawing.Point(983, 473);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(174, 70);
            this.btn_Start.TabIndex = 15;
            this.btn_Start.TabStop = false;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // alert
            // 
            this.alert.AutoSize = true;
            this.alert.BackColor = System.Drawing.Color.Transparent;
            this.alert.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.alert.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.alert.Location = new System.Drawing.Point(52, 19);
            this.alert.Name = "alert";
            this.alert.Size = new System.Drawing.Size(72, 26);
            this.alert.TabIndex = 19;
            this.alert.Text = "aaaaaa";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(910, 9);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(201, 34);
            this.progressBar1.TabIndex = 20;
            // 
            // Host
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1270, 712);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.alert);
            this.Controls.Add(this.Roll_number);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_Roll);
            this.Controls.Add(this.btn_Start);
            this.DoubleBuffered = true;
            this.Name = "Host";
            this.Text = "Player_Create";
            ((System.ComponentModel.ISupportInitialize)(this.Roll_number)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Roll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Start)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Roll_number;
        private System.Windows.Forms.PictureBox btn_exit;
        private System.Windows.Forms.PictureBox btn_Roll;
        private System.Windows.Forms.PictureBox btn_Start;
        private System.Windows.Forms.Label alert;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}