namespace TwitterView
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.IDBox = new System.Windows.Forms.TextBox();
            this.IDLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.calendar = new System.Windows.Forms.DateTimePicker();
            this.DateMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XpriceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DifCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SentCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tweetLengthCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PictureCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.IDCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HashtagsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NameMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.revertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DateMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.menu.SuspendLayout();
            this.NameMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // IDBox
            // 
            this.IDBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IDBox.Location = new System.Drawing.Point(12, 531);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(180, 22);
            this.IDBox.TabIndex = 1;
            this.IDBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IDBox_KeyDown);
            // 
            // IDLabel
            // 
            this.IDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IDLabel.AutoSize = true;
            this.IDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDLabel.Location = new System.Drawing.Point(12, 499);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(180, 29);
            this.IDLabel.TabIndex = 2;
            this.IDLabel.Text = "Add Product ID:";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(873, 518);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(105, 35);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // calendar
            // 
            this.calendar.Location = new System.Drawing.Point(400, 529);
            this.calendar.Name = "calendar";
            this.calendar.Size = new System.Drawing.Size(230, 22);
            this.calendar.TabIndex = 4;
            this.calendar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.calendar_KeyDown);
            // 
            // DateMenu
            // 
            this.DateMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DateMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeDateToolStripMenuItem});
            this.DateMenu.Name = "menu";
            this.DateMenu.Size = new System.Drawing.Size(165, 28);
            this.DateMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.menu_MouseClick);
            // 
            // changeDateToolStripMenuItem
            // 
            this.changeDateToolStripMenuItem.Name = "changeDateToolStripMenuItem";
            this.changeDateToolStripMenuItem.Size = new System.Drawing.Size(164, 24);
            this.changeDateToolStripMenuItem.Text = "Change Date";
            this.changeDateToolStripMenuItem.Click += new System.EventHandler(this.changeDateToolStripMenuItem_Click);
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameCol,
            this.PriceCol,
            this.XpriceCol,
            this.DifCol,
            this.SentCol,
            this.DateCol,
            this.tweetLengthCol,
            this.PictureCol,
            this.IDCol,
            this.HashtagsCol});
            this.DGV.Dock = System.Windows.Forms.DockStyle.Top;
            this.DGV.Location = new System.Drawing.Point(0, 0);
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersWidth = 51;
            this.DGV.RowTemplate.Height = 24;
            this.DGV.Size = new System.Drawing.Size(990, 486);
            this.DGV.TabIndex = 0;
            this.DGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellContentClick);
            this.DGV.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellLeave);
            this.DGV.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DGV_CellValidating);
            this.DGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellValueChanged);
            this.DGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_KeyDown);
            this.DGV.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DGV_MouseClick);
            // 
            // NameCol
            // 
            this.NameCol.HeaderText = "Name";
            this.NameCol.MinimumWidth = 6;
            this.NameCol.Name = "NameCol";
            this.NameCol.Width = 150;
            // 
            // PriceCol
            // 
            this.PriceCol.HeaderText = "Price";
            this.PriceCol.MinimumWidth = 6;
            this.PriceCol.Name = "PriceCol";
            this.PriceCol.Width = 50;
            // 
            // XpriceCol
            // 
            this.XpriceCol.HeaderText = "Xprice";
            this.XpriceCol.MinimumWidth = 6;
            this.XpriceCol.Name = "XpriceCol";
            this.XpriceCol.Width = 50;
            // 
            // DifCol
            // 
            this.DifCol.HeaderText = "Difference";
            this.DifCol.MinimumWidth = 6;
            this.DifCol.Name = "DifCol";
            this.DifCol.Width = 50;
            // 
            // SentCol
            // 
            this.SentCol.HeaderText = "Sent";
            this.SentCol.MinimumWidth = 6;
            this.SentCol.Name = "SentCol";
            this.SentCol.Width = 50;
            // 
            // DateCol
            // 
            this.DateCol.HeaderText = "Date";
            this.DateCol.MinimumWidth = 6;
            this.DateCol.Name = "DateCol";
            this.DateCol.ReadOnly = true;
            this.DateCol.Width = 125;
            // 
            // tweetLengthCol
            // 
            this.tweetLengthCol.HeaderText = "Tweet Length";
            this.tweetLengthCol.MinimumWidth = 6;
            this.tweetLengthCol.Name = "tweetLengthCol";
            this.tweetLengthCol.Width = 60;
            // 
            // PictureCol
            // 
            this.PictureCol.HeaderText = "Picture";
            this.PictureCol.Image = ((System.Drawing.Image)(resources.GetObject("PictureCol.Image")));
            this.PictureCol.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.PictureCol.MinimumWidth = 6;
            this.PictureCol.Name = "PictureCol";
            this.PictureCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PictureCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PictureCol.Width = 125;
            // 
            // IDCol
            // 
            this.IDCol.HeaderText = "ID";
            this.IDCol.MinimumWidth = 6;
            this.IDCol.Name = "IDCol";
            this.IDCol.Width = 75;
            // 
            // HashtagsCol
            // 
            this.HashtagsCol.HeaderText = "Hashtags";
            this.HashtagsCol.MinimumWidth = 6;
            this.HashtagsCol.Name = "HashtagsCol";
            this.HashtagsCol.Width = 200;
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteRowToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(156, 28);
            // 
            // deleteRowToolStripMenuItem
            // 
            this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.deleteRowToolStripMenuItem.Text = "Delete Row";
            this.deleteRowToolStripMenuItem.Click += new System.EventHandler(this.deleteRowToolStripMenuItem_Click);
            // 
            // NameMenu
            // 
            this.NameMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.NameMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.revertToolStripMenuItem});
            this.NameMenu.Name = "NameMenu";
            this.NameMenu.Size = new System.Drawing.Size(121, 28);
            // 
            // revertToolStripMenuItem
            // 
            this.revertToolStripMenuItem.Name = "revertToolStripMenuItem";
            this.revertToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.revertToolStripMenuItem.Text = "Revert";
            this.revertToolStripMenuItem.Click += new System.EventHandler(this.revertToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 565);
            this.Controls.Add(this.calendar);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.IDBox);
            this.Controls.Add(this.DGV);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DateMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.menu.ResumeLayout(false);
            this.NameMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.DateTimePicker calendar;
        private System.Windows.Forms.ContextMenuStrip DateMenu;
        private System.Windows.Forms.ToolStripMenuItem changeDateToolStripMenuItem;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem deleteRowToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn XpriceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DifCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SentCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn tweetLengthCol;
        private System.Windows.Forms.DataGridViewImageColumn PictureCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HashtagsCol;
        private System.Windows.Forms.ContextMenuStrip NameMenu;
        private System.Windows.Forms.ToolStripMenuItem revertToolStripMenuItem;
    }
}

