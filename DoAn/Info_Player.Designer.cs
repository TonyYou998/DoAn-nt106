
namespace DoAn
{
    partial class Info_Player
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
            this.btn_Connect = new System.Windows.Forms.PictureBox();
            this.lbIP = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.RichTextBox();
            this.Port = new System.Windows.Forms.RichTextBox();
            this.IpServer = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Connect)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Connect
            // 
            this.btn_Connect.BackColor = System.Drawing.Color.Transparent;
            this.btn_Connect.BackgroundImage = global::DoAn.Properties.Resources.CONNECT;
            this.btn_Connect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Connect.Location = new System.Drawing.Point(565, 496);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(177, 73);
            this.btn_Connect.TabIndex = 9;
            this.btn_Connect.TabStop = false;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // lbIP
            // 
            this.lbIP.AutoSize = true;
            this.lbIP.BackColor = System.Drawing.Color.Transparent;
            this.lbIP.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbIP.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbIP.Location = new System.Drawing.Point(394, 298);
            this.lbIP.Name = "lbIP";
            this.lbIP.Size = new System.Drawing.Size(133, 41);
            this.lbIP.TabIndex = 6;
            this.lbIP.Text = "IP Server";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.BackColor = System.Drawing.Color.Transparent;
            this.lbPort.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbPort.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbPort.Location = new System.Drawing.Point(394, 413);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(72, 41);
            this.lbPort.TabIndex = 7;
            this.lbPort.Text = "Port";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbName.Location = new System.Drawing.Point(394, 194);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(157, 41);
            this.lbName.TabIndex = 8;
            this.lbName.Text = "UserName";
            // 
            // UserName
            // 
            this.UserName.BackColor = System.Drawing.Color.White;
            this.UserName.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UserName.Location = new System.Drawing.Point(578, 197);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(325, 38);
            this.UserName.TabIndex = 3;
            this.UserName.Text = "";
            // 
            // Port
            // 
            this.Port.BackColor = System.Drawing.Color.White;
            this.Port.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Port.Location = new System.Drawing.Point(578, 410);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(325, 38);
            this.Port.TabIndex = 4;
            this.Port.Text = "";
            // 
            // IpServer
            // 
            this.IpServer.BackColor = System.Drawing.Color.White;
            this.IpServer.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IpServer.Location = new System.Drawing.Point(578, 301);
            this.IpServer.Name = "IpServer";
            this.IpServer.Size = new System.Drawing.Size(325, 38);
            this.IpServer.TabIndex = 5;
            this.IpServer.Text = "";
            // 
            // Info_Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DoAn.Properties.Resources.Client__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1270, 712);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.lbIP);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.IpServer);
            this.DoubleBuffered = true;
            this.Name = "Info_Player";
            this.Text = "Info_Player";
            ((System.ComponentModel.ISupportInitialize)(this.btn_Connect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btn_Connect;
        private System.Windows.Forms.Label lbIP;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.RichTextBox UserName;
        private System.Windows.Forms.RichTextBox Port;
        private System.Windows.Forms.RichTextBox IpServer;
    }
}