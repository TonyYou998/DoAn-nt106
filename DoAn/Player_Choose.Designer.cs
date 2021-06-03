
namespace DoAn
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
            this.label1 = new System.Windows.Forms.Label();
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
            this.btn_Join_Room.BackgroundImage = global::DoAn.Properties.Resources.JOIN;
            this.btn_Join_Room.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Join_Room.Location = new System.Drawing.Point(684, 435);
            this.btn_Join_Room.Name = "btn_Join_Room";
            this.btn_Join_Room.Size = new System.Drawing.Size(177, 73);
            this.btn_Join_Room.TabIndex = 12;
            this.btn_Join_Room.TabStop = false;
            this.btn_Join_Room.Click += new System.EventHandler(this.btn_Join_Room_Click);
            // 
            // btn_Create_Room
            // 
            this.btn_Create_Room.BackColor = System.Drawing.Color.Transparent;
            this.btn_Create_Room.BackgroundImage = global::DoAn.Properties.Resources.CREATE;
            this.btn_Create_Room.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Create_Room.ErrorImage = null;
            this.btn_Create_Room.Location = new System.Drawing.Point(432, 435);
            this.btn_Create_Room.Name = "btn_Create_Room";
            this.btn_Create_Room.Size = new System.Drawing.Size(177, 73);
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
            this.lbRoomName.Location = new System.Drawing.Point(391, 312);
            this.lbRoomName.Name = "lbRoomName";
            this.lbRoomName.Size = new System.Drawing.Size(184, 41);
            this.lbRoomName.TabIndex = 7;
            this.lbRoomName.Text = "Room Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(380, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 41);
            this.label1.TabIndex = 8;
            this.label1.Text = "UserName:";
            // 
            // PlayerName
            // 
            this.PlayerName.AutoSize = true;
            this.PlayerName.BackColor = System.Drawing.Color.Transparent;
            this.PlayerName.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlayerName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PlayerName.Location = new System.Drawing.Point(576, 205);
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.Size = new System.Drawing.Size(302, 41);
            this.PlayerName.TabIndex = 9;
            this.PlayerName.Text = "Tên đã nhập trước đó";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbName.Location = new System.Drawing.Point(390, 205);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(164, 41);
            this.lbName.TabIndex = 10;
            this.lbName.Text = "UserName:";
            // 
            // RoomName
            // 
            this.RoomName.BackColor = System.Drawing.Color.White;
            this.RoomName.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RoomName.Location = new System.Drawing.Point(566, 315);
            this.RoomName.Name = "RoomName";
            this.RoomName.Size = new System.Drawing.Size(325, 38);
            this.RoomName.TabIndex = 6;
            this.RoomName.Text = "";
            // 
            // Player_Choose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DoAn.Properties.Resources.Client__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1270, 712);
            this.Controls.Add(this.btn_Join_Room);
            this.Controls.Add(this.btn_Create_Room);
            this.Controls.Add(this.lbRoomName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlayerName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.RoomName);
            this.DoubleBuffered = true;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PlayerName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.RichTextBox RoomName;
    }
}