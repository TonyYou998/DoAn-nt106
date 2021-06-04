
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
            this.btn_Connect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Connect.Location = new System.Drawing.Point(646, 667);
            this.btn_Connect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(206, 100);
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
            this.lbIP.Location = new System.Drawing.Point(450, 397);
            this.lbIP.Name = "lbIP";
            this.lbIP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbIP.Size = new System.Drawing.Size(165, 50);
            this.lbIP.TabIndex = 6;
            this.lbIP.Text = "IP Server";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.BackColor = System.Drawing.Color.Transparent;
            this.lbPort.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbPort.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbPort.Location = new System.Drawing.Point(450, 551);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(90, 50);
            this.lbPort.TabIndex = 7;
            this.lbPort.Text = "Port";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbName.Location = new System.Drawing.Point(450, 259);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(193, 50);
            this.lbName.TabIndex = 8;
            this.lbName.Text = "UserName";
            // 
            // UserName
            // 
            this.UserName.BackColor = System.Drawing.Color.White;
            this.UserName.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UserName.Location = new System.Drawing.Point(661, 263);
            this.UserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(371, 49);
            this.UserName.TabIndex = 3;
            this.UserName.Text = "";
            // 
            // Port
            // 
            this.Port.BackColor = System.Drawing.Color.White;
            this.Port.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Port.Location = new System.Drawing.Point(661, 547);
            this.Port.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(371, 49);
            this.Port.TabIndex = 4;
            this.Port.Text = "";
            // 
            // IpServer
            // 
            this.IpServer.BackColor = System.Drawing.Color.White;
            this.IpServer.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IpServer.Location = new System.Drawing.Point(661, 401);
            this.IpServer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IpServer.Name = "IpServer";
            this.IpServer.Size = new System.Drawing.Size(371, 49);
            this.IpServer.TabIndex = 5;
            this.IpServer.Text = "";
            this.IpServer.TextChanged += new System.EventHandler(this.IpServer_TextChanged);
            // 
            // Info_Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1451, 949);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.lbIP);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.IpServer);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Info_Player";
            this.Text = "Info_Player";
            this.Load += new System.EventHandler(this.Info_Player_Load);
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