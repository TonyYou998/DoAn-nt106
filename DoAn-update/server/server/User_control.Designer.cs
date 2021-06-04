
namespace Cờ_cá_ngựa
{
    partial class User_control
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
            this.ID_LB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Username_LB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RoomID_LB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // Box_listview
            // 
            this.Box_listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID_LB,
            this.Username_LB,
            this.RoomID_LB});
            this.Box_listview.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Box_listview.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.Box_listview.GridLines = true;
            this.Box_listview.HideSelection = false;
            this.Box_listview.Location = new System.Drawing.Point(25, 23);
            this.Box_listview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Box_listview.Name = "Box_listview";
            this.Box_listview.Size = new System.Drawing.Size(719, 640);
            this.Box_listview.TabIndex = 0;
            this.Box_listview.UseCompatibleStateImageBehavior = false;
            this.Box_listview.View = System.Windows.Forms.View.Details;
            // 
            // ID_LB
            // 
            this.ID_LB.Text = "ID";
            this.ID_LB.Width = 150;
            // 
            // Username_LB
            // 
            this.Username_LB.Text = "Username";
            this.Username_LB.Width = 165;
            // 
            // RoomID_LB
            // 
            this.RoomID_LB.Text = "RoomID";
            this.RoomID_LB.Width = 186;
            // 
            // User_control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 694);
            this.Controls.Add(this.Box_listview);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "User_control";
            this.Text = "Manage user";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView Box_listview;
        private System.Windows.Forms.ColumnHeader ID_LB;
        private System.Windows.Forms.ColumnHeader Username_LB;
        private System.Windows.Forms.ColumnHeader RoomID_LB;
    }
}