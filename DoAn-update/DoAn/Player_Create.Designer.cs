﻿
namespace Client
{
    partial class Player_Create
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
            ((System.ComponentModel.ISupportInitialize)(this.Roll_number)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Roll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Start)).BeginInit();
            this.SuspendLayout();
            // 
            // Roll_number
            // 
            this.Roll_number.BackColor = System.Drawing.Color.Transparent;
            this.Roll_number.BackgroundImage = global::Client.Properties.Resources._1;
            this.Roll_number.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Roll_number.Location = new System.Drawing.Point(1040, 67);
            this.Roll_number.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Roll_number.Name = "Roll_number";
            this.Roll_number.Size = new System.Drawing.Size(343, 400);
            this.Roll_number.TabIndex = 18;
            this.Roll_number.TabStop = false;
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit.BackgroundImage = global::Client.Properties.Resources.exit;
            this.btn_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_exit.Location = new System.Drawing.Point(1123, 769);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(199, 93);
            this.btn_exit.TabIndex = 17;
            this.btn_exit.TabStop = false;
            // 
            // btn_Roll
            // 
            this.btn_Roll.BackColor = System.Drawing.Color.Transparent;
            this.btn_Roll.BackgroundImage = global::Client.Properties.Resources.roll;
            this.btn_Roll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Roll.Location = new System.Drawing.Point(1120, 507);
            this.btn_Roll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Roll.Name = "btn_Roll";
            this.btn_Roll.Size = new System.Drawing.Size(199, 93);
            this.btn_Roll.TabIndex = 16;
            this.btn_Roll.TabStop = false;
            this.btn_Roll.Click += new System.EventHandler(this.btn_roll_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.BackColor = System.Drawing.Color.Transparent;
            this.btn_Start.BackgroundImage = global::Client.Properties.Resources.START_2;
            this.btn_Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Start.Location = new System.Drawing.Point(1123, 631);
            this.btn_Start.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(199, 93);
            this.btn_Start.TabIndex = 15;
            this.btn_Start.TabStop = false;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // Player_Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.BANCO__1_2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1451, 949);
            this.Controls.Add(this.Roll_number);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_Roll);
            this.Controls.Add(this.btn_Start);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Player_Create";
            this.Text = "Player_Create";
          
            ((System.ComponentModel.ISupportInitialize)(this.Roll_number)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Roll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Start)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Roll_number;
        private System.Windows.Forms.PictureBox btn_exit;
        private System.Windows.Forms.PictureBox btn_Roll;
        private System.Windows.Forms.PictureBox btn_Start;
    }
}