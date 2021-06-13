
namespace Client
{
    partial class Player_Join
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
            this.Roll_number.Click += new System.EventHandler(this.Roll_number_Click);
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
            // Player_Join
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.BANCO__1_3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1270, 712);
            this.Controls.Add(this.Roll_number);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_Roll);
            this.DoubleBuffered = true;
            this.Name = "Player_Join";
            this.Text = "Player_Join";
            ((System.ComponentModel.ISupportInitialize)(this.Roll_number)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Roll)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Roll_number;
        private System.Windows.Forms.PictureBox btn_exit;
        private System.Windows.Forms.PictureBox btn_Roll;
    }
}