
namespace DoAn
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
            this.btn_test = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Roll_number)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Roll)).BeginInit();
            this.SuspendLayout();
            // 
            // Roll_number
            // 
            this.Roll_number.BackColor = System.Drawing.Color.Transparent;
            this.Roll_number.BackgroundImage = global::DoAn.Properties.Resources._1;
            this.Roll_number.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Roll_number.Location = new System.Drawing.Point(1043, 63);
            this.Roll_number.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Roll_number.Name = "Roll_number";
            this.Roll_number.Size = new System.Drawing.Size(339, 383);
            this.Roll_number.TabIndex = 23;
            this.Roll_number.TabStop = false;
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit.BackgroundImage = global::DoAn.Properties.Resources.exit;
            this.btn_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_exit.Location = new System.Drawing.Point(1123, 625);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(199, 93);
            this.btn_exit.TabIndex = 22;
            this.btn_exit.TabStop = false;
            // 
            // btn_Roll
            // 
            this.btn_Roll.BackColor = System.Drawing.Color.Transparent;
            this.btn_Roll.BackgroundImage = global::DoAn.Properties.Resources.roll;
            this.btn_Roll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Roll.Location = new System.Drawing.Point(1123, 504);
            this.btn_Roll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Roll.Name = "btn_Roll";
            this.btn_Roll.Size = new System.Drawing.Size(199, 93);
            this.btn_Roll.TabIndex = 21;
            this.btn_Roll.TabStop = false;
            this.btn_Roll.Click += new System.EventHandler(this.btn_roll_Click);
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(1123, 759);
            this.btn_test.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(209, 83);
            this.btn_test.TabIndex = 24;
            this.btn_test.Text = "Create green";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // Player_Join
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DoAn.Properties.Resources.BANCO__1_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1451, 949);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.Roll_number);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_Roll);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Player_Join";
            this.Text = "Player_Join";
            this.Load += new System.EventHandler(this.Player_Join_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Roll_number)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Roll)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Roll_number;
        private System.Windows.Forms.PictureBox btn_exit;
        private System.Windows.Forms.PictureBox btn_Roll;
        private System.Windows.Forms.Button btn_test;
    }
}