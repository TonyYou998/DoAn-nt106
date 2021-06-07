
namespace Client
{
    partial class Player_Choose
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
            this.btn_Join_Room = new System.Windows.Forms.PictureBox();
            this.btn_Create_Room = new System.Windows.Forms.PictureBox();
            this.lbRoomName = new System.Windows.Forms.Label();
            this.PlayerName = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.RoomName = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Join_Room)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Create_Room)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Join_Room
            // 
            this.btn_Join_Room.BackColor = System.Drawing.Color.Transparent;
            this.btn_Join_Room.BackgroundImage = global::Client.Properties.Resources.JOIN;
            this.btn_Join_Room.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Join_Room.Location = new System.Drawing.Point(783, 580);
            this.btn_Join_Room.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Join_Room.Name = "btn_Join_Room";
            this.btn_Join_Room.Size = new System.Drawing.Size(202, 97);
            this.btn_Join_Room.TabIndex = 12;
            this.btn_Join_Room.TabStop = false;
            this.btn_Join_Room.Click += new System.EventHandler(this.btn_Join_Room_Click);
            // 
            // btn_Create_Room
            // 
            this.btn_Create_Room.BackColor = System.Drawing.Color.Transparent;
            this.btn_Create_Room.BackgroundImage = global::Client.Properties.Resources.CREATE;
            this.btn_Create_Room.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Create_Room.ErrorImage = null;
            this.btn_Create_Room.Location = new System.Drawing.Point(491, 580);
            this.btn_Create_Room.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Create_Room.Name = "btn_Create_Room";
            this.btn_Create_Room.Size = new System.Drawing.Size(202, 97);
            this.btn_Create_Room.TabIndex = 11;
            this.btn_Create_Room.TabStop = false;
            this.btn_Create_Room.Click += new System.EventHandler(this.btn_Create_Room_Click);
            // 
            // lbRoomName
            // 
            this.lbRoomName.AutoSize = true;
            this.lbRoomName.BackColor = System.Drawing.Color.Transparent;
            this.lbRoomName.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbRoomName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbRoomName.Location = new System.Drawing.Point(438, 420);
            this.lbRoomName.Name = "lbRoomName";
            this.lbRoomName.Size = new System.Drawing.Size(227, 50);
            this.lbRoomName.TabIndex = 7;
            this.lbRoomName.Text = "Room Name";
            // 
            // PlayerName
            // 
            this.PlayerName.AutoSize = true;
            this.PlayerName.BackColor = System.Drawing.Color.Transparent;
            this.PlayerName.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlayerName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PlayerName.Location = new System.Drawing.Point(658, 273);
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.Size = new System.Drawing.Size(372, 50);
            this.PlayerName.TabIndex = 9;
            this.PlayerName.Text = "Tên đã nhập trước đó";
            this.PlayerName.Click += new System.EventHandler(this.PlayerName_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbName.Location = new System.Drawing.Point(446, 273);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(201, 50);
            this.lbName.TabIndex = 10;
            this.lbName.Text = "UserName:";
            // 
            // RoomName
            // 
            this.RoomName.BackColor = System.Drawing.Color.White;
            this.RoomName.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RoomName.Location = new System.Drawing.Point(671, 417);
            this.RoomName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RoomName.Name = "RoomName";
            this.RoomName.Size = new System.Drawing.Size(371, 49);
            this.RoomName.TabIndex = 6;
            this.RoomName.Text = "";
            // 
            // Player_Choose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.Client__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1451, 949);
            this.Controls.Add(this.btn_Join_Room);
            this.Controls.Add(this.btn_Create_Room);
            this.Controls.Add(this.lbRoomName);
            this.Controls.Add(this.PlayerName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.RoomName);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Player_Choose";
            this.Text = "PlayerChoose";
            ((System.ComponentModel.ISupportInitialize)(this.btn_Join_Room)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Create_Room)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btn_Join_Room;
        private System.Windows.Forms.PictureBox btn_Create_Room;
        private System.Windows.Forms.Label lbRoomName;
        private System.Windows.Forms.Label PlayerName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.RichTextBox RoomName;
    }
}