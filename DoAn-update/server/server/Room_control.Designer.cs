
namespace Cờ_cá_ngựa
{
    partial class Room_control
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
            this.Box_listview = new System.Windows.Forms.ListView();
            this.RoomID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeStart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // Box_listview
            // 
            this.Box_listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RoomID,
            this.Title,
            this.TimeStart});
            this.Box_listview.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Box_listview.GridLines = true;
            this.Box_listview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.Box_listview.HideSelection = false;
            this.Box_listview.Location = new System.Drawing.Point(9, 10);
            this.Box_listview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Box_listview.Name = "Box_listview";
            this.Box_listview.Size = new System.Drawing.Size(851, 551);
            this.Box_listview.TabIndex = 0;
            this.Box_listview.UseCompatibleStateImageBehavior = false;
            this.Box_listview.View = System.Windows.Forms.View.Details;
            // 
            // RoomID
            // 
            this.RoomID.Text = "Phòng";
            this.RoomID.Width = 198;
            // 
            // Title
            // 
            this.Title.Text = "Nội Dung";
            this.Title.Width = 414;
            // 
            // TimeStart
            // 
            this.TimeStart.Text = "Thời gian bắt đầu";
            this.TimeStart.Width = 238;
            // 
            // Room_control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 570);
            this.Controls.Add(this.Box_listview);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Room_control";
            this.Text = "Room_control";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView Box_listview;
        private System.Windows.Forms.ColumnHeader RoomID;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader TimeStart;
    }
}