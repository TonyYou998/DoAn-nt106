
namespace DoAn
{
    partial class Player
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Exit = new System.Windows.Forms.PictureBox();
            this.btn_Contact = new System.Windows.Forms.PictureBox();
            this.btn_Start = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Contact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Start)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_Exit.BackgroundImage = global::DoAn.Properties.Resources.exit;
            this.btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Exit.InitialImage = null;
            this.btn_Exit.Location = new System.Drawing.Point(704, 559);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(141, 58);
            this.btn_Exit.TabIndex = 5;
            this.btn_Exit.TabStop = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Contact
            // 
            this.btn_Contact.BackColor = System.Drawing.Color.Transparent;
            this.btn_Contact.BackgroundImage = global::DoAn.Properties.Resources.contact;
            this.btn_Contact.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Contact.InitialImage = null;
            this.btn_Contact.Location = new System.Drawing.Point(392, 559);
            this.btn_Contact.Name = "btn_Contact";
            this.btn_Contact.Size = new System.Drawing.Size(141, 58);
            this.btn_Contact.TabIndex = 4;
            this.btn_Contact.TabStop = false;
            // 
            // btn_Start
            // 
            this.btn_Start.BackColor = System.Drawing.Color.Transparent;
            this.btn_Start.BackgroundImage = global::DoAn.Properties.Resources.START;
            this.btn_Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Start.InitialImage = null;
            this.btn_Start.Location = new System.Drawing.Point(548, 473);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(147, 65);
            this.btn_Start.TabIndex = 3;
            this.btn_Start.TabStop = false;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DoAn.Properties.Resources.MainMenu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1270, 712);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Contact);
            this.Controls.Add(this.btn_Start);
            this.DoubleBuffered = true;
            this.Name = "Player";
            this.Text = "Player";
            ((System.ComponentModel.ISupportInitialize)(this.btn_Exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Contact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Start)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btn_Exit;
        private System.Windows.Forms.PictureBox btn_Contact;
        private System.Windows.Forms.PictureBox btn_Start;
    }
}

