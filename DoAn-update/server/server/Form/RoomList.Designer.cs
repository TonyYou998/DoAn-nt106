
namespace Server
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
            this.Member_count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // Box_listview
            // 
            this.Box_listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RoomID,
            this.Title,
            this.Member_count});
            this.Box_listview.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Box_listview.GridLines = true;
            this.Box_listview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.Box_listview.HideSelection = false;
            this.Box_listview.Location = new System.Drawing.Point(12, 12);
            this.Box_listview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Box_listview.MultiSelect = false;
            this.Box_listview.Name = "Box_listview";
            this.Box_listview.Size = new System.Drawing.Size(1111, 730);
            this.Box_listview.TabIndex = 0;
            this.Box_listview.UseCompatibleStateImageBehavior = false;
            this.Box_listview.View = System.Windows.Forms.View.Details;
            this.Box_listview.SelectedIndexChanged += new System.EventHandler(this.Box_listview_SelectedIndexChanged);
            // 
            // RoomID
            // 
            this.RoomID.Text = "Phòng";
            this.RoomID.Width = 198;
            // 
            // Title
            // 
            this.Title.Text = "Tên Phòng";
            this.Title.Width = 356;
            // 
            // Member_count
            // 
            this.Member_count.Text = "Số lượng người chơi";
            this.Member_count.Width = 261;
            // 
            // Room_control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 757);
            this.Controls.Add(this.Box_listview);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Room_control";
            this.Text = "Room_control";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView Box_listview;
        private System.Windows.Forms.ColumnHeader RoomID;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Member_count;
    }
}